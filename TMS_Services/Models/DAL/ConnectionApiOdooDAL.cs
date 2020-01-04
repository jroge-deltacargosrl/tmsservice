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
    public class ConnectionApiOdooDAL
    {

        private readonly IConnectionApiOdooRepository connectionApiOdooRepository;

        public ConnectionApiOdooDAL(IConnectionApiOdooRepository connectionApiOdooRepository)
        {
            this.connectionApiOdooRepository = connectionApiOdooRepository;
        }

        public IEnumerable<ConnectionApiOdooDTO> getAll(Expression<Func<ConfiguracionAPI,bool>> filter = null, Func<IQueryable<ConfiguracionAPI>,IOrderedQueryable<ConfiguracionAPI>> orderBy = null)
        {
            return connectionApiOdooRepository.get(filter, orderBy)
                .ToList()
                .ConvertAll(c => (ConnectionApiOdooDTO)c);
        }

        public ConnectionApiOdooDTO getById(int id)
        {
            return (ConnectionApiOdooDTO)connectionApiOdooRepository.getById(id);
        }
        
        public ConnectionApiOdooDTO create(ConnectionApiOdooDTO model)
        {
            return (ConnectionApiOdooDTO)connectionApiOdooRepository.create(model);
        }

        public ConnectionApiOdooDTO edit(ConnectionApiOdooDTO model)
        {
            return (ConnectionApiOdooDTO)connectionApiOdooRepository.edit(model);
        }

        public ConnectionApiOdooDTO remove(int id)
        {
            return (ConnectionApiOdooDTO)connectionApiOdooRepository.remove(id);
        }

        public IEnumerable<ConnectionApiOdooDTO> removeAll()
        {
            return connectionApiOdooRepository.removeAll()
                .ToList()
                .ConvertAll(c => (ConnectionApiOdooDTO)c);
        }

        public ConnectionApiOdooDTO updateConnectionDefault(int connectionApiOdooId)
        {
            return connectionApiOdooRepository.updateConnectionDefault(connectionApiOdooId);
        }
    }
}