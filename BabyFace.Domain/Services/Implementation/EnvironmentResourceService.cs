using BabyFace.Domain.Model.Enums;
using BabyFace.Domain.Repositories;
using BabyFace.Domain.Services.Contracts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace BabyFace.Domain.Services.Implementation
{
  public class EnvironmentResourceService : IEnvironmentResourceService
  {
    private readonly Lazy<IEnvironmentResourceRepository> _repository;
    public EnvironmentResourceService(Lazy<IEnvironmentResourceRepository> repository)
    {
      _repository = repository;
    }

    public async Task<string> GetValueByResourceKey(string key, int? languageId)
    {
      return await _repository.Value.Query()
                      .Where(r => r.Language == languageId && r.Key == key)
                      .Select(_ => _.Value)
                      .FirstOrDefaultAsync();
    }
  }
}
