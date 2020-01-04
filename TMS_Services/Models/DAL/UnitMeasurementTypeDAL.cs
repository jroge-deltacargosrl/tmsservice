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
    public class UnitMeasurementTypeDAL
    {

        private readonly IUnitMeasurementTypeRepository unitMeasurementTypeRepository;

        public UnitMeasurementTypeDAL(IUnitMeasurementTypeRepository IUnitMeasurementTypeRepository)
        {
            this.unitMeasurementTypeRepository = IUnitMeasurementTypeRepository;
        }

        public IEnumerable<UnitMeasurementTypeDTO> getAll(Expression<Func<TipoUnidadMedida, bool>> filter = null, Func<IQueryable<TipoUnidadMedida>, IOrderedQueryable<TipoUnidadMedida>> orderBy = null)
        {
            return unitMeasurementTypeRepository.get(filter, orderBy)
                .ToList()
                .ConvertAll(ut => (UnitMeasurementTypeDTO)ut);
        }

        public UnitMeasurementTypeDTO getById(int id)
        {
            return (UnitMeasurementTypeDTO)unitMeasurementTypeRepository.getById(id);
        }

        public UnitMeasurementTypeDTO create(UnitMeasurementTypeDTO model)
        {
            return (UnitMeasurementTypeDTO)unitMeasurementTypeRepository.create((TipoUnidadMedida)model);
        }

        public UnitMeasurementTypeDTO delete(int id)
        {
            return (UnitMeasurementTypeDTO)unitMeasurementTypeRepository.remove(id);
        }

        /*public static List<UnitMeasurementTypeDTO> getAll()
        {
            List<UnitMeasurementTypeDTO> result = new List<UnitMeasurementTypeDTO>();
            using (DeltaDBEntities db = new DeltaDBEntities())
            {
                db.TipoUnidadMedida.ToList()
                    .ForEach(um => result.Add((UnitMeasurementTypeDTO)um));
            }
            return result;
        }*/

    }
}