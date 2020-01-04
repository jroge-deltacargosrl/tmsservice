using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using TMS_Services.Infraestructure.Interfaces;
using TMS_Services.Models.DTO;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Infraestructure.Repository
{
    public class TaskConfigurationRepository : Repository<ConfiguracionTarea>, ITaskConfigurationRepository
    {

        private readonly IConnectionApiOdooRepository connectionApiOdooRepository;

        public TaskConfigurationRepository(DeltaDBEntities dbContext, IConnectionApiOdooRepository connectionApiOdooRepository) : base(dbContext)
        {
            this.connectionApiOdooRepository = connectionApiOdooRepository;
        }

        public TaskConfigurationDTO updateAllowDocumentsAndDisplayForClient(TaskConfigurationDTO model)
        {
            var taskEntity = getById(model.id);
            if (!isNull(taskEntity))
            {
                taskEntity.permitirDocs = model.allowDocuments;
                taskEntity.estado = model.state; // visualizacion al cliente
                return (TaskConfigurationDTO)edit(taskEntity);
            }
            return model; // no se realizo ninguna modificacion
        }
    }
}