using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using TMS_Services.Infraestructure.Interfaces;

namespace TMS_Services.Infraestructure.Repository
{
    public class CarrierMembershipRepository : Repository<Transportista_Afiliacion>, ICarrierMembershipRepository
    {
        private readonly IConnectionApiOdooRepository connectionApiOdooRepository;

        public CarrierMembershipRepository(DeltaDBEntities dbContext, IConnectionApiOdooRepository connectionApiOdooRepository) : base(dbContext)
        {

            this.connectionApiOdooRepository = connectionApiOdooRepository;

        }
    }
}