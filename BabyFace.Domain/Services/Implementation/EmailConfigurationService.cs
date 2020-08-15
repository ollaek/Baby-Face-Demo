using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using BabyFace.Domain.Model.Models.Entities;
using BabyFace.Domain.Repositories;
using BabyFace.Domain.Services.Contracts;

using System.IO;

using BabyFace.Domain.Model.ViewModels.Email;
using BabyFace.Domain.Model.Helpers;
using System.Web.Hosting;

namespace BabyFace.Domain.Services.Implementation
{
    public class EmailConfigurationService : IEmailConfigurationService
    {
        private readonly Lazy<IEmailConfigurationRepository> _repository;

        public EmailConfigurationService(Lazy<IEmailConfigurationRepository> repository)
        {
            _repository = repository;
        }



        public async Task<string> PrepareEmailContent(EmailConfigurationViewModel emailconfigviewmodel)
        {

            var emailconfig = await _repository.Value.Query().Where(_ => _.Language.Language1.ToLower() == emailconfigviewmodel.Language.ToLower() && _.EmailAction.Name.ToLower() == emailconfigviewmodel.ActionName.ToLower()).FirstOrDefaultAsync();

            var filecontent = File.ReadAllText(HostingEnvironment.MapPath(emailconfig?.FileUrl));
            var emailcontent = EmailTemplateHelper.CustomBindingPropertiesIntoString(filecontent, emailconfigviewmodel, typeof(EmailConfigurationViewModel));
            return emailcontent;

        }
    }
}

