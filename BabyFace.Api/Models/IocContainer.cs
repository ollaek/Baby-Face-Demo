using BabyFace.Domain.Model.Contracts;
using System;
using System.Collections.Generic;
using Unity;
using Unity.Extension;
using Unity.Lifetime;
using Unity.Registration;
using Unity.Resolution;

namespace BabyFace.Api.Models
{
  public class IocContainer : IUnityContainer, IIocContainer
  {
    private readonly IUnityContainer _container = UnityConfig.Container;

    public void Dispose()
    {
      _container.Dispose();
    }

    public IUnityContainer RegisterType(Type typeFrom, Type typeTo, string name, LifetimeManager lifetimeManager,
      params InjectionMember[] injectionMembers)
    {
      return _container.RegisterType(typeFrom, typeTo, name, lifetimeManager, injectionMembers);
    }

    public IUnityContainer RegisterInstance(Type type, string name, object instance, LifetimeManager lifetime)
    {
      return _container.RegisterInstance(type, name, instance, lifetime);
    }

    public object Resolve(Type type, string name, params ResolverOverride[] resolverOverrides)
    {
      return _container.Resolve(type, name, resolverOverrides);
    }

    public object BuildUp(Type type, object existing, string name, params ResolverOverride[] resolverOverrides)
    {
      return _container.BuildUp(type, existing, name, resolverOverrides);
    }

    public IUnityContainer AddExtension(UnityContainerExtension extension)
    {
      return _container.AddExtension(extension);
    }

    public object Configure(Type configurationInterface)
    {
      return _container.Configure(configurationInterface);
    }

    public IUnityContainer CreateChildContainer() { return _container.CreateChildContainer(); }

    public bool IsRegistered(Type type, string name)
    {
      return _container.IsRegistered(type, name);
    }

    public IUnityContainer Parent
    {
      get { return _container.Parent; }
    }

    public IEnumerable<IContainerRegistration> Registrations
    {
      get { return _container.Registrations; }
    }

    public object Resolve(Type type)
    {
      return _container.Resolve(type);
    }
  }
}