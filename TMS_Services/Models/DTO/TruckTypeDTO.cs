

using System;
using TMS_Services.App_Data;

namespace TMS_Services.Models.DTO
{
    public class TruckTypeDTO
    {
        public int id { get; set; }
        public string type { get; set; }
        public string description { get; set; }


        public static explicit operator TruckTypeDTO(TipoCamion value)
            => new TruckTypeDTO
            {
                id = value.id,
                type = value.tipo.Trim(),
                description = value.descripcion.Trim()
            };

        public static explicit operator TipoCamion(TruckTypeDTO model) 
            => new TipoCamion
            { 
                id = model.id,
                tipo = model.type.Trim(),
                descripcion = model.description.Trim(),
                create_at = DateTime.Now               
            };

    }
}