using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Models.DTO
{
    public class CarrierDTO
    {

        public int id { get; set; }
        public long nroLicense { get; set; }
        public string fullname { get; set; }
        public string lastname { get; set; }
        public string company { get; set; }
        public string phone { get; set; }
        public int id_truckType { get; set; }
        // id de registro de afiliacion actual mediante la pagina web
        public string email{ get; set; } // modificacion reciente
        public int id_membership { get; set; }

        // campo para obtener las rutas marcadas por los choferes
        public List<RouteDTO> ids_Route { get; set; } = new List<RouteDTO>();


        public static explicit operator CarrierDTO(Transportista value)
        {
            CarrierDTO result = default;
            if (!isNull(value))
            {
                result = new CarrierDTO
                {
                    id = value.id,
                    nroLicense = value.nroLicencia,
                    fullname = value.nombres,
                    lastname = value.apellidos,
                    company = value.empresa,
                    phone = value.celular,
                    email = value.correoElectronico,
                    id_truckType = value.id_tipoCamion
                };
                value.Transportista_Ruta
                    .ToList()
                    .ForEach(t => result.ids_Route.Add((RouteDTO)t.Ruta));
            }
            return result;
        }


        public static explicit operator Transportista(CarrierDTO model)
        {
            Transportista entityDb = default;
            if (!isNull(model))
            {
                entityDb = new Transportista
                {
                    nroLicencia = model.nroLicense,
                    nombres = model.fullname,
                    apellidos = model.lastname,
                    empresa = model.company,
                    celular = model.phone,
                    correoElectronico = model.email,
                    id_tipoCamion = model.id_truckType,
                    create_at = DateTime.UtcNow// analizar luego
                };
            }
            return entityDb;
        }
          
    }
}