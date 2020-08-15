using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabyFace.Domain.Model.Models.Entities;

namespace BabyFace.Domain.Services.Contracts
{
    public interface IEmailActionService
    {
        Task<EmailAction> GetByName(string name);

    }
}
