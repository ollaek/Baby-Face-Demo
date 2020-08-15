using System.Collections.Generic;

namespace BabyFace.Domain.Services.Contracts
{
  public interface ILookupService
  {
    Dictionary<string, dynamic> GetAll();
    Dictionary<string, dynamic> GetByName(string[] lookupNames);
    List<string> GetLookupNames();
  }
}
