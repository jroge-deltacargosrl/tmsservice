using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Models.DTO
{
    public class InformationFileDTO
    {
        public int idTask { get; set; }
        public int projectId { get; set; }
        public string format { get; set; }


        public static explicit operator InformationFileDTO(InfoArchivo entity)
            => !isNull(entity)
            ? new InformationFileDTO
            {
                idTask = entity.id_tarea,
                projectId = entity.id_proyecto,
                format = entity.extension
            }
            :default;
            
        public static implicit operator InfoArchivo(InformationFileDTO model)
            => !isNull(model)
            ? new InfoArchivo
            {
                id_tarea = model.idTask,
                id_proyecto = model.projectId,
                extension = model.format,
                create_at = DateTime.UtcNow
            }
            :default;
               



    }
}