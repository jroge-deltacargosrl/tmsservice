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
    [RoutePrefix(RESOURCE_TASK_CONFIGURATION)]
    public class TaskConfigurationController : ApiController
    {

        private readonly TaskConfigurationDAL taskConfigurationDAL;

        public TaskConfigurationController(TaskConfigurationDAL taskConfigurationDAL)
        {
            this.taskConfigurationDAL = taskConfigurationDAL;
        }

        [HttpGet]
        [Route(ROOT)]
        public ActionResultApi<IEnumerable<TaskConfigurationDTO>> getAll()
        {
            return new ActionResultApi<IEnumerable<TaskConfigurationDTO>>(HttpStatusCode.OK, taskConfigurationDAL.getAll(), Request);
        }

        [HttpGet]
        [Route(FIELD_STATE_TASK)]
        public ActionResultApi<IEnumerable<TaskConfigurationDTO>> getAllByStateView(int stateTask)
        {
            return new ActionResultApi<IEnumerable<TaskConfigurationDTO>>(HttpStatusCode.OK, taskConfigurationDAL.getAll(filter: taskConf => taskConf.estado == stateTask), Request);
        }


        [HttpGet]
        [Route(FIELD_ID)]
        public ActionResultApi<TaskConfigurationDTO> getById(int id)
        {
            return new ActionResultApi<TaskConfigurationDTO>(HttpStatusCode.OK, taskConfigurationDAL.getById(id), Request);
        }

        [HttpPost]
        [Route(ROOT)]
        public ActionResultApi<TaskConfigurationDTO> create(TaskConfigurationDTO model)
        {
            return new ActionResultApi<TaskConfigurationDTO>(HttpStatusCode.OK, taskConfigurationDAL.create(model), Request);
        }

        [HttpPut]
        [Route(ROOT)]
        public ActionResultApi<TaskConfigurationDTO> update(TaskConfigurationDTO model)
        {
            return new ActionResultApi<TaskConfigurationDTO>(HttpStatusCode.OK, taskConfigurationDAL.update(model), Request);
        }

        [HttpPut]
        [Route(UPDATE_ALLOW_DOCS_AND_DISPLAY_FOR_CLIENT)]
        public ActionResultApi<TaskConfigurationDTO> updateAllowDocumentsAndDisplayForClient(TaskConfigurationDTO model)
        {
            return new ActionResultApi<TaskConfigurationDTO>(HttpStatusCode.OK, taskConfigurationDAL.updateAllowDocumentsAndDisplayForClient(model), Request) ;
        }

        [HttpDelete]
        [Route(ROOT)]
        public ActionResultApi<TaskConfigurationDTO> remove(int id)
        {
            return new ActionResultApi<TaskConfigurationDTO>(HttpStatusCode.OK, taskConfigurationDAL.delete(id), Request);
        }




    }
}
