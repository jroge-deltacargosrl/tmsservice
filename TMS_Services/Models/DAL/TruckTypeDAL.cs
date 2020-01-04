using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using TMS_Services.Infraestructure.Interfaces;
using TMS_Services.Models.DTO;

namespace TMS_Services.Models.DAL
{
    public class TruckTypeDAL
    {

        private readonly ITruckTypeRepository truckTypeRepository;

        public TruckTypeDAL(ITruckTypeRepository truckTypeRepository)
        {
            this.truckTypeRepository = truckTypeRepository;
        }

        public IEnumerable<TruckTypeDTO> getAll()
        {
            return truckTypeRepository.get()
                .ToList()
                .ConvertAll(t => (TruckTypeDTO)t);
        }

        public TruckTypeDTO getById(int id)
        {
            return (TruckTypeDTO)truckTypeRepository.getById(id);
        }

    }
}