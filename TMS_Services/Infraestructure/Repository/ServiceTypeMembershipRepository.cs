using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using TMS_Services.Infraestructure.Interfaces;
using TMS_Services.Models.DTO;

namespace TMS_Services.Infraestructure.Repository
{
    public class ServiceTypeMembershipRepository : Repository<TipoServicio_Afiliacion>, IServiceTypeMembershipRepository
    {

        public ServiceTypeMembershipRepository(DeltaDBEntities dbContext) : base(dbContext)
        {
        }

        public IEnumerable<ServiceTypeDTO> getAllByCompanyId(int companyId)
        {
            return get(s => s.id_afiliacion == companyId, includeProperties: "TipoServicio")
                .Select(s => s.TipoServicio)
                .ToList()
                .ConvertAll(s => (ServiceTypeDTO)s);
        }

        public IEnumerable<ServiceTypeDTO> getAllByServiceTypeId(int serviceTypeId)
        {
            return get(s => s.id_tipoServicio == serviceTypeId, includeProperties: "TipoServicio")
                .Select(s => s.TipoServicio)
                .ToList()
                .ConvertAll(s => (ServiceTypeDTO)s);
        }
    }
}