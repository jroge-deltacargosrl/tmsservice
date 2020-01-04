using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Services.App_Data;
using TMS_Services.Models.DTO;

namespace TMS_Services.Infraestructure.Interfaces
{
    public interface ITaskConfigurationRepository: IRepository<ConfiguracionTarea>
    {
        // metodos adicionales
        TaskConfigurationDTO updateAllowDocumentsAndDisplayForClient(TaskConfigurationDTO model);
    }
}
