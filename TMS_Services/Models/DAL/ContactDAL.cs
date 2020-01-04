using CookComputing.XmlRpc;
using OdooRpcWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TMS_Services.App_Data;
using TMS_Services.Infraestructure.Interfaces;
using TMS_Services.Models.DTO;

namespace TMS_Services.Models.DAL
{
    public class ContactDAL 
    {

        /*private static OdooAPI odooApi = new OdooAPI(new OdooConnectionCredentials("https://deltacargo-deltaqa-646890.dev.odoo.com", "deltacargo-deltaqa-646890", "deltacargomanuel2019@gmail.com", "delta011235813"));*/

        private readonly IUserRepository userRepository;


        public ContactDAL(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<ContactDTO> getAllContactsErp()
        {
            return userRepository.getAllContactsErp();
        }

        public IEnumerable<ContactDTO> syncWithErp()
        {
            return userRepository.syncWithErp();
        }

        // metodos a implementar (version mejorada)


    }
}