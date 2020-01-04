using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS_Services.Models.DTO.ViewModels
{
    public class QuotationViewDTO
    {
        public IEnumerable<ServiceTypeDTO> servicesTypes { get; set; }
        public IEnumerable<RouteDTO> macroRoutes { get; set; }
        public IEnumerable<TruckTypeDTO> trucksTypes { get; set; }

        // recuperar los datos para las unidades de medida
        public IEnumerable<UnitMeasurementDTO> umsStorageCapacity { get; set; }
        public IEnumerable<UnitMeasurementDTO> umsStorageTime { get; set; }


            


    }
}