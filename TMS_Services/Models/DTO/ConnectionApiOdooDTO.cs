using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using static TMS_Services.App_Utils.UtilsApiTms;


namespace TMS_Services.Models.DTO
{
    public class ConnectionApiOdooDTO
    {
        public int id { get; set; }
        public string urlApi { get; set; }
        public string nameDb { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int state { get; set; }
        public int id_environmentApi { get; set; }


        public static explicit operator ConnectionApiOdooDTO(ConfiguracionAPI entity)
            => !isNull(entity) 
            ? new ConnectionApiOdooDTO
            {
                id = entity.id,
                urlApi = entity.urlApi,
                nameDb = entity.nombreDb,
                email = entity.email,
                password = entity.pass,
                state = entity.estado,
                id_environmentApi = entity.id_entornoApi
            }
            :default;
        
        public static implicit operator ConfiguracionAPI(ConnectionApiOdooDTO model)
            => !isNull(model) 
            ? new ConfiguracionAPI
            {
                id = model.id,
                urlApi = model.urlApi,
                nombreDb = model.nameDb, 
                email = model.email,
                pass = model.password,
                estado = model.state,
                id_entornoApi = model.id_environmentApi,
                create_at = DateTime.Now
            }
            :default;


    }
}