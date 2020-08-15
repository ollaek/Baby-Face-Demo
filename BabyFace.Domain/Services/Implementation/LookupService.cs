using BabyFace.Domain.Model.Constants;
using BabyFace.Domain.Model.Contracts;
using BabyFace.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BabyFace.Domain.Services.Implementation
{
  public class LookupService : ILookupService
  {
    private readonly Lazy<IIocContainer> _container;

    public LookupService(Lazy<IIocContainer> container)
    {
      _container = container ?? throw new ArgumentNullException(nameof(container));
    }

    public Dictionary<string, dynamic> GetAll()
    {
      var types = AppDomain.CurrentDomain.GetAssemblies()
        .Where(_ => _.GetName().Name == BabyFaceConstants.DomainEntitiesAssemblyName)
        .SelectMany(_ => _.GetTypes())
        .Where(_ => typeof(ILookupEntity).IsAssignableFrom(_) && !_.IsInterface).ToList();

      var result = new Dictionary<string, dynamic>();

      foreach (var type in types)
      {
        var serviceType = typeof(ILookupService<>).MakeGenericType(type);

        var service = _container.Value.Resolve(serviceType);
        result.Add(type.Name, service.GetType().GetMethod("GetFuture")?.Invoke(service, null));
      }

      return result;
    }

    public Dictionary<string, dynamic> GetByName(string[] lookupNames)
    {
      var result = new Dictionary<string, dynamic>();

      foreach (var lookupName in lookupNames)
      {
        var entityType =
          Type.GetType($"{BabyFaceConstants.DomainEntitiesNamespace}.{lookupName}, {BabyFaceConstants.DomainEntitiesAssemblyName}");

        if (entityType == null)
          continue;

        var serviceType = typeof(ILookupService<>).MakeGenericType(entityType);

        var service = _container.Value.Resolve(serviceType);
        result.Add(lookupName, service.GetType().GetMethod("GetFuture")?.Invoke(service, null));
      }

      return result;
    }

    public List<string> GetLookupNames()
    {
      return AppDomain.CurrentDomain.GetAssemblies()
        .Where(_ => _.GetName().Name == BabyFaceConstants.DomainEntitiesAssemblyName)
        .SelectMany(_ => _.GetTypes())
        .Where(_ => typeof(ILookupEntity).IsAssignableFrom(_) && !_.IsInterface)
        .Select(_ => _.Name)
        .ToList();
    }
  }
}
