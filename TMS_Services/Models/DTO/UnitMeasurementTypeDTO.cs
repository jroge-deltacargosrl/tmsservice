using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;

namespace TMS_Services.Models.DTO
{
    public class UnitMeasurementTypeDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        


        public static explicit operator UnitMeasurementTypeDTO(TipoUnidadMedida entity) 
            => new UnitMeasurementTypeDTO
            {
                id =  entity.id,
                name = entity.nombre
            };

        public static explicit operator TipoUnidadMedida(UnitMeasurementTypeDTO model)
            => new TipoUnidadMedida
            {
                id = model.id,
                nombre = model.name
            };


    }
}