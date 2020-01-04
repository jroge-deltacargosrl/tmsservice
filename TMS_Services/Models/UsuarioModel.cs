using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Utils;
using TMS_Services.Models.Types;
using static TMS_Services.App_Utils.UtilsApiTms;
using XmlRpc;

namespace TMS_Services.Models
{
    public class UsuarioModel
    {
        public long id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public PersonalModel relationPersona { get; set; }
        public RolModel relationRol { get; set; }
        public CredencialApiModel relationCredentialsApi { get; set; }
        private ConexionXmlRpc conexionXmlRpc { get; set; } = new ConexionXmlRpc();


        public UsuarioModel() : this(default,string.Empty,string.Empty,default){}

        public UsuarioModel(UsuarioModel objCopy)
        {
            if (objCopy != null)
            {
                id = objCopy.id;
                userName = objCopy.userName;
                password = objCopy.password;
                relationPersona = new PersonalModel(objCopy.relationPersona);
                relationRol = new RolModel(objCopy.relationRol);
                relationCredentialsApi = new CredencialApiModel(objCopy.relationCredentialsApi);
            }
        }

        public bool aplicaCamposObligatorios() => !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password);

        public UsuarioModel(long id=default,string userName="admin",string password="admin", PersonalModel relationPersona = null, RolModel relationRol = null, CredencialApiModel relationCredentialsApi = null)
        {
            this.id = id;
            this.userName = userName;
            this.password = password;
            this.relationPersona = new PersonalModel(relationPersona);
            this.relationRol = new RolModel(relationRol);
            this.relationCredentialsApi = new CredencialApiModel(relationCredentialsApi);
        }

        
        /// <summary>
        /// Login de autenticacion de la API ODOO
        /// </summary>
        /// <returns></returns>
        public string logIn()
        {
            XmlRpcClient client = new XmlRpcClient();
            
            //client.Url = url;
            //client.Path = UtilsApiTms.PATH_XML_API;

            //XmlRpcRequest requestLogin = new XmlRpcRequest(UtilsApiTms.METHOD_AUTHENTICATE);

            //requestLogin.AddParams(database, userName, password, XmlRpcParameter.EmptyStruct());

            //XmlRpcResponse rps = client.Execute(requestLogin);

            client.WriteRequest(Console.Out);
            client.WriteResponse(Console.Out);

            //return !rps.IsFault() ? rps.GetString() : UtilsApiTms.LOGIN_FAILED; //""rps.GetFaultString();
            return "";
        }

        public long accessApiOdoo()
        {
            return 1;
        }

    }
}