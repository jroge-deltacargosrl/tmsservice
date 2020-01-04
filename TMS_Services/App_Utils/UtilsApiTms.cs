using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.Models;
using System.Data.CData.Odoo;
using System.Data;
using TMS_Services.Infraestructure.Metadata;
using TMS_Services.Models.DTO;
using System.Text;
using TMS_Services.Models.ViewModels;
using OdooRpcWrapper;

namespace TMS_Services.App_Utils
{
    public class UtilsApiTms
    {


        #region "Configuracion Envio Email"
        public const string EMAIL_EMISOR = "comercial@deltacargosrl.com";
        public const string HOST = "smtp.office365.com";
        public const int PUERTO = 587;
        public const bool HABILITAR_SSL = true;
        public const bool USAR_CREDENCIALES_DEFAULT = false;
        public const string USER = "comercial@deltacargosrl.com";
        public const string PASS = "1025565029Cdc.";
        public const int STATE_MAIL_OK = 200;

        public const string SUBJECT_GENERATE_PASSWORD = "Credenciales de Usuario al Portal Clientes - Delta Cargo SRL";

        public const string URL_PORTAL_CLIENTES = "https://deltacargosrl.azurewebsites.net/";


        public static string formatMessageForGenerateCredentialsUser(GeneratePasswordUserViewDTO model)
        {
            StringBuilder sb = new StringBuilder();
            string textTitle = "Bienvenido a la Plataforma Tecnológica de la Industria del Transporte mas grande de toda Bolívia : Portal Clientes Delta Cargo SRL";
            string textDescription = "Hemos recibido tu solicitud de afiliarte como cliente de la empresa, a continuación te mandamos tus <strong>credenciales de usuario</strong> por defecto, posteriomente podras cambiar tu contraseña";
            return sb.AppendLine("<html>")
                .AppendLine("<body>")
                .AppendLine($"<strong>{textTitle}</strong>")
                .AppendLine("</br>")
                .AppendLine(textDescription)
                .AppendLine("</br></br>")
                .AppendLine("<table border=\"1\">")
                .AppendLine(dataBody(model))
                .AppendLine("</table>")
                .AppendLine("</body>")
                .AppendLine("</html>")
                .ToString();
        }

        public static string dataBody(GeneratePasswordUserViewDTO model)
        {
            StringBuilder st = new StringBuilder();
            Dictionary<string, object> headerText = new Dictionary<string, object>()
            {
                ["Correo Electrónico"] = model.email,
                ["Contraseña"] = model.password,
                ["URL Portal Clientes"] = model.url
            };
            foreach (var item in headerText)
            {
                st.AppendLine("<tr>")
                    .AppendLine($"<td><strong>{item.Key}</strong></td>")
                    .AppendLine($"<td><i>{item.Value}</i></td>")
                    .AppendLine("</tr>");
            }
            return st.ToString();
        }
        #endregion  

        #region "Configuraciones de Conexion Inicial"

        public static readonly string KEY_URL = "KEY_URL";
        public static readonly string KEY_PATH = "KEY_PATH";
        public static readonly string KEY_METHOD = "KEY_METHOD";
        public static readonly string KEY_DATABASE = "KEY_DATABASE";
        public static readonly string KEY_USERNAME = "KEY_USERNAME";
        public static readonly string KEY_PASSWORD = "Password";


        #endregion
        /*public static readonly string PATH_XML_API = "common";
        public static readonly string METHOD_AUTHENTICATE = "authenticate";*/

        #region "Respuestas Autenticacion API ODOO"

        public static readonly string LOGIN_FAILED = "login failed";

        #endregion  

        #region "Configuraciones API REST"
        public const string API_PATH = "api";
        public const string API_VERSION = "v1";
        public const string FIELD_ID = "{id}";
        public const string ROOT = "";
        public const string GET_VIEW_MODELS = "dataRequired/" + "{companyId}";

        public const string FIELD_ID_BY_TYPE_ACCESS = "{typeAccess}/" + FIELD_ID;

        public const string FIELD_PROJECT_ID = "{projectId}";
        public const string FIELD_TASK_ID = "{taskId}";
        public const string FIELDS_PROJECT_TASK_IDS = FIELD_PROJECT_ID + "/" + FIELD_TASK_ID;
        public const string FIELD_STATE_TASK = "{stateTask}";

        public const string FIELD_COMPANY_ID = "company/{companyId}";
        public const string FIELD_SERVICE_TYPE_ID = "serviceType/{serviceTypeId}";

        public const string API_RELATIVE_PATH = API_PATH + "/" + API_VERSION;

        // ServiceTypecontroller
        public const string RESOURCE_SERVICE_TYPE_MEMBERSHIP = API_RELATIVE_PATH + "/serviceTypeCompany";

        // AccessClient
        public const string ACCESS_USER = "access";

        // Generate First Password for user
        public const string GENERATE_FIRST_PASSWORD_USER = "firstPassword/{userId}";

        // Update Privileges of User
        public const string UPDATE_PRIVILEGES_USER = "updatePrivileges";

        // Update Partial Task : Allow Documents and Display For Client
        public const string UPDATE_ALLOW_DOCS_AND_DISPLAY_FOR_CLIENT = "updateAllowDocsAndDisplayClient";


        // Update Default Connection API ODOO
        public const string FIELD_CONNECTION_API_ODOO_ID = "{connectionApiOdooId}";

        // MetadataController
        public const string GET_LIST_TABLE = API_RELATIVE_PATH + "/metadata/";
        public const string GET_TABLE = API_RELATIVE_PATH + "/metadata/{name}";
        public const string GET_MODEL = API_RELATIVE_PATH + "/model/";

        // OperationController
        public const string RESOURCE_OPERATION = API_RELATIVE_PATH + "/operation";
        //public const string GET_LIST_OPERATIONS = API_RELATIVE_PATH + "/operation";
        public const string GET_OPERATION_BY_CUSTOMER = API_RELATIVE_PATH + "/operation/{idClient}";
        //Para guardar el archivo subido. No se si estan bien estos nombres de constantes, atte: Jroge
        public const string POST_UPLOAD_FILE = "uploadFile";
        public const string POST_DELETE_FILE = "deleteFile";
        public const string GET_ALL_FILES = "getFiles";

        //ContactController
        public const string RESOURCE_CONTACT = API_RELATIVE_PATH + "/contact";
        public const string GET_CONTACT = API_RELATIVE_PATH + "/contact/{email}";
        public const string SYNC_CONTACT =  "sync";

        // CarrierController
        public const string RESOURCE_ROUTE = API_RELATIVE_PATH + "/route";
        public const string RESOURCE_ROUTE_BY_ID = API_RELATIVE_PATH + "/route/" + FIELD_ID;

        public const string RESOURCE_TRUCK_TYPE = API_RELATIVE_PATH + "/truck";
        public const string RESOURCE_TRUCK_TYPE_BY_ID = API_RELATIVE_PATH + "/truck/" + FIELD_ID;

        public const string RESOURCE_CARRIER = API_RELATIVE_PATH + "/carrier";
        public const string RESOURCE_CARRIER_BY_ID = API_RELATIVE_PATH + "/carrier/" + FIELD_ID;

        // UnitMeasurementController
        public const string RESOURCE_UNIT_MEASUREMENT = API_RELATIVE_PATH + "/unitMeasurement";
        public const string RESOURCE_UNIT_MEASUREMENT_BY_ID = API_RELATIVE_PATH + "/unitMeasurement/" + FIELD_ID;

        public const string FIELD_ID_BY_TYPE = "type/" + FIELD_ID;
        public const string FIELD_NAME_BY_TYPE = "type/" + FIELD_NAME;


        // UnitMeasurementTypeController
        public const string RESOURCE_UNIT_MEASUREMENT_TYPE = API_RELATIVE_PATH + "/unitMeasurementType";

        // QuotationController
        public const string RESOURCE_QUOTATION = API_RELATIVE_PATH + "/quotation";

        // ServiceTypeController
        public const string RESOURCE_SERVICE_TYPE = API_RELATIVE_PATH + "/service";
        public const string RESOURCE_SERVICE_TYPE_BY_ID = API_RELATIVE_PATH + "/service/" + FIELD_ID;

        public const string FIELD_COMPANY_NAME = "{companyName}";
        public const string FIELD_NAME = "{name}";
        
        // UserController
        public const string RESOURCE_USER = API_RELATIVE_PATH + "/user";

        // ClientController
        public const string RESOURCE_CLIENT = API_RELATIVE_PATH + "/client";

        // MembershipController
        public const string RESOURCE_MEMBERSHIP = API_RELATIVE_PATH + "/membership";

        // TaskConfigurationController
        public const string RESOURCE_TASK_CONFIGURATION = API_RELATIVE_PATH + "/taskConfiguration";

        // InformationFileController
        public const string RESOURCE_INFORMATION_FILE = API_RELATIVE_PATH + "/infoFile";


        // ConnectionApiOdooControlller
        public const string RESOURCE_CONNECTION_API_ODOO = API_RELATIVE_PATH + "/connectionApiOdoo";

        // EnvironmentApiOdooController
        public const string RESOURCE_ENVIRONMENT_API_ODOO = API_RELATIVE_PATH + "/environmentApiOdoo";

        #endregion

        #region "Metodos Utilitarios Genericos"
        public static bool isNull<T>(T obj) => obj == null;

        public static List<object[]> exampleCnxOdooADONET()
        {
            var odooConfigCnn = new OdooConnectionStringBuilder
            {
                URL = "https://deltacargo-deltaw-515413.dev.odoo.com",
                Database = "deltacargo-deltaw-515413",
                User = "deltacargomanuel2019@gmail.com",
                Password = "delta011235813"
            };

            OdooConnection cnn = null;
            try
            {
                cnn = new OdooConnection(odooConfigCnn);
                cnn.Open();
                OdooCommand cmd = new OdooCommand("SELECT id, name FROM res_partner", cnn);
                List<object[]> dataList = new List<object[]>();
                OdooDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataList.Add(new object[] { dr["id"], dr["name"], });
                }
                return dataList;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
        }

        // Metodo de obtener de datos 
        public static List<MetadataModel> getTablesOdoo()
        {
            // credenciales estaticas
            var odooConfigCnn = new OdooConnectionStringBuilder
            {
                URL = "https://deltacargo-deltaw-515413.dev.odoo.com",
                Database = "deltacargo-deltaw-515413",
                User = "deltacargomanuel2019@gmail.com",
                Password = "delta011235813"
            };

            //string cnnString = "URL = https://deltacargo-deltaw-515413.dev.odoo.com; User = deltacargomanuel2019@gmail.com; Password = delta011235813; Database = deltacargo-deltaw-515413;";
            OdooConnection cnn = null;
            try
            {
                cnn = new OdooConnection(odooConfigCnn);
                List<MetadataModel> dataList = new List<MetadataModel>();
                int index = 0;
                cnn.Open();
                DataTable dt = cnn.GetSchema("Tables");
                foreach (DataRow row in dt.Rows)
                {

                    var objMetaModelo = new MetadataModel
                    {
                        id = ++index,
                        tableCatalog = row[0].ToString(),
                        tableSchema = row[1].ToString(),
                        tableName = row[2].ToString(),
                        tableType = row[3].ToString(),
                    };
                    /*
                    List<Object> objCurrent = new List<object>() { ++index }; 
                    foreach (DataColumn col in dt.Columns)
                    {
                        objCurrent.Add(row[col]);
                    }*/
                    dataList.Add(objMetaModelo);
                }
                return dataList;
            }
            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                cnn.Clone();
            }
        }
        #endregion

        #region "Metodos de Composicion de datos para los modelos"
        public static string getDescriptionQuotationWithFormat(QuotationDetailsViewDTO quotationDetails)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("------------------------------ DETALLE DE OPERACION ------------------------------")
                .AppendLine($"Nombre Completo : {quotationDetails.name}")
                .AppendLine($"Empresa : {quotationDetails.company}")
                .AppendLine($"Celular : {quotationDetails.phone}")
                .AppendLine($"Correo Electrónico : {quotationDetails.email}")
                .AppendLine($"Tipo de Servicio : {quotationDetails.serviceType}");

            // falta el peso y volumen
            switch (quotationDetails.serviceType)
            {
                case "Transporte Urbano en SCZ":
                    //  sin campos especializados
                    break;
                case "Almacenamiento de Carga en SCZ":
                    sb.AppendLine($"Capacidad de Almacenamiento : {quotationDetails.storageCapacity}")
                        .AppendLine($"Tiempo de Almacenamiento : {quotationDetails.storageTime}");
                    break;
                case "Transporte Nacional":
                    sb.AppendLine($"Ciudad Origen : {quotationDetails.cityDestination}")
                        .AppendLine($"Ciudad Destino : {quotationDetails.cityDestination}");
                    break;
                case "Transporte Internacional":
                    sb.AppendLine($"Ruta Origen : {quotationDetails.countryOrigin}")
                        .AppendLine($"Ciudad Origen : {quotationDetails.cityOrigin}")
                        .AppendLine($"Ruta Destino : {quotationDetails.countryDestination}")
                        .AppendLine($"Ciudad Destino : {quotationDetails.cityDestination}");
                    break;
                case "Ruta Urbana SCZ":
                    sb.AppendLine($"Dirección : {quotationDetails.street}");
                    break;
                default:
                    break;
            }
            if (!quotationDetails.serviceType.Equals("Almacenamiento de Carga en SCZ"))
            {
                sb.AppendLine($"Peso : {quotationDetails.loadWeight} Tn.")
                    .AppendLine($"Volumen : {quotationDetails.loadVolume} m3");
            }
            sb.AppendLine($"Coméntanos : {quotationDetails.comment}")
                .Append("-------------------------------------------------------------------------");
            return sb.ToString();
        }
        #endregion

        #region "Metodos Conexion API ODOO"
        public static OdooAPI getConnectionDefault(ConnectionApiOdooDTO model)
        {
            OdooAPI odooApi = default;
            if (!isNull(model))
            {
                var credentials = new OdooConnectionCredentials(model.urlApi, model.nameDb, model.email, model.password);
                odooApi = new OdooAPI(credentials);
            }
            return odooApi;
        }
            
            
        

        #endregion

    }
}