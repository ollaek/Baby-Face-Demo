using System;

namespace BabyFace.Domain.Model.Contracts
{
  public interface IIocContainer
  {
    object Resolve(Type type);
  }
}
