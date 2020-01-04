using CookComputing.XmlRpc;
using OdooRpcWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using TMS_Services.App_Utils;
using TMS_Services.Infraestructure.Interfaces;
using TMS_Services.Models.DAL;
using TMS_Services.Models.DTO;
using TMS_Services.Models.ODOO_Conexion;
using TMS_Services.Models.ViewModels;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Infraestructure.Repository
{
    public class UserRepository : Repository<usuario>, IUserRepository
    {
        private readonly IConnectionApiOdooRepository connectionApiOdooRepository;

        private readonly OdooAPI odooApi; // not dependency injection
        private readonly MailServiceDAL mailServiceDAL;


        public UserRepository(DeltaDBEntities dbContext, IConnectionApiOdooRepository connectionApiOdooRepository, MailServiceDAL mailServiceDAL) : base(dbContext)
        {
            this.connectionApiOdooRepository = connectionApiOdooRepository;
            this.mailServiceDAL = mailServiceDAL;

            // 1: Desarrollo, 2 Produccion
            var modelApiOdoo = connectionApiOdooRepository.getConnectionCurrentApiOdoo();
            odooApi = getConnectionDefault(modelApiOdoo);
        }

       

        public IEnumerable<ContactDTO> getAllContactsErp()
        {
            List<ContactDTO> contactResult = new List<ContactDTO>();
            // contactos de Odoo
            int[] idsUsers = odooApi.Search("res.users", new object[] { });
            List<XmlRpcStruct> usersTuples = odooApi.Read("res.users", idsUsers, new object[] { "id" })
                .ToList()
                .Cast<XmlRpcStruct>()
                .ToList();

            // REALIZAR EL CRUZE DE TABLAS
            List<int> idContacts = new List<int>();
            foreach (var idUser in idsUsers.ToList())
            {
                idContacts.AddRange((odooApi.Search("res.partner", new object[] {
                    new object[]{ "user_ids", "=", idUser }
                })).ToList());
            }
            List<XmlRpcStruct> contactsTuples = odooApi.Read("res.partner", idContacts.ToArray(), new object[] { "id", "name", "email", "display_name", "phone", "street", "customer", "supplier", "employee" })
                .ToList()
                .Cast<XmlRpcStruct>()
                .ToList();

            contactsTuples.ForEach(
                (contact) =>
                {
                    var contactModel = new ContactDTO
                    {
                        id = (int)contact["id"],
                        displayName = (string)contact["display_name"],
                        email = (string)contact["email"],
                        name = (string)contact["name"],
                        phone = !(contact["phone"]).Equals(false) ? (string)contact["phone"] : string.Empty,
                        //isCustomer = (bool)contact["is_customer"],
                        street = !(contact["street"]).Equals(false) ? (string)contact["street"] : string.Empty,
                        id_membership = 1 // Afiliacion Delta Cargo SRL
                    };
                    contactResult.Add(contactModel);
                });
            return contactResult;

        }

        public UserResponseDTO logIn(UserDTO userModel)
        {
            UserResponseDTO result = new UserResponseDTO()
            {
                id = -1,
                email = string.Empty,
                responseType = 1
            };

            var userWithEmailResult = dbContext.usuario.FirstOrDefault(u => u.correo == userModel.email && ((userModel.typeAccess == 1 ? u.tipo_c == 1 : userModel.typeAccess == 2 ? u.tipo_e == 1 : u.tipo_s == 1)));

            if (!isNull(userWithEmailResult))
            {
                if (userModel.typeAccess == 1 || userModel.typeAccess == 3)
                {
                    result.email = userWithEmailResult.correo;
                }
                else // typeAcces = 2 (Portal TMS)
                {
                    // roles: super admin = 1, normal user = 2
                    result.email = userModel.email == "prejas@deltacargosrl.com" ? "1" : "2";
                }
                
                // arreglar
                bool userCompleteResult = userWithEmailResult.password == userModel.password;
                if (userCompleteResult)
                {
                    result.id = userWithEmailResult.id;
                    result.responseType = 3;
                }
                else
                {
                    result.responseType = 2;
                }
            }

            /*using (DeltaDBEntities db = new DeltaDBEntities())
            {
                var userWithEmailResults = (from userTbl in db.usuario
                                            where userTbl.correo == request.email && userTbl.tipo_c == 1
                                            select userTbl).ToList();
                if (userWithEmailResults.Count > 0)
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
            }*/
            return result;
        }

        public IEnumerable<ContactDTO> syncWithErp()
        {

            List<ContactDTO> contactResult = new List<ContactDTO>();
            // contactos de Odoo
            int[] idsUsers = odooApi.Search("res.users", new object[] { });
            List<XmlRpcStruct> usersTuples = odooApi.Read("res.users", idsUsers, new object[] { "id" })
                .ToList()
                .Cast<XmlRpcStruct>()
                .ToList();

            // REALIZAR EL CRUZE DE TABLAS
            List<int> idContacts = new List<int>();
            foreach (var idUser in idsUsers.ToList())
            {
                idContacts.AddRange((odooApi.Search("res.partner", new object[] {
                    new object[]{ "user_ids", "=", idUser }
                })).ToList());
            }
            List<XmlRpcStruct> contactsTuples = odooApi.Read("res.partner", idContacts.ToArray(), new object[] { "id", "name", "email", "display_name", "phone", "street", "customer", "supplier", "employee" })
                .ToList()
                .Cast<XmlRpcStruct>()
                .ToList();

            // usuarios de dbTMS
            contactsTuples.ForEach(
                    (contact) =>
                    {
                        // validacion provisional (email)
                        if (!contact["email"].Equals(false))
                        {
                            string emailContact = (string)contact["email"];
                            var countNoSync = get(u => u.correo == emailContact).Count();
                            if (countNoSync == 0) //no existe el usuario
                            {
                                // para el listado
                                var contactModel = new ContactDTO
                                {
                                    id = (int)contact["id"],
                                    displayName = (string)contact["display_name"],
                                    email = (string)contact["email"],
                                    name = (string)contact["name"],
                                    phone = !(contact["phone"]).Equals(false) ? (string)contact["phone"] : string.Empty,
                                    //isCustomer = (bool)contact["is_customer"],
                                    street = !(contact["street"]).Equals(false) ? (string)contact["street"] : string.Empty,
                                    id_membership = 1 // Afiliacion Delta Cargo SRL
                                };
                                contactResult.Add(contactModel);

                                // Para base de datos
                                var userModel = new UserDTO
                                {
                                    id = (int)contact["id"],
                                    email = emailContact,
                                    password = "delta123abc", // provisional
                                    clientType = !contact["customer"].Equals(false) ? (byte)1 : (byte)0,
                                    employeeType = !contact["employee"].Equals(false) ? (byte)1 : (byte)0,
                                    supplierType = !contact["supplier"].Equals(false) ? (byte)1 : (byte)0,
                                    id_membership = 1, // por default (delta cargo SRL)
                                };
                                create(userModel);
                            }
                        }
                    });
            return contactResult;

        }

        public UserDTO generateFirstPassword(int userId)
        {
            var userFind = getById(userId);
            if (!isNull(userFind) && userFind.enviar_password == 1)
            {
                userFind.password = RandomPassword.randomPassword(acceptToUpper: true);
                // enviar password
                userFind.enviar_password = 0; // inhabilitar envio de password
                var generatePassUserView = new GeneratePasswordUserViewDTO
                {
                    email = userFind.correo,
                    password = userFind.password,
                    url = URL_PORTAL_CLIENTES
                };
                var response = mailServiceDAL.sendMail(generatePassUserView);
                if (response.code == STATE_MAIL_OK)
                {
                    return (UserDTO)edit(userFind);
                }
            }
            return (UserDTO)userFind;

        }

        public UserDTO editPrivileges(UserDTO model)
        {
            usuario userForUpdate = getById(model.id); // obtener entidad de base de datos
            if (!isNull(userForUpdate))
            {
                userForUpdate.tipo_c = model.clientType;
                userForUpdate.tipo_s = model.supplierType;
                userForUpdate.tipo_e = model.employeeType;

                return (UserDTO)edit(userForUpdate);
            }
            return model;
        }
    }
}