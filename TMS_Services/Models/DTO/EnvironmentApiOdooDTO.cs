using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Models.DTO
{
    public class EnvironmentApiOdooDTO
    {
        public int id { get; set; }
        public string nameEnvironment { get; set; }


        public static explicit operator EnvironmentApiOdooDTO(EntornoAPI entity)
            => !isNull(entity) 
            ? new EnvironmentApiOdooDTO
            {
                id = entity.id,
                nameEnvironment = entity.nombre
            }
            :default;

        public static implicit operator EntornoAPI(EnvironmentApiOdooDTO model)
           => !isNull(model)
            ? new EntornoAPI
            {
                nombre = model.nameEnvironment,
                create_at = DateTime.Now
            }
            :default;

    }
}