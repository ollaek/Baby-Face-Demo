using BabyFace.Domain.Model.Models.Entities;
using BabyFace.Domain.Repositories;
using BabyFace.Domain.UnitOfWork;
using System.Linq;

namespace BabyFace.Infrastructure.Repositories
{
  public class ResponseMessageResourceRepository : Repository<ResponseMessageResource>, IResponseMessageResourceRepository
  {
    public ResponseMessageResourceRepository(IUnitOfWork unitOfWork)
      : base(unitOfWork)
    {
    }

    public IQueryable<ResponseMessageResource> GetMessages()
    {
      return GetAll()/*.Select(_ => new ResponseMessageResource { Code = _.Code, MessageKey = _.MessageKey, Message = _.Message, LanguageId = _.LanguageId })*/;
    }

  }

}
