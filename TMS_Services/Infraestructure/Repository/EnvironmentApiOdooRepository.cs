using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using TMS_Services.Infraestructure.Interfaces;

namespace TMS_Services.Infraestructure.Repository
{
    public class EnvironmentApiOdooRepository : Repository<EntornoAPI>, IEnvironmentApiOdooRepository
    {
        public EnvironmentApiOdooRepository(DeltaDBEntities dbContext) : base(dbContext)
        {

        }
    }
}