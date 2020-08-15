using BabyFace.Domain.Model.Models.Entities;
using BabyFace.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabyFace.Domain.UnitOfWork;

namespace BabyFace.Infrastructure.Repositories
{
    public class EnvironmentResourceRepository : Repository<EnvironmentResource>, IEnvironmentResourceRepository
    {
        public EnvironmentResourceRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
