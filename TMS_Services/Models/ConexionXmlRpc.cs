using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Utils;
using TMS_Services.Models.Types;
using XmlRpc;

namespace TMS_Services.Models
{
    public class ConexionXmlRpc
    {
        
        private XmlRpcClient clientXmlRpc { get; set; }
        private XmlRpcRequest requestXmlRpc { get; set; }
        private XmlRpcResponse responseXmlRpc { get; set; }


        public ConexionXmlRpc() : this(new XmlRpcClient()) { }

        public ConexionXmlRpc(XmlRpcClient clientXmlRpc, XmlRpcRequest requestXmlRpc = null, XmlRpcResponse responseXmlRpc = null)  
        {
            this.clientXmlRpc = clientXmlRpc;
            this.requestXmlRpc = requestXmlRpc;
            this.responseXmlRpc = responseXmlRpc;
        }


        #region "Procesos de comunicacion con la API ODOO"
        public bool setUpConnectionData(Dictionary<string,object> dataConnection)
        {
            if (dataConnection.Count > 0)
            {
                string urlAccess = dataConnection[UtilsApiTms.KEY_URL].ToString();
                TIPO_RUTA_API path = dataConnection[UtilsApiTms.KEY_PATH].ToString().DehumanizeTo<TIPO_RUTA_API>();
                TIPO_METODO_API method = dataConnection[UtilsApiTms.KEY_METHOD].ToString().DehumanizeTo<TIPO_METODO_API>();
                string database = dataConnection[UtilsApiTms.KEY_DATABASE].ToString();
                string username = dataConnection[UtilsApiTms.KEY_USERNAME].ToString();
                string password = dataConnection[UtilsApiTms.KEY_PASSWORD].ToString();

                applyUrlAccess(urlAccess);
                applyPath(path);
                applyMethod(method);
                applyAccessCredentials(database, username, password);
            }
            return dataConnection.Count > 0; 
        }


        private void applyUrlAccess(string urlAccess) => clientXmlRpc.Url = urlAccess;

        private void applyPath(TIPO_RUTA_API path) => clientXmlRpc.Path = path.Humanize();

        private void applyMethod(TIPO_METODO_API method) => requestXmlRpc = new XmlRpcRequest(method.Humanize());

        public void applyAccessCredentials(string database, string username, string pass) => addParameterAnyType(database, username, pass, XmlRpcParameter.EmptyStruct());

        public XmlRpcRequest addParameterAnyType(params object[] parameters) => requestXmlRpc.AddParams(parameters);
        public XmlRpcRequest addParameterStruct(KeyValuePair<string, object>[] keyValuePair) => requestXmlRpc.AddParamStruct(keyValuePair);

        /// <summary>
        /// Realiza la peticion con el protocolo XML-RPC asignando el objeto [responseXmlRpc] dados los parametros [requestXmlRpc]
        /// </summary>
        public void execute()
        {
            responseXmlRpc = clientXmlRpc.Execute(requestXmlRpc);
            clientXmlRpc.WriteRequest(Console.Out);
            clientXmlRpc.WriteResponse(Console.Out);
        }

        public bool success() => !responseXmlRpc.IsFault();

        public string responseData() => success() ?
            responseXmlRpc.GetString() :
            responseXmlRpc.GetFaultString();

        /// <summary>
        /// Realiza la peticion con el protocolo XML-RPC respondiendo el objeto resultante en formato XML
        /// encapsulado dentro de un string
        /// </summary>
        /// <returns></returns>
        public string executeWithResponse()
        {
            execute();
            return responseData();
        }


        #endregion


        public void example()
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
        }

    }
}