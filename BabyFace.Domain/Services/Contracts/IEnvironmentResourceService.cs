using BabyFace.Domain.Model.Enums;
using System.Threading.Tasks;
namespace BabyFace.Domain.Services.Contracts
{
  public interface IEnvironmentResourceService
  {
    Task<string> GetValueByResourceKey(string key, int? languageId);
  }
}
