using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabyFace.Domain.Model.Models.Entities;
using BabyFace.Domain.Model.ViewModels.Email;

namespace BabyFace.Domain.Services.Contracts
{
    public interface IEmailConfigurationService
    {

        Task<string> PrepareEmailContent(EmailConfigurationViewModel emailconfig);
    }
}
