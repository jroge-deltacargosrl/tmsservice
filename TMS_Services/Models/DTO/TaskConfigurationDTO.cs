using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Models.DTO
{
    public class TaskConfigurationDTO
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int state { get; set; }
        public string description { get; set; }
        public int allowDocuments  { get; set; }


        public static explicit operator TaskConfigurationDTO(ConfiguracionTarea entity)
            => !isNull(entity)
            ? new TaskConfigurationDTO
            {
                id = entity.id, 
                code = entity.codigo,
                name = entity.nombre,
                description = entity.descripcion,
                state = entity.estado,
                allowDocuments = entity.permitirDocs
            }
            : default;

        public static implicit operator ConfiguracionTarea(TaskConfigurationDTO model)
            => !isNull(model)
            ? new ConfiguracionTarea
            {
                codigo = model.code,
                nombre = model.name,
                descripcion = model.description,
                estado = model.state,
                permitirDocs = model.allowDocuments,
                create_at = DateTime.UtcNow
            }
            :default;



    }
}