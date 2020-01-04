using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Services.App_Data;

namespace TMS_Services.Infraestructure.Interfaces
{
    public interface IServiceTypeRepository: IRepository<TipoServicio>
    {
        // metodos adicionales
        //IEnumerable<TipoServicio> getAllByCompanyId(int companyId);

    }
}
