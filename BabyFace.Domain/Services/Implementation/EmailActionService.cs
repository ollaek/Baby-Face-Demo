using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabyFace.Domain.Model.Models.Entities;
using BabyFace.Domain.Repositories;
using BabyFace.Domain.Services.Contracts;

namespace BabyFace.Domain.Services.Implementation
{
    public class EmailActionService : IEmailActionService
    {
        private readonly Lazy<IEmailActionRepository> _repository;

        public EmailActionService(Lazy<IEmailActionRepository> repository)
        {
            _repository = repository;
        }

        public async Task<EmailAction> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            return await _repository.Value.Query().Where(_ => _.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync();
        }


    }
}
