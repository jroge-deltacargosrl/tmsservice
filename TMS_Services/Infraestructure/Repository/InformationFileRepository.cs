using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using TMS_Services.Infraestructure.Interfaces;
using TMS_Services.Models.DTO;

namespace TMS_Services.Infraestructure.Repository
{
    public class InformationFileRepository : Repository<InfoArchivo>, IInformationFileRepository
    {

        private readonly IConnectionApiOdooRepository connectionApiOdooRepository;
        private readonly ITaskConfigurationRepository taskConfigurationRepository;
        private readonly ITaskOperationRepository taskOperationRepository;

        public InformationFileRepository(DeltaDBEntities dbContext, IConnectionApiOdooRepository connectionApiOdooRepository, ITaskConfigurationRepository taskConfigurationRepository, ITaskOperationRepository taskOperationRepository) : base(dbContext)
        {
            this.connectionApiOdooRepository = connectionApiOdooRepository;
            this.taskConfigurationRepository = taskConfigurationRepository;
            this.taskOperationRepository = taskOperationRepository;
        }


        public FileUploadResponseDTO createFile(FileDTO fileModel)
        {
            /*Para sacar la ruta del directorio raiz
            string path = HttpRuntime.AppDomainAppVirtualPath != null ?
                Path.Combine(HttpRuntime.AppDomainAppPath, "App_Data") :
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);*/
            FileUploadResponseDTO result = new FileUploadResponseDTO()
            {
                responseType = 1
            };

            string fileContent = fileModel.documentContent;
            string fileName = fileModel.documentName;

            var memoryStream = new MemoryStream();
            using (var ms = new MemoryStream())
            {
                //act on the Base64 data
                var fileBytes = Convert.FromBase64String(fileContent);
                memoryStream = new MemoryStream(fileBytes);
            }
            try
            {
                // cadena de conexion al servicio de azure storage
                //string connString = "DefaultEndpointsProtocol=https;AccountName=uploadedfiles;AccountKey=M8vvc5JGmOKZWMYiW8qFOMmloZM9GuhShPcNwCSZWNxYStzhLeRPL1DbgjpApua76GoobasudU51mdqNB5Xt7A==;EndpointSuffix=core.windows.net";

                string connString = ConfigurationManager.AppSettings["connectionAzureBlobStorage_DeltaCargo"].ToString();
                string destContainer = "pdf";

                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connString);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                CloudBlobContainer container = blobClient.GetContainerReference(destContainer);
                container.CreateIfNotExists();

                // method upload Blob
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
                blockBlob.UploadFromStream(memoryStream);

                //uploadBlob(container, fileName, memoryStream);
            }
            catch (Exception ex)
            {
                result.responseType = 2;
            }
            finally
            {
                if (result.responseType == 1)
                {
                    // guardar en base de datos
                    var infoFile = new InformationFileDTO
                    {
                        //idTask = request.idTask, // id odoo tarea
                        projectId = fileModel.idProject,
                        format = fileModel.format
                    };

                    string nameTaskInErp = taskOperationRepository.getNameTaskByIdInERP(fileModel.idTask);

                    infoFile.idTask = taskConfigurationRepository.getFirstOrDefault(tc => tc.nombre.ToLower() == nameTaskInErp).id;

                    // obtener [id_tarea] de la tabla de configuracion de tareas                
                    create(infoFile);
                }
            }
            return result;
        }

        public FileUploadResponseDTO deleteFile(string fileName)
        {
            FileUploadResponseDTO result = new FileUploadResponseDTO()
            {
                responseType = 4
            };
            try
            {
                fileName = "https://deltacargostorage.blob.core.windows.net/pdf/" + fileName;
                Uri fileUri = new Uri(fileName);
                string blobName = Path.GetFileName(fileUri.LocalPath);
                string connString = ConfigurationManager.AppSettings["connectionAzureBlobStorage_DeltaCargo"].ToString();
                string destContainer = "pdf";
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connString);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(destContainer);
                container.CreateIfNotExists();

                // method delete Blob
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
                blockBlob.Delete();
            }
            catch (Exception ex)
            {
                result.responseType = 5;
            }
            return result;
        }

        public List<string> getAllFiles()
        {
            List<string> _blobList = new List<string>();
            string connString = ConfigurationManager.AppSettings["connectionAzureBlobStorage_DeltaCargo"].ToString();
            string destContainer = "pdf";
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(destContainer);
            foreach (IListBlobItem item in container.ListBlobs())
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob _blobpage = (CloudBlockBlob)item;
                    _blobList.Add(_blobpage.Uri.AbsoluteUri.ToString());
                }
            }
            return _blobList;
        }

        public InfoArchivo deleteByProjectTaskId(int projectId, int taskId)
        {
            var infoFileConfigurationFind = dbContext.InfoArchivo.Find(projectId, taskId);
            return (InformationFileDTO)dbContext.InfoArchivo.Remove(infoFileConfigurationFind);
        }

        /*public IEnumerable<InformationFileDTO> getByProjectId(int projectId)
        {
            throw new NotImplementedException();
        }

        public InformationFileDTO getByProjectTaskId(int projectId, int taskId)
        {
            throw new NotImplementedException();
        }*/
    }
}