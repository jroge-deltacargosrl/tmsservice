using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using TMS_Services.Models.DTO;

namespace TMS_Services.Infraestructure.Interfaces
{
    public interface IUnitMeasurementRepository:IRepository<UnidadMedida> 
    {
        // metodos adicionales que necesita la clase
        IEnumerable<UnidadMedida> getByType(int idType);

        IEnumerable<UnitMeasurementDTO> getUnitsMeasurementFiltered(string filterName);
        
        // modificar estos metodos
        /*IEnumerable<UnidadMedida> getUnitMeasurementStorageCapacity();
        IEnumerable<UnidadMedida> getUnitMeasurementStorageTime();*/

    }
}