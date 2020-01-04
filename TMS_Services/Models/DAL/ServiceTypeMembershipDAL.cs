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
    public class ServiceTypeMembershipDAL
    {
        private readonly IServiceTypeMembershipRepository membershipServiceTypeRepository;

        public ServiceTypeMembershipDAL(IServiceTypeMembershipRepository membershipServiceTypeRepository)
        {
            this.membershipServiceTypeRepository = membershipServiceTypeRepository;
        }

        public IEnumerable<ServiceTypeMembershipDTO> getAll(Expression<Func<TipoServicio_Afiliacion, bool>> filter = null, Func<IQueryable<TipoServicio_Afiliacion>, IOrderedQueryable<TipoServicio_Afiliacion>> orderBy = null)
        {
            return membershipServiceTypeRepository.get(filter, orderBy)
                .ToList()
                .ConvertAll(a => (ServiceTypeMembershipDTO)a);
        }

        public ServiceTypeMembershipDTO getById(int id)
        {
            return (ServiceTypeMembershipDTO)membershipServiceTypeRepository.getById(id);
        }


        public ServiceTypeMembershipDTO create(ServiceTypeMembershipDTO model)
        {
            return (ServiceTypeMembershipDTO)membershipServiceTypeRepository.create(model);
        }

        public ServiceTypeMembershipDTO delete(int id)
        {
            return (ServiceTypeMembershipDTO)membershipServiceTypeRepository.remove(id);
        }

        public IEnumerable<ServiceTypeMembershipDTO> deleteAll()
        {
            return membershipServiceTypeRepository.removeAll()
                .ToList()
                .ConvertAll(a => (ServiceTypeMembershipDTO)a);
        }

        // Metodos extras (redundancia minima con el metodo getAll() )
        public IEnumerable<ServiceTypeDTO> getAllByCompanyId(int companyId)
        {
            return membershipServiceTypeRepository.getAllByCompanyId(companyId);
        }

        public IEnumerable<ServiceTypeDTO> getAllByServiceTypeId(int serviceTypeId)
        {
            return membershipServiceTypeRepository.getAllByServiceTypeId(serviceTypeId);
        }

    }
}