using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS_Services.Infraestructure.Metadata
{
    public class MetadataModel
    {
        public long id { get; set; }
        public string tableCatalog { get; set; }
        public string tableSchema { get; set; }
        public string tableName { get; set; }
        public string tableType { get; set; }


        public MetadataModel() : this(string.Empty, string.Empty, string.Empty, string.Empty) { }
        
        public MetadataModel(string tableCatalog, string tableSchema, string tableName, string tableType)
        {
            this.tableCatalog = tableCatalog;
            this.tableSchema = tableSchema;
            this.tableName = tableName;
            this.tableType = tableType;
        }


        
    }
}