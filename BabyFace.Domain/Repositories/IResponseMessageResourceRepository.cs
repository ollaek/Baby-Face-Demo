using BabyFace.Domain.Model.Models.Entities;
using System.Linq;

namespace BabyFace.Domain.Repositories
{
  public interface IResponseMessageResourceRepository : IRepository<ResponseMessageResource>
  {
    IQueryable<ResponseMessageResource> GetMessages();
  }
}
