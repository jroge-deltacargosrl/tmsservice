using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using static TMS_Services.App_Utils.UtilsApiTms;


namespace TMS_Services.Models.DTO
{
    public class MembershipDTO
    {
        public int id { get; set; }
        public string company { get; set; }
        public string description { get; set; }

        public static explicit operator MembershipDTO(Afiliacion entity)
            => !isNull(entity)
            ? new MembershipDTO
            {
                id = entity.id,
                company = entity.empresa,
                description = entity.descripcion
            }
            : default;

        public static implicit operator Afiliacion(MembershipDTO model)
            => isNull(model)
            ?new Afiliacion
            {
                empresa = model.company,
                descripcion = model.description,
                create_at = DateTime.UtcNow
            }
            :default;

    }
}