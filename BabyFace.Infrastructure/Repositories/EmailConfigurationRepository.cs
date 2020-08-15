using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabyFace.Domain.Model.Models.Entities;
using BabyFace.Domain.Repositories;
using BabyFace.Domain.UnitOfWork;

namespace BabyFace.Infrastructure.Repositories
{
    public class EmailConfigurationRepository : Repository<EmailConfiguration>, IEmailConfigurationRepository
    {

        public EmailConfigurationRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
