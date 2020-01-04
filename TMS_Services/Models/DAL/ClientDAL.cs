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
    public class ClientDAL
    {
        private readonly IClientRepository clientRepository;

        public ClientDAL(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public IEnumerable<ClientDTO> getAll(Expression<Func<Cliente, bool>> filter = null, Func<IQueryable<Cliente>, IOrderedQueryable<Cliente>> orderBy = null)
        {
            return clientRepository.get(filter, orderBy)
                .ToList()
                .ConvertAll(c => (ClientDTO)c);
        }

        public ClientDTO getById(int id)
        {
            return (ClientDTO)clientRepository.getById(id);
        }


        public ClientDTO create(ClientDTO model)
        {
            return (ClientDTO)clientRepository.create(model);
           
        }

        public ClientDTO remove(int id)
        {
            return (ClientDTO)clientRepository.remove(id);
        }
    }
}