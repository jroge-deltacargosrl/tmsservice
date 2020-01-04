using CookComputing.XmlRpc;
using OdooRpcWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TMS_Services.Models.DTO;
using TMS_Services.Models.ODOO_Conexion;
using TMS_Services.App_Data;
using System.IO;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using System.Configuration;
using static TMS_Services.App_Utils.UtilsApiTms;
using TMS_Services.Infraestructure.Interfaces;

namespace TMS_Services.Models.DAL
{
    public class ProjectDAL
    {
        // Refactorizar la clase con el patron unit of work
        private readonly IOperationRepository operationRepository;
        private readonly ITaskConfigurationRepository taskConfigurationRepository;
        private readonly IInformationFileRepository informationFileRepository;
        //private static ConexionOdoo conexionOdoo = new ConexionOdoo();

        public ProjectDAL(IOperationRepository operationRepository, ITaskConfigurationRepository taskConfigurationRepository, IInformationFileRepository informationFileRepository)
        {
            this.operationRepository = operationRepository;
            this.taskConfigurationRepository = taskConfigurationRepository;
            this.informationFileRepository = informationFileRepository;
        }

        // refactorizar la clase para separar los procesos direccionados en origen a odoo
        /*public string getNameTaskByIdInERP(int taskIdErp)
        {
            return operationRepository.getNameTaskByIdInERP(taskIdErp);
        }*/

        // adecuar este metodo para recibir correctamente el parametro
        public IEnumerable<ProjectDTO> getAllOperationsByTypeAccessId(int typeAccess, int id)
        {
            return operationRepository.getAllOperationsByTypeAccess(typeAccess, id);
            
        }

        public IEnumerable<ProjectDTO> getAllOperations()
        {
            return operationRepository.getAllOperations();
        }

        public FileUploadResponseDTO fileUploadedAsync(FileDTO model)
        {
            return informationFileRepository.createFile(model);
        }

        public FileUploadResponseDTO fileDeleteAsync(string fileName)
        {
            return informationFileRepository.deleteFile(fileName);
        }

        public List<string> fileGetAllAsync()
        {
            return informationFileRepository.getAllFiles();
        }
    }
}