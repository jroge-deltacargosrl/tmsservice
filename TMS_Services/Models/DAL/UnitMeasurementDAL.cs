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
    public class UnitMeasurementDAL
    {

        private readonly IUnitMeasurementRepository unitMeasurementRepository;

        public UnitMeasurementDAL(IUnitMeasurementRepository unitMeasurementRepository)
        {
            this.unitMeasurementRepository = unitMeasurementRepository;
        }

        public IEnumerable<UnitMeasurementDTO> getAll(Expression<Func<UnidadMedida, bool>> filter = null, Func<IQueryable<UnidadMedida>, IOrderedQueryable<UnidadMedida>> orderBy = null)
        {
            return unitMeasurementRepository.get()
                .ToList()
                .ConvertAll(u => (UnitMeasurementDTO)u);
        }

        public UnitMeasurementDTO getById(int id)
        {
            return (UnitMeasurementDTO)unitMeasurementRepository.getById(id);
        }

        public UnitMeasurementDTO create(UnitMeasurementDTO model)
        {
            return (UnitMeasurementDTO)unitMeasurementRepository.create((UnidadMedida)model);
        }

        public UnitMeasurementDTO delete(int id)
        {
            return (UnitMeasurementDTO)unitMeasurementRepository.remove(id);
        }

        public IEnumerable<UnitMeasurementDTO> getByType(int idType)
        {
            return unitMeasurementRepository.getByType(idType)
                .ToList()
                .ConvertAll(u => (UnitMeasurementDTO)u);
        }

        // modificar para siguientes iteraciones
        // storage_capacity, storage_time => CONVERTIR EN UNA ENUMERACION
        public IEnumerable<UnitMeasurementDTO> getUnitsMeasurementFiltered(string filterName)
        {
            return unitMeasurementRepository.getUnitsMeasurementFiltered(filterName);
            /*IEnumerable<UnidadMedida> result = default;
            switch (nameFilter)
            {
                case "storage_capacity":
                    result = unitMeasurementRepository.getUnitMeasurementStorageCapacity();
                    break;
                case "storage_time":
                    result = unitMeasurementRepository.getUnitMeasurementStorageTime();
                    break;
                default:
                    break;
            }
            return result.ToList()
                .ConvertAll(u => (UnitMeasurementDTO)u);*/
        }


        /*public static List<UnitMeasurementDTO> getAll()
        {
            List<UnitMeasurementDTO> result = new List<UnitMeasurementDTO>();
            using (DeltaDBEntities db = new DeltaDBEntities())
            {
                db.UnidadMedida.ToList()
                    .ForEach(um => result.Add((UnitMeasurementDTO)um));
            }
            return result;
        }
        
        public static List<UnitMeasurementDTO> getByIdType(long idUnitMeasurementType)
        {
            List<UnitMeasurementDTO> result = new List<UnitMeasurementDTO>();
            using (DeltaDBEntities db = new DeltaDBEntities())
            {
                db.UnidadMedida
                    .Where( um => um.id_tipoUnidad == idUnitMeasurementType)
                    .ToList()
                    .ForEach(um => result.Add((UnitMeasurementDTO)um));
            }
            return result;
         }*/

    }



}