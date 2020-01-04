using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;

namespace TMS_Services.Models.DTO
{
    public class ServiceTypeDTO
    {
        public int id { get; set; }
        public string name { get; set; }

        public static explicit operator ServiceTypeDTO(TipoServicio entity)  
            => new ServiceTypeDTO
            {
                id = entity.id, 
                name = entity.servicio.Trim()
            };

        public static implicit operator TipoServicio(ServiceTypeDTO model) 
            => new TipoServicio
            {
                id = model.id,
                servicio = model.name.Trim(),
                create_at = DateTime.Now
            };

    }
}