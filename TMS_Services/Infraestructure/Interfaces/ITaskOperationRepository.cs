using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Services.Infraestructure.Interfaces
{
    // Implementacion con la base de datos SQL Server Pendiente
    public interface ITaskOperationRepository 
    {

        string getNameTaskByIdInERP(int taskIdErp);

    }
}
