using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Services.App_Data;
using TMS_Services.Models.DTO;

namespace TMS_Services.Infraestructure.Interfaces
{
    public interface IServiceTypeMembershipRepository : IRepository<TipoServicio_Afiliacion>
    {
        IEnumerable<ServiceTypeDTO> getAllByCompanyId(int companyId);

        IEnumerable<ServiceTypeDTO> getAllByServiceTypeId(int serviceTypeId);

    }
}
