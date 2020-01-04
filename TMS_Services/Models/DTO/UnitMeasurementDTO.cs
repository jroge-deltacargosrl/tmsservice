using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;

namespace TMS_Services.Models.DTO
{
    public class UnitMeasurementDTO
    {

        public int id { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public int id_unitMeasurementType { get; set; }

        public static explicit operator UnitMeasurementDTO(UnidadMedida entity)
            => new UnitMeasurementDTO
            {
                id = entity.id,
                name = entity.nombre,
                abbreviation = entity.abreviatura,
                id_unitMeasurementType = entity.id_tipoUnidad
            };

        public static explicit operator UnidadMedida(UnitMeasurementDTO model)
            => new UnidadMedida
            {
                id = model.id,
                nombre = model.name,
                abreviatura = model.abbreviation,
                id_tipoUnidad = model.id_unitMeasurementType
            };



    }
}