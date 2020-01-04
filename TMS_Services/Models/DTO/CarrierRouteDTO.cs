using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;

namespace TMS_Services.Models.DTO
{
    public class CarrierRouteDTO
    {

        public int id_carrier { get; set; }
        public int id_route { get; set; }
        public int state { get; set; }


        public static explicit operator CarrierRouteDTO(Transportista_Ruta value) 
            => new CarrierRouteDTO
            {
                id_carrier = value.id_transportista,
                id_route = value.id_ruta,
                state = value.estado
            };

        // analizar el casteo implementado 
        public static implicit operator Transportista_Ruta(CarrierRouteDTO value)
         => new Transportista_Ruta
         {
             id_transportista = value.id_carrier,
             id_ruta= value.id_route,
             estado = value.state,
             create_at = DateTime.Now
         };


    }
}