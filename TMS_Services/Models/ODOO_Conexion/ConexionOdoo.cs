using System;
using System.Collections.Generic;
using System.Data;
using System.Data.CData.Odoo;
using System.Linq;
using System.Web;
using TMS_Services.Models.DTO;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Models.ODOO_Conexion
{
    public class ConexionOdoo
    {
        private static OdooConnection odooConnection;
        public static ConexionOdoo cnn { get; set; } = null;
        private static readonly object padLook = new object();

        public static ConexionOdoo Instance
        {
            get
            {
                lock (padLook)
                {
                    if (isNull(cnn))
                    {
                        cnn = new ConexionOdoo();
                        //odooConnection = new OdooConnection(configConnection())
                    }
                    return cnn;
                }
            }
        }

        public ConexionOdoo() { }

        public void initConfig(string url, string dbName, string userName, string password)
        {
            OdooConnectionStringBuilder config = new OdooConnectionStringBuilder()
            {
                URL = url,
                Database = dbName,
                User = userName,
                Password = password
            };
            odooConnection = new OdooConnection(config);
        }


        /*private  OdooConnectionStringBuilder configConnection()
        {

            return isNull(credentials) 
                ? new OdooConnectionStringBuilder
                {
                    /*URL = "https://deltacargo-deltaw-515413.dev.odoo.com",
                    Database = "deltacargo-deltaw-515413",
                    User = "deltacargomanuel2019@gmail.com",
                    Password = "delta011235813"
                    URL =credentials.url,
                    Database = credentials.dbName,
                    User = credentials.userName,
                    Password = credentials.password
                } 
                :null;
        }*/

        public ConexionOdoo(CredentialsDTO cred) 
            => initConfig(cred.url, cred.dbName, cred.userName, cred.password);
        


        public bool open()
        {
            try
            {
                if (!isOpen())
                {
                    odooConnection.Open();
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Dictionary<string, List<object>> executeRead(string query)
        {
            try
            {
                open();
                OdooCommand cmd = new OdooCommand(query, odooConnection);
                OdooDataReader dr = cmd.ExecuteReader();
                Dictionary<string, List<object>> rows = new Dictionary<string, List<object>>();

                List<string> columnName = Enumerable.Range(0, dr.FieldCount).Select(dr.GetName).ToList();
                columnName
                    .ForEach(
                        colName => rows[colName] = new List<object>()
                    );

                while (dr.Read())
                {
                    columnName.ForEach(col => rows[col].Add(dr[col]));
                }
                return rows;
            }
            catch (Exception e)
            {
                return new Dictionary<string, List<object>>()
                {
                    { "ERROR" , new List<object>(){e.Message.ToString()} }
                };
            }
            finally
            {
                close();
            }

        }

        public DataTable executeReadDT()
        {
            try
            {
                open();
                return odooConnection.GetSchema("Tables");
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                close();
            }
        }


        public bool isOpen() => odooConnection.State == System.Data.ConnectionState.Open;
        private void close()
        {
            if (!isOpen())
            {
                open();
            }
        }




    }
}