using System;

namespace TMS_Services.Models.DTO
{
    public class TaskDTO
    {
        public int id { get; set; }
        public string kanbanState { get; set; }
        public string name { get; set; }
        public DateTime date_start { get; set; }
        public int projectId { get; set; }
        // adecuacion parcial: 
        public int stageId { get; set; }

        // properties for document ( Tabla Configuracion_Tarea)
        public bool canUpload { get; set; }
        
        public bool uploaded { get; set; }

        public string format { get; set; }

    }
}