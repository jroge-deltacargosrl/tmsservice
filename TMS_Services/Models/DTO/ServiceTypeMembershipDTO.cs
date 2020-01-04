using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Models.DTO
{
    public class ServiceTypeMembershipDTO
    {
        public int serviceTypeId  { get; set; }
        public int companyId { get; set; }
        public int state { get; set; }
        //public ServiceTypeDTO s { get; set; }

        public static explicit operator ServiceTypeMembershipDTO(TipoServicio_Afiliacion entity)
            => !isNull(entity) 
            ? new ServiceTypeMembershipDTO
            {
                companyId = entity.id_afiliacion,
                serviceTypeId = entity.id_tipoServicio,
                state = entity.estado
                //s = (ServiceTypeDTO)entity.TipoServicio
            }
            : default;

        public static implicit operator TipoServicio_Afiliacion(ServiceTypeMembershipDTO model)
            => !isNull(model)
            ? new TipoServicio_Afiliacion
            {
                id_afiliacion = model.companyId,
                id_tipoServicio = model.serviceTypeId,
                estado = model.state,
                create_at = DateTime.Now
            }
            : default;



    }
}