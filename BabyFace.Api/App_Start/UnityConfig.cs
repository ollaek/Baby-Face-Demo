using BabyFace.Api.Helpers;
using BabyFace.Api.Models;

using BabyFace.Domain.Model.Contracts;
using BabyFace.Domain.Model.Models.Entities;
using BabyFace.Domain.Providers;
using BabyFace.Domain.Repositories;
using BabyFace.Domain.Services.Contracts;
using BabyFace.Domain.Services.Implementation;

using BabyFace.Domain.UnitOfWork;
using BabyFace.Infrastructure;
using BabyFace.Infrastructure.Providers;
using BabyFace.Infrastructure.Repositories;

using BabyFace.Infrastructure.UnitOfWork;

using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.DataProtection;
using System;
using System.Data.Entity;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;
using Unity.Injection;

namespace BabyFace.Api
{
  /// <summary>
  /// Specifies the Unity configuration for the main container.
  /// </summary>
  public static class UnityConfig
  {
    #region Unity Container
    private static Lazy<IUnityContainer> container =
      new Lazy<IUnityContainer>(() =>
      {
        var container = new UnityContainer();
        RegisterTypes(container);
        return container;
      });

    /// <summary>
    /// Configured Unity Container.
    /// </summary>
    public static IUnityContainer Container
    {
      get { return container.Value; }
    }
    #endregion

    /// <summary>
    /// Registers the type mappings with the Unity container.
    /// </summary>
    /// <param name="container">The unity container to configure.</param>
    /// <remarks>
    /// There is no need to register concrete types such as controllers or
    /// API controllers (unless you want to change the defaults), as Unity
    /// allows resolving a concrete type even if it was not previously
    /// registered.
    /// </remarks>
    public static void RegisterTypes(IUnityContainer container)
    {
      // NOTE: To load from web.config uncomment the line below.
      // Make sure to add a Unity.Configuration to the using statements.
      // container.LoadConfiguration();
      // TODO: Register your type's mappings here.
      // container.RegisterType<IProductRepository, ProductRepository>();

      //container.RegisterType(typeof(ISecureDataFormat<>), typeof(SecureDataFormat<>));
      //container.RegisterType<ISecureDataFormat<AuthenticationTicket>, SecureDataFormat<AuthenticationTicket>>();
      //container.RegisterType<ISecureDataFormat<AuthenticationTicket>, TicketDataFormat>();
      //container.RegisterType<IDataSerializer<AuthenticationTicket>, TicketSerializer>();
      //container.RegisterType<IDataProtector>(
      //    new InjectionFactory(c => new DpapiDataProtectionProvider().Create("ASP.NET Identity")));

      //container.RegisterType<IAuthenticationManager>(
      //    new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));

      container.RegisterType<DbContext, BabyFaceEntities>();
      container.RegisterType<UserManager<BabyFaceUser>>();


      // Register Application Dependencies Here
      container.RegisterType<IUnitOfWork, UnitOfWork>();
      container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            
      container.RegisterType(typeof(ILookupService<>), typeof(LookupService<>));

      container.RegisterType<IBabyFaceUserRepository, BabyFaceUserRepository>();
            
      container.RegisterType<IEmailConfigurationRepository, EmailConfigurationRepository>();
      container.RegisterType<IEmailConfigurationService, EmailConfigurationService>();

      container.RegisterType<IEnvironmentResourceRepository, EnvironmentResourceRepository>();
      container.RegisterType<IEnvironmentResourceService, EnvironmentResourceService>();


      container.RegisterType<IBabyFaceResetPasswordDataProtector>(
   new InjectionFactory(_ =>
     new BabyFaceResetPasswordDataProtector(
       new DpapiDataProtectionProvider("BabyFace").Create("ResetPasswordToken"))
   ));

      container.RegisterType<IBabyFaceChangeEmailDataProtector>(
        new InjectionFactory(_ =>
          new BabyFaceChangeEmailDataProtector(
            new DpapiDataProtectionProvider("BabyFace").Create("ChangeEmailToken"))
        ));

      container.RegisterType<IIocContainer, IocContainer>();


      //container.RegisterType<IResponseMessageDictionary, ResponseMessageDictionary>(new SingletonLifetimeManager());

      GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
    }
  }
}