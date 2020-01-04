using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Utils;
using TMS_Services.Models.Types;
using TMS_Services.App_Data;
using static TMS_Services.App_Utils.UtilsApiTms;
using Humanizer;

namespace TMS_Services.Models
{
    public class CredencialApiModel
    {
        public string url { get; set; }
        public string database { get; set; }
        // datos ingresados por el usuario para la verificacion de la API
        public string userName { get; set; }
        public string password { get; set; }
        public TipoCredencialModel relationTipoCredencial { get; set; }


        private ConexionXmlRpc conexionXmlRpc { get; set; } = new ConexionXmlRpc();
        public CredencialApiModel() : this(string.Empty, string.Empty) { }


        public CredencialApiModel(string url, string database, string userName = "admin", string password = "admin",TipoCredencialModel tipoCredencialModel = null)
        {
            this.url = url;
            this.database = database;
            this.userName = userName;
            this.password = password;
            this.relationTipoCredencial = tipoCredencialModel;
        }

        public CredencialApiModel(CredencialApiModel objCopy)
        {
            if (objCopy != null)
            {
                url = objCopy.url;
                database = objCopy.database;
                userName = objCopy.userName;
                password = objCopy.password;
            }
        }

        public bool applyRequeridFields() => !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password) && !isNull(relationTipoCredencial);

        /// <summary>
        /// Obtiene las credenciales en caso de existir
        /// </summary>
        /// <returns></returns>
        public CredencialApiModel read(long idTipoCredencial)
        {
            CredencialApiModel credencialOut = null;
            using (TMS_DBEntities db = new TMS_DBEntities())
            {
                var result = db.sp_accesoApiOdoo(userName, password, (int)idTipoCredencial).FirstOrDefault();
                if (result != null)
                {
                    credencialOut = new CredencialApiModel
                    {
                        userName = result.username.Trim(),
                        password = result.pass.Trim(),
                        url = result.urlAcceso.Trim(),
                        database = result.dbNombre.Trim()
                    };
                }
                return credencialOut;
            }
        }

        // CONSIDERAR RETORNAR UN OBJETO QUE CONTENGA UNA RESPUESTA ABSURDA 
        // PARA EL LOGIN O PARA CUALQUIER OTRO TIPO DE PETICION


        /// <summary>
        /// Retorna el ID del usuario con permisos para acceder a la API
        /// </summary>
        /// <returns></returns>
        public long accessApi()
        {
            CredencialApiModel credencialAccess = read(relationTipoCredencial.id);
            Dictionary<string, object> mapAccess = new Dictionary<string, object>();
            long idUserOdoo = default;
            if (!isNull(credencialAccess))
            {
                conexionXmlRpc.setUpConnectionData(credencialAccess.assignCredential());
                conexionXmlRpc.execute();
                if (conexionXmlRpc.success())
                {
                    idUserOdoo = long.Parse(conexionXmlRpc.responseData());
                }
            }
            return idUserOdoo;
        }

        /// <summary>
        /// Asigna un Diccionario de datos para almacenar las credenciales en funcion al objeto recien asignado
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> assignCredential()
        {
            Dictionary<string, object> credentialsData = new Dictionary<string, object>();
            if (!isNull(this))
            {
                credentialsData = new Dictionary<string, object>()
                {
                    { KEY_PATH, TIPO_RUTA_API.ACCESO.Humanize() },
                    { KEY_METHOD, TIPO_METODO_API.AUTENTICACION.Humanize() },
                    {KEY_URL, url },
                    { KEY_DATABASE, database},
                    { KEY_USERNAME, userName },
                    { KEY_PASSWORD, password}
                };
            }
            return credentialsData;
        }


    }

}