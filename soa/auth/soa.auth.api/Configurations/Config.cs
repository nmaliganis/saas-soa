using System;
using System.Reflection;
using AspNetCoreRateLimit;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Driver;
using NHibernate.Spatial.Dialect;
using NHibernate.Spatial.Mapping;
using NHibernate.Spatial.Metadata;
using soa.auth.api.Helpers.Repositories;
using soa.auth.api.Helpers.Repositories.Mappings;
using soa.auth.api.Helpers.Services.Blocks;
using soa.auth.api.Helpers.Services.Blocks.Statistics.Contracts;
using soa.auth.api.Helpers.Services.Blocks.Statistics.Impls;
using soa.common.infrastructure.Exceptions.Repositories;
using soa.common.infrastructure.PropertyMappings.TypeHelpers;
using soa.common.infrastructure.Serializers;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;

namespace soa.auth.api.Configurations
{
  public static class Config
  {
    public static void ConfigureRepositories(IServiceCollection services)
    {
      services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
      services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
      services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
      services.AddScoped<IUrlHelper>(implementationFactory =>
      {
        var actionContext = implementationFactory.GetService<IActionContextAccessor>()
          .ActionContext;
        return new UrlHelper(actionContext);
      });

      services.AddScoped<IUrlHelper>(x =>
      {
        var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
        var factory = x.GetRequiredService<IUrlHelperFactory>();
        return factory.GetUrlHelper(actionContext);
      });

      services.AddSingleton<ITypeHelperService, TypeHelperService>();

      services.AddSingleton<IJsonSerializer, JSONsSerializer>();

      services.AddScoped<IInquiryAccountProcessor, InquiryAccountProcessor>();
      services.AddScoped<IInquiryAllAccountsProcessor, InquiryAllAccountsProcessor>();
      services.AddScoped<ICreateAccountProcessor, CreateAccountProcessor>();
      services.AddScoped<IAccountRepository, AccountRepository>();
      services.AddScoped<IAccountsControllerDependencyBlock, AccountsControllerDependencyBlock>();
    }

    public static void ConfigureAutoMapper(IServiceCollection services)
    {
      services.AddSingleton<IAutoMapper, AutoMapperAdapter>();
    }

    public static void ConfigureNHibernate(IServiceCollection services, string connectionString)
    {
      try
      {
        var cfg = Fluently.Configure()
          .Database(PostgreSQLConfiguration.PostgreSQL82
            .ConnectionString(connectionString)
            .Driver<NpgsqlDriver>()
            .Dialect<PostGis20Dialect>()
            //.ShowSql()
            .MaxFetchDepth(5)
            .FormatSql()
            .Raw("transaction.use_connection_on_system_prepare", "true")
            .AdoNetBatchSize(100)
          )
          .Mappings(x => x.FluentMappings.AddFromAssemblyOf<AccountMap>())
          .Cache(c => c.UseSecondLevelCache().UseQueryCache()
            .ProviderClass(typeof(NHibernate.Caches.RtMemoryCache.RtMemoryCacheProvider)
              .AssemblyQualifiedName)
          )
          .CurrentSessionContext("web")
          .BuildConfiguration();

        cfg.AddAssembly(Assembly.GetExecutingAssembly());
        cfg.AddAuxiliaryDatabaseObject(new SpatialAuxiliaryDatabaseObject(cfg));
        Metadata.AddMapping(cfg, MetadataClass.GeometryColumn);
        Metadata.AddMapping(cfg, MetadataClass.SpatialReferenceSystem);

        var sessionFactory = cfg.BuildSessionFactory();

        services.AddSingleton<ISessionFactory>(sessionFactory);

        services.AddScoped<ISession>((ctx) =>
        {
          var sf = ctx.GetRequiredService<ISessionFactory>();

          return sf.OpenSession();

        });

        services.AddScoped<IUnitOfWork, NhUnitOfWork>();
      }
      catch (Exception ex)
      {
        throw new NHibernateInitializationException(ex.Message, ex.InnerException?.Message);
      }
    }
  }
}
