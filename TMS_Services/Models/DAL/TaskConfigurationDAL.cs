using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TMS_Services.App_Data;
using TMS_Services.Infraestructure.Interfaces;
using TMS_Services.Models.DTO;

namespace TMS_Services.Models.DAL
{
    public class TaskConfigurationDAL
    {

        private readonly ITaskConfigurationRepository taskConfigurationRepository;

        public TaskConfigurationDAL(ITaskConfigurationRepository taskConfigurationRepository)
        {
            this.taskConfigurationRepository = taskConfigurationRepository;
        }

        public IEnumerable<TaskConfigurationDTO> getAll(Expression<Func<ConfiguracionTarea, bool>> filter = null, Func<IQueryable<ConfiguracionTarea>, IOrderedQueryable<ConfiguracionTarea>> orderBy = null)
        {
            return taskConfigurationRepository.get(filter: filter, orderBy: orderBy)
                .ToList()
                .ConvertAll(tc => (TaskConfigurationDTO)tc);
        }

        public TaskConfigurationDTO getFirstOrDefault(Expression<Func<ConfiguracionTarea,bool>> filter = null)
        {
            return (TaskConfigurationDTO)taskConfigurationRepository.getFirstOrDefault(filter: filter);
        }


        public TaskConfigurationDTO getById(int id)
        {
            return (TaskConfigurationDTO)taskConfigurationRepository.getById(id);
        }

        public TaskConfigurationDTO create(TaskConfigurationDTO model)
        {
            return (TaskConfigurationDTO)taskConfigurationRepository.create(model);
        }

        public TaskConfigurationDTO update(TaskConfigurationDTO model)
        {
            return (TaskConfigurationDTO)taskConfigurationRepository.edit(model);
        }

        public TaskConfigurationDTO updateAllowDocumentsAndDisplayForClient(TaskConfigurationDTO model)
        {
            return taskConfigurationRepository.updateAllowDocumentsAndDisplayForClient(model);
        }

        public TaskConfigurationDTO delete(int id)
        {
            return (TaskConfigurationDTO)taskConfigurationRepository.remove(id);
        }




    }
}