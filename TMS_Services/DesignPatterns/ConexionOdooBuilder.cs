using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.Models.DTO;
using TMS_Services.Models.ODOO_Conexion;
using static TMS_Services.App_Utils.UtilsApiTms;


namespace TMS_Services.DesignPatterns
{
    public class ConexionOdooBuilder
    {
        private ConexionOdoo instanceCnn { get; set; }
        private CredentialsDTO credentials { get; set; }

        public ConexionOdooBuilder addCredentials(CredentialsDTO obj)
        {
            credentials = new CredentialsDTO
            {
                url = obj.url,
                dbName = obj.dbName,
                userName = obj.userName,
                password = obj.password
            };
            return this;
        }

        public ConexionOdooBuilder addUrl(string url)
        {
            if (isNull(credentials))
            {
                credentials = new CredentialsDTO();
            }
            credentials.url = url;
            return this;
        }

        public ConexionOdooBuilder addDbName(string dbName)
        {
            if (isNull(credentials))
            {
                credentials = new CredentialsDTO();  
            } 
            credentials.dbName = dbName;
            return this;
        }

        public ConexionOdooBuilder addUserName(string userName)
        {
            if (isNull(credentials))
            {
                credentials = new CredentialsDTO();
            }
            credentials.userName = userName;
            return this;
        }

        public ConexionOdooBuilder addPassword(string password)
        {
            if (!isNull(credentials))
            {
                credentials.password = password;
            }
            return this;
        }


        public ConexionOdoo build()
        {
            if (!isNull(instanceCnn))
            {
                return instanceCnn;
            }
            if (isNull(credentials))
            {
                return null;
            }
            if (isNull(ConexionOdoo.cnn))
            {
                ConexionOdoo.cnn = new ConexionOdoo(credentials);
                instanceCnn = ConexionOdoo.Instance;
            }
            return instanceCnn;
        }




        
    }
}