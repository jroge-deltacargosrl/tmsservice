using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using TMS_Services.Infraestructure.Interfaces;
using TMS_Services.Models.DTO;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Infraestructure.Repository
{
    public class ConnectionApiOdooRepository : Repository<ConfiguracionAPI>, IConnectionApiOdooRepository
    {

        public ConnectionApiOdooRepository(DeltaDBEntities dbContext) : base(dbContext)
        {
        }

        public ConnectionApiOdooDTO getConnectionCurrentApiOdoo()
        {
            return (ConnectionApiOdooDTO)getFirstOrDefault(cnnApi => cnnApi.estado == 1); 
        }

        public ConnectionApiOdooDTO updateConnectionDefault(int connectionApiOdooId)
        {
            var cnnApiOdooResult = default(ConnectionApiOdooDTO);
            var cnnApiOdooDefault = getById(connectionApiOdooId);
            if (!isNull(cnnApiOdooDefault))
            {
                IEnumerable<ConfiguracionAPI> configuracionAPIs = get(filter: apiOdoo => apiOdoo.id != connectionApiOdooId);
                configuracionAPIs.ToList()
                    .ForEach(confApi => 
                    {
                        confApi.estado = 0;
                        edit(confApi);
                    });
                cnnApiOdooDefault.estado = 1;
                cnnApiOdooResult = (ConnectionApiOdooDTO)edit(cnnApiOdooDefault);
            }
            return cnnApiOdooResult;
        }

       
    }
}