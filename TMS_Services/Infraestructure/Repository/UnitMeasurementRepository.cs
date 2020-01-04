using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using TMS_Services.Infraestructure.Interfaces;
using TMS_Services.Models.DTO;

namespace TMS_Services.Infraestructure.Repository
{
    public class UnitMeasurementRepository : Repository<UnidadMedida>, IUnitMeasurementRepository
    {
        private readonly IConnectionApiOdooRepository connectionApiOdooRepository;

        public UnitMeasurementRepository(DeltaDBEntities dbContext, IConnectionApiOdooRepository connectionApiOdooRepository) : base(dbContext)
        {
            this.connectionApiOdooRepository = connectionApiOdooRepository;
        }


        // implementacion de los metodos adicionales
        public IEnumerable<UnidadMedida> getByType(int typeUmId)
        {
            return get(u => u.id_tipoUnidad == typeUmId);
            /*return dbContext.UnidadMedida
                .Where(u => u.id_tipoUnidad == idType);*/
        }


        public IEnumerable<UnitMeasurementDTO> getUnitsMeasurementFiltered(string filterName)
        {
            List<string> abbrevsAccept = new List<string>();
            switch (filterName)
            {
                case "storage_capacity":
                    abbrevsAccept.AddRange(new List<string>() { "m2", "m3" });
                    break;
                case "storage_time":
                    abbrevsAccept.AddRange(new List<string>() { "Semana(s)", "Mes(es)", "Año(s)" });
                    break;
                default:
                    break;
            }
            return get(um => abbrevsAccept.Contains(um.abreviatura))
                .ToList()
                .ConvertAll(u => (UnitMeasurementDTO)u);
        }

        /// <summary>
        /// Obtiene las unidades de medida disponilble para capacidad de almacenamiento
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UnidadMedida> getUnitMeasurementStorageCapacity()
        {
            // ver la forma de hacer dinamico esto de aqui
            List<string> abrevsAccept = null;
            return get(um => abrevsAccept.Contains(um.abreviatura));

            //return dbContext.UnidadMedida
                //.Where(u => abrevsAccpet.Contains(u.abreviatura));
        }

        /// <summary>
        /// Obtiene las unidaes de medida disponilble para tiempo de almacenamiento
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UnidadMedida> getUnitMeasurementStorageTime()
        {
            List<string> abrevsAccept = new List<string>()
            {
                "Semana(s)","Mes(es)","Año(s)"
            };
            return get(um => abrevsAccept.Contains(um.abreviatura));
        }

        
        // modificar los metodos de arriba, basandose en el esquema del patron template


    }
}