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
    public class InformationFileDAL
    {
        private readonly IInformationFileRepository informationFileRepository;

        public InformationFileDAL(IInformationFileRepository informationFileRepository)
        {
            this.informationFileRepository = informationFileRepository;
        }


        public IEnumerable<InformationFileDTO> getAll(Expression<Func<InfoArchivo,bool>> filter = null, Func<IQueryable<InfoArchivo>,IOrderedQueryable<InfoArchivo>> orderBy = null)
        {
            return informationFileRepository.get(filter, orderBy)
                .ToList()
                .ConvertAll(i => (InformationFileDTO)i);
        }

        public IEnumerable<InformationFileDTO> getAllByProjectId(int projectId)
        {
            return informationFileRepository.get(filter: infoFile => infoFile.id_proyecto == projectId)
                .ToList()
                .ConvertAll(info => (InformationFileDTO)info);
        }

        public IEnumerable<InformationFileDTO> getAllByTaskIdTemplate(int taskId)
        {
            return informationFileRepository.get(filter: infoFile => infoFile.id_tarea == taskId)
                .ToList()
                .ConvertAll(info => (InformationFileDTO)info);
        }


        public InformationFileDTO getByProjectTaskId(int projectId, int taskId)
        {
            return (InformationFileDTO)informationFileRepository.getFirstOrDefault(filter: infoFile => infoFile.id_proyecto == projectId && infoFile.id_tarea == taskId);
        } 

            
        public InformationFileDTO create(InformationFileDTO model)
        {
            return (InformationFileDTO)informationFileRepository.create(model);
        }

        public InformationFileDTO uppdate(InformationFileDTO model)
        {
            return (InformationFileDTO)informationFileRepository.edit(model);
        }

       
        public IEnumerable<InformationFileDTO> deleteByProjectId(int projectId)
        {
            return informationFileRepository.get(filter: info => info.id_proyecto == projectId)
                .ToList()
                .ConvertAll(info => (InformationFileDTO)info);
        }

        public IEnumerable<InformationFileDTO> deleteByTaskIdTemplate(int taskId)
        {
            return informationFileRepository.get(filter: info => info.id_tarea == taskId)
                .ToList()
                .ConvertAll(info => (InformationFileDTO)info);
        }

        public InformationFileDTO deleteByProjectTaskId(int projectId, int taskId)
        {
            return (InformationFileDTO)informationFileRepository.deleteByProjectTaskId(projectId, taskId);
        }
    }
}