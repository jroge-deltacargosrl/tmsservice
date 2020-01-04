using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using static TMS_Services.App_Utils.UtilsApiTms;


namespace TMS_Services.Models.DTO
{
    public class QuotationDTO
    {
        #region "Fields Database DeltaDB"
        public int id { get; set; }
        // cotizacion relacionado con datos de un cliente (nuevo/antiguo)
        //public ContactDTO contact { get; set; }
        public int idContact { get; set; }
        //public ServiceTypeDTO serviceType { get; set;}
        public int idServiceType { get; set; }

        // st : transporte (internacional/nacional)
        //public RouteDTO macroRouteOrigin { get; set; }
        public int? idMacroRouteOrigin { get; set; }
        public string routeCityOrigin { get; set; }  // no habilitadas para st: transporte nacional
        //public RouteDTO macroRouteDestination { get; set; }
        public int? idMacroRouteDestination { get; set; }
        public string routeCityDestination { get; set; } // no habilitada para st: transporte nacional
        //public TruckTypeDTO truckType { get; set; } // no habilitadas para clientes no registradas
        public int? idTruckType { get; set; }
        // para todos st (Excepto el almacenamiento de carga)
        public decimal? loadWeight { get; set; }
        //public UnitMeasurementDTO umLoadWeight { get; set; }
        public int? idUmLoadWeight { get; set; }
        public decimal? loadVolume { get; set; }
        //public UnitMeasurementDTO umLoadVolume { get; set; }
        public int? idUmLoadVolume { get; set; }
        public bool? imo { get; set; } // solo para cotizaciones de clientes antiguos

        // st: almacen de carga
        public decimal? storageCapacity { get; set; }
        //public UnitMeasurementDTO umStorageCapacity { get; set; }
        public int? idUmStorageCapacity { get; set; }

        public decimal? storageTime { get; set; }
        //public UnitMeasurementDTO umStorageTime { get; set; }
        public int? idUmStorageTime { get; set; }

        // para todos los tipos de servicio
        public string comment { get; set; }

        // relacion a la tabla afiliacion
        public int? id_membership { get; set; }

        #endregion
        #region "Fields Model Crm.Leads"
        public string name { get; set; }
        public string company_name { get; set; }
        public string email_from { get; set; }
        public string phone { get; set; }
        // city and country reusability of previus model
        public string street { get; set; }
        public string kanban_state { get; set; }
        public string type { get; set; }
        public string description { get; set; } // internal_notes
        #endregion

        public static explicit operator QuotationDTO(SolicitudCotizacion entity)
            => !isNull(entity) ?new QuotationDTO
            {
                id = entity.id,
                idContact = entity.id_cliente,
                idServiceType = entity.id_servicio,
                idMacroRouteOrigin = entity.id_rutaOrigen,
                routeCityOrigin = entity.ciudadOrigen,
                idMacroRouteDestination = entity.id_rutaDestino,
                routeCityDestination = entity.ciudadDestino,
                idTruckType = entity.id_tipoCamion,
                loadWeight = entity.pesoCarga,
                idUmLoadWeight = entity.id_unidadPeso,
                loadVolume =  entity.volumenCarga,
                idUmLoadVolume = entity.id_unidadVolumen,
                imo = entity.imoCarga,
                storageCapacity = entity.capacidadAlmacenamiento,
                idUmStorageCapacity = entity.id_unidadCapacidad,
                storageTime = entity.tiempoAlmacenamiento,
                idUmStorageTime = entity.id_unidadTiempo,
                comment = entity.comentarios,
                id_membership = entity.id_afiliacion
            }: default;

        public static implicit operator SolicitudCotizacion(QuotationDTO model)
            => !isNull(model) ? new SolicitudCotizacion
            {
                id_cliente = model.idContact,
                id_servicio = model.idServiceType,
                id_rutaOrigen = model.idMacroRouteOrigin,
                ciudadOrigen = model.routeCityOrigin,
                id_rutaDestino = model.idMacroRouteDestination,
                ciudadDestino = model.routeCityDestination,
                id_tipoCamion = model.idTruckType,
                pesoCarga = model.loadWeight,
                id_unidadPeso = model.idUmLoadWeight,
                volumenCarga = model.loadVolume,
                id_unidadVolumen = model.idUmLoadVolume,
                imoCarga = model.imo,
                capacidadAlmacenamiento = model.storageCapacity,
                id_unidadCapacidad = model.idUmStorageCapacity,
                tiempoAlmacenamiento = model.storageTime,
                id_unidadTiempo = model.idUmStorageTime,
                comentarios = model.comment,
                id_afiliacion = model.id_membership,
                create_at = DateTime.UtcNow
            }: default;
    }
}