using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS_Services.Models.DTO
{
    public class MetadataDTO
    {
        public long id { get; set; }
        public string tableCatalog { get; set; }
        public string tableSchema { get; set; }
        public string tableName { get; set; }
        public string tableType { get; set; }


    }
}