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
    public class MembershipDAL
    {
        private readonly IMembershipRepository membershipRepository;
        public MembershipDAL(IMembershipRepository membershipRepository)
        {
            this.membershipRepository = membershipRepository;
        }

        // includes no utilizado
        public IEnumerable<MembershipDTO> getAll(Expression<Func<Afiliacion, bool>> filter = null, Func<IQueryable<Afiliacion>, IOrderedQueryable<Afiliacion>> orderBy = null)
        {
            return membershipRepository.get(filter,orderBy)
                .ToList()
                .ConvertAll(a => (MembershipDTO)a);
        }

        public MembershipDTO getById(int id)
        {
            return (MembershipDTO)membershipRepository.getById(id);
        }


        public MembershipDTO create(MembershipDTO model)
        {
            return (MembershipDTO)membershipRepository.create(model);
        }

        public MembershipDTO update(MembershipDTO model)
        {
            return (MembershipDTO)membershipRepository.edit(model);
        }

        public MembershipDTO delete(int id)
        {
            return (MembershipDTO)membershipRepository.remove(id);
        }

        public IEnumerable<MembershipDTO> deleteAll()
        {
            return membershipRepository.removeAll()
                .ToList()
                .ConvertAll(a => (MembershipDTO)a);
        }

        
        

    }
}