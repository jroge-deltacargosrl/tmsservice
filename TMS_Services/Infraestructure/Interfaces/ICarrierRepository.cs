using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Services.App_Data;
using TMS_Services.Models.DTO;

namespace TMS_Services.Infraestructure.Interfaces
{
    public interface ICarrierRepository : IRepository<Transportista> 
    {
        // agrega los metodos bases de la interfaz IRepository (CRUD) ademas de 
        // los descritos abajo
        //IEnumerable<TransportRouteDTO> addBusyRoutes(CarrierDTO carrier);
        


    }
}
