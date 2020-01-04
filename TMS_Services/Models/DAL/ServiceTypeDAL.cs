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
    public class ServiceTypeDAL
    {

        private readonly IServiceTypeRepository serviceTypeRepository;

        public ServiceTypeDAL(IServiceTypeRepository serviceTypeRepository)
        {
            this.serviceTypeRepository = serviceTypeRepository;
        }

        public IEnumerable<ServiceTypeDTO> getAll(Expression<Func<TipoServicio, bool>> filter = null, Func<IQueryable<TipoServicio>, IOrderedQueryable<TipoServicio>> orderBy = null)
        {
            return serviceTypeRepository.get(filter,orderBy)
                .ToList()
                .ConvertAll(item => (ServiceTypeDTO)item);
        }

        public ServiceTypeDTO getById(int id)
        {
            return (ServiceTypeDTO)serviceTypeRepository.getById(id);
                
        }

        public ServiceTypeDTO create(ServiceTypeDTO model)
        {
            return (ServiceTypeDTO)serviceTypeRepository.create(model);
        }

       
    }
}