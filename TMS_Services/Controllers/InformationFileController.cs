using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TMS_Services.Infraestructure.API;
using TMS_Services.Models.DAL;
using TMS_Services.Models.DTO;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Controllers
{
    [RoutePrefix(RESOURCE_INFORMATION_FILE)]
    public class InformationFileController : ApiController
    {

        private readonly InformationFileDAL informationFileDAL;
        public InformationFileController(InformationFileDAL informationFileDAL)
        {
            this.informationFileDAL = informationFileDAL;
        }


        [HttpGet]
        [Route(ROOT)]
        public ActionResultApi<IEnumerable<InformationFileDTO>> getAll()
        {
            return new ActionResultApi<IEnumerable<InformationFileDTO>>(HttpStatusCode.OK, informationFileDAL.getAll(), Request);
        }

        [HttpGet]
        [Route(FIELD_PROJECT_ID)]
        public ActionResultApi<IEnumerable<InformationFileDTO>> getAllByProjectId(int projectId)
        {
            return new ActionResultApi<IEnumerable<InformationFileDTO>>(HttpStatusCode.OK, informationFileDAL.getAll(filter: infoFile => infoFile.id_proyecto == projectId),Request);
        }

        [HttpGet]
        [Route(FIELD_TASK_ID)]
        public ActionResultApi<IEnumerable<InformationFileDTO>> getAllByTaskId(int taskId)
        {
            return new ActionResultApi<IEnumerable<InformationFileDTO>>(HttpStatusCode.OK, informationFileDAL.getAllByProjectId(taskId), Request);
        } 

        [HttpGet]
        [Route(FIELDS_PROJECT_TASK_IDS)]
        public ActionResultApi<InformationFileDTO> getByProjectTaskId(int taskId, int projectId)
        {
            return new ActionResultApi<InformationFileDTO>(HttpStatusCode.OK, informationFileDAL.getByProjectTaskId(taskId, projectId), Request);
        }

        [HttpPost]
        [Route(ROOT)]
        public ActionResultApi<InformationFileDTO> create([FromBody] InformationFileDTO model)
        {
            return new ActionResultApi<InformationFileDTO>(HttpStatusCode.OK, informationFileDAL.create(model), Request);
        }

        // funcionan en conjunto con el metodo para remover el documento del servidor de azure
        [HttpDelete]
        [Route(FIELD_PROJECT_ID)]
        public ActionResultApi<IEnumerable<InformationFileDTO>> removeByProject(int projectId)
        {
            return new ActionResultApi<IEnumerable<InformationFileDTO>>(HttpStatusCode.OK, informationFileDAL.deleteByProjectId(projectId), Request);
        }

        [HttpDelete]
        [Route(FIELD_TASK_ID)]
        public ActionResultApi<IEnumerable<InformationFileDTO>> removeByTaskTemplate(int taskId)
        {
            return new ActionResultApi<IEnumerable<InformationFileDTO>>(HttpStatusCode.OK, informationFileDAL.deleteByTaskIdTemplate(taskId), Request);
        }

        [HttpDelete]
        [Route(FIELDS_PROJECT_TASK_IDS)]
        public ActionResultApi<InformationFileDTO> removeByProjectTaskId(int projectId, int taskId)
        {
            return new ActionResultApi<InformationFileDTO>(HttpStatusCode.OK, informationFileDAL.deleteByProjectTaskId(projectId, taskId), Request);
        }


    }
}
