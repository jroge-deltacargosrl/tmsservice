namespace TMS_Services.Models.DTO
{
    public class FileDTO
    {
        public int idTask { get; set; } // Id de Odoo
        //public int idStage { get; set; }
        public int idProject { get; set; }
        public string documentName { get; set; }
        public string documentContent { get; set; }
        // Extension documento
        public string format { get; set; }

    }
}
