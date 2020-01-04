using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.Infraestructure.Interfaces;
using TMS_Services.Models.DTO;

namespace TMS_Services.Infraestructure.Interfaces
{
    // pendiente de implementar tabla en la base de datos SQL AZURE
    public interface IOperationRepository 
    {

        IEnumerable<ProjectDTO> getAllOperationsByTypeAccess(int typeAccess, int id);
        IEnumerable<ProjectDTO> getAllOperations();

        //string getNameTaskByIdInERP(int taskIdErp);

    }
}