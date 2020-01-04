using CookComputing.XmlRpc;
using OdooRpcWrapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TMS_Services.DesignPatterns;
using TMS_Services.Models.DTO;
using TMS_Services.Models.ODOO_Conexion;

namespace TMS_Services.Models.DAL
{
    public class MetadataDAL
    {
        // credenciles static (modificar con el tiempo)
        private static OdooAPI odooAPI = new OdooAPI(new OdooConnectionCredentials("https://deltacargo-deltaz-567009.dev.odoo.com", "deltacargo-deltaz-567009", "deltacargomanuel2019@gmail.com", "delta011235813"));


        // patrones combinados (builder y singleton) 
        private static ConexionOdoo cnn = new ConexionOdooBuilder()
            .addUrl("https://deltacargo-deltaz-567009.dev.odoo.com")
            .addDbName("deltacargo-deltaz-567009")
            .addUserName("deltacargomanuel2019@gmail.com")
            .addPassword("delta011235813")
            .build();


        // method with library CData (Expired)
        public static List<MetadataDTO> getTablesOdoo()
        {
            List<MetadataDTO> metadatasResult = new List<MetadataDTO>();
            DataTable dt = cnn.executeReadDT();
            foreach (DataRow row in dt.Rows)
            {
                metadatasResult.Add(new MetadataDTO
                {
                    id = metadatasResult.Count + 1,
                    tableCatalog = row[0].ToString(),
                    tableSchema = row[1].ToString(),
                    tableName = row[2].ToString(),
                    tableType = row[3].ToString(),
                });
            }
            return metadatasResult;
        }

        public static MetadataDTO getTableOdoo(string nameTable)
        {
            DataTable dt = cnn.executeReadDT();
            foreach (DataRow row in dt.Rows)
            {
                string tableName = row[2].ToString().Trim();
                if (nameTable.Equals(tableName))
                {
                    return new MetadataDTO
                    {
                        id = 1,
                        tableCatalog = row[0].ToString(),
                        tableSchema = row[1].ToString(),
                        tableName = row[2].ToString(),
                        tableType = row[3].ToString(),
                    };
                }
            }
            return null;
        }



        public static XmlRpcStruct getModelOdoo(ModelFilterDTO modelOdoo)
        {
            List<string> fields = new List<string>();
            modelOdoo.fields.ForEach((kv) => fields.Add(kv.Key));
            return odooAPI.Fields_Get(modelOdoo.modelName, new object[] { }, fields.ToArray());
        }

    }
}