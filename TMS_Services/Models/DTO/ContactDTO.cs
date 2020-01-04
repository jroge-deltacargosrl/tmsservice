using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS_Services.Models.DTO
{
    public class ContactDTO
    {
        // Modelo para llevar control de los datos de contactos
        // del ERP
        public int id { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public string email { get; set; }
        public bool isCustomer { get; set; }
        public string phone { get; set; }
        public string image {get;set;} // no utilizado
        public string street { get; set; }
        // propieda adicional para saber donde se esta registrando el usuario
        public int id_membership { get; set; }


    }
}