using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;

namespace TMS_Services.Models.DTO
{
    public class ClientDTO
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string lastname { get; set; }
        public string company { get; set; }
        public string phone { get; set; }
        public int? id_membership { get; set; }


        public static explicit operator ClientDTO(Cliente entity)
            => new ClientDTO
            {
                id = entity.id,
                fullname = entity.nombres,
                lastname = entity.apellidos,
                company = entity.empresa,
                phone = entity.celular,
                id_membership = entity.id_afiliacion
            };

        public static implicit operator Cliente(ClientDTO model)
            => new Cliente
            {
                nombres = model.fullname,
                apellidos = model.lastname,
                empresa = model.company,
                celular = model.phone,
                id_afiliacion = model.id_membership,
                create_at = DateTime.UtcNow
            };
    }
}