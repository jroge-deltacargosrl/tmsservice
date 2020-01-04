using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Models.DTO
{
    public class UserDTO
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public byte clientType { get; set; }
        public byte supplierType { get; set; }
        public byte employeeType { get; set; }
        public int? id_membership { get; set; }
        public bool canSend { get; set; }



        // Acceso Tipo Web
        public int typeAccess { get; set; } // portal cliente = 1, tms web = 2, app choferes = 3  

        public static explicit operator UserDTO(usuario entity)
            => !isNull(entity)
            ? new UserDTO
            {
                id = entity.id,
                email = entity.correo,
                password = entity.password,
                clientType = entity.tipo_c,
                employeeType = entity.tipo_e,
                supplierType = entity.tipo_s,
                id_membership = entity.id_afiliacion,
                typeAccess = entity.tipo_c == 1 ? 1 : entity.tipo_e,
                canSend = Convert.ToBoolean(entity.enviar_password)
            } : default;


        public static implicit operator usuario(UserDTO model)
            => !isNull(model)
            ? new usuario
            {
                id = model.id,
                correo = model.email,
                password = model.password,
                tipo_c = model.clientType,
                tipo_e = model.employeeType,
                tipo_s = model.supplierType,
                id_afiliacion = model.id_membership,
                enviar_password = Convert.ToInt32(model.canSend),
                create_at = DateTime.UtcNow
            } : default;

    }
}