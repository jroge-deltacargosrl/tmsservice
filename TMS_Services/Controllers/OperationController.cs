using Grpc.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;
using TMS_Services.Infraestructure.API;
using TMS_Services.Models.DAL;
using TMS_Services.Models.DTO;
using TMS_Services.Models.ODOO_Conexion;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Controllers
{
    [RoutePrefix(RESOURCE_OPERATION)]
    public class OperationController : ApiController
    {
        private readonly ProjectDAL projectDAL;

        public OperationController(ProjectDAL projectDAL)
        {
            this.projectDAL = projectDAL;
        }

        // estructurar correctamente el proyecto
        [HttpGet]
        [Route(ROOT)]
        public ActionResultApi<IEnumerable<ProjectDTO>> getAllProjects()
        {
            return new ActionResultApi<IEnumerable<ProjectDTO>>(HttpStatusCode.OK, projectDAL.getAllOperations(), Request);
        }

        // Cambiando la ruta del atributo a {id}
        [HttpGet]
        [Route(FIELD_ID_BY_TYPE_ACCESS)]
        public ActionResultApi<IEnumerable<ProjectDTO>> getProjectsWithTaskById(int typeAccess, int id)
        {
            return new ActionResultApi<IEnumerable<ProjectDTO>>(HttpStatusCode.OK, projectDAL.getAllOperationsByTypeAccessId(typeAccess,id), Request);
        }

        
        [HttpPost]
        [Route(POST_UPLOAD_FILE)]
        public ActionResultApi<FileUploadResponseDTO> fileUploadAsync([FromBody] FileDTO file)
        {
            return new ActionResultApi<FileUploadResponseDTO>(HttpStatusCode.OK, projectDAL.fileUploadedAsync(file), Request);
        }

        [HttpPost]
        [Route(POST_DELETE_FILE)]
        public ActionResultApi<FileUploadResponseDTO> fileDeleteAsync([FromBody] string fileName)
        {
            return new ActionResultApi<FileUploadResponseDTO>(HttpStatusCode.OK, projectDAL.fileDeleteAsync(fileName), Request);
        }

        [HttpGet]
        [Route(GET_ALL_FILES)]
        public ActionResultApi<List<string>> fileGetAllAsync()
        {
            return new ActionResultApi<List<string>>(HttpStatusCode.OK, projectDAL.fileGetAllAsync(), Request);
        }
    }
}
