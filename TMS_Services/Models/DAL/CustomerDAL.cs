using CookComputing.XmlRpc;
using OdooRpcWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using TMS_Services.DesignPatterns;
using TMS_Services.Models.DTO;
using TMS_Services.Models.ODOO_Conexion;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Models.DAL
{
    // implementar una clase generica sobre esta entidad
    public class CustomerDAL
    {

        private static OdooAPI odooApi = new OdooAPI(new OdooConnectionCredentials(
            "https://deltacargo-deltaqa-646890.dev.odoo.com",
            "deltacargo-deltaqa-646890",
            "deltacargomanuel2019@gmail.com",
            "delta011235813")
            );

        /*private static ConexionOdoo cnn = new ConexionOdooBuilder()
            .addUrl("https://deltacargo-deltaw-515413.dev.odoo.com")
            .addDbName("deltacargo-deltaw-515413")
            .addUserName("deltacargomanuel2019@gmail.com")
            .addPassword("delta011235813")
            .build();*/

        public static UserResponseDTO logIn(UserDTO request)
        {
            UserResponseDTO result = new UserResponseDTO()
            {
                id = -1,
                email = "",
                responseType = 1
            };
            using (DeltaDBEntities db = new DeltaDBEntities())
            {
                var userWithEmailResults = (from userTbl in db.usuario
                                           where userTbl.correo == request.email && userTbl.tipo_c == 1
                                           select userTbl).ToList();
                if (userWithEmailResults.Count>0)
                {
                    result.email = userWithEmailResults.FirstOrDefault().correo;
                    var userCompleteResult = userWithEmailResults.FirstOrDefault((usr) => usr.password == request.password);
                    if (!isNull(userCompleteResult))
                    {
                        result.id = userCompleteResult.id;
                        result.responseType = 3;
                    }
                    else
                    {
                        result.responseType = 2;
                    }
                }
            }
            return result;
        }

        // metodod pendiente de implementacion
        public static List<ContactDTO> getPasswords()
        {
            int[] idPass = odooApi.Search("res.users", new object[] { });
            List<XmlRpcStruct> passTuples = odooApi.Read("res.users", idPass, new object[] { }).ToList().Cast<XmlRpcStruct>().ToList();

            // listar las contraseñas de los usuarios
            List<ContactDTO> changePassResult = new List<ContactDTO>();

            passTuples.ForEach(
                (pass) =>
                {
                    int passId = (int)pass["id"];


                }

                );
            return changePassResult;
        }


    }
}