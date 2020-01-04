using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Models.DTO
{
    public class RouteDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; } = "";
        public bool marked { get; set; }


        // dificultad con navegacion del objeto ruta desde Tranportista_Ruta
        public static explicit operator RouteDTO(Ruta valueDb)
         => !isNull(valueDb) ?
                new RouteDTO
                {
                    id = valueDb.id,
                    name = valueDb.pais.Trim(),
                    description = valueDb.descripcion.Trim(),
                    marked = true
                }
                : null;


        public static explicit operator Ruta(RouteDTO valueModel)
            => new Ruta
            {
                id = valueModel.id,
                pais = valueModel.name.Trim(),
                descripcion = valueModel.description.Trim(),
                create_at = DateTime.Now
            };



    }
}