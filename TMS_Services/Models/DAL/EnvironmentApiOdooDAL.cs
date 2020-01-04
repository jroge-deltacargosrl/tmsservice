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
    public class EnvironmentApiOdooDAL
    {
        private readonly IEnvironmentApiOdooRepository environmentApiOdooRepository;

        public EnvironmentApiOdooDAL(IEnvironmentApiOdooRepository environmentApiOdooRepository)
        {
            this.environmentApiOdooRepository = environmentApiOdooRepository;
        }

        public IEnumerable<EnvironmentApiOdooDTO> getAll(Expression<Func<EntornoAPI, bool>> filter = null, Func<IQueryable<EntornoAPI>, IOrderedQueryable<EntornoAPI>> orderBy = null)
        {
            return environmentApiOdooRepository.get(filter, orderBy)
                .ToList()
                .ConvertAll(e => (EnvironmentApiOdooDTO)e);
        }

        public EnvironmentApiOdooDTO getById(int id)
        {
            return (EnvironmentApiOdooDTO)environmentApiOdooRepository.getById(id);
        }

        public EnvironmentApiOdooDTO create(EnvironmentApiOdooDTO model)
        {
            return (EnvironmentApiOdooDTO)environmentApiOdooRepository.create(model);
        }

        public EnvironmentApiOdooDTO edit(EnvironmentApiOdooDTO model)
        {
            return (EnvironmentApiOdooDTO)environmentApiOdooRepository.edit(model);
        }

        public EnvironmentApiOdooDTO remove(int id)
        {
            return (EnvironmentApiOdooDTO)environmentApiOdooRepository.remove(id);
        }
    }
}