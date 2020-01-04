using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;

namespace TMS_Services.Models.DTO
{
    public class CarrierMembershipDTO
    {

        public int id_membership { get; set; }
        public int id_carrier { get; set; }
        public int state { get; set; }


        public static explicit operator CarrierMembershipDTO(Transportista_Afiliacion entity)
            => new CarrierMembershipDTO
            {
                id_carrier = entity.id_transportista,
                id_membership =  entity.id_afiliacion,
                state = 0, // libre
            };

        public static implicit operator Transportista_Afiliacion(CarrierMembershipDTO model)
            => new Transportista_Afiliacion
            {
                id_transportista = model.id_carrier,
                id_afiliacion = model.id_membership,
                estado = model.state, // libre
                create_at = DateTime.Now
            };
    }
}