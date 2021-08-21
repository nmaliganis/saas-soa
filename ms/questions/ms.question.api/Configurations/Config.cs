using System;
using System.Reflection;
using AspNetCoreRateLimit;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using ms.question.api.Helpers.Repositories;
using ms.question.api.Helpers.Repositories.Mappings;
using ms.question.api.Helpers.Services.Blocks.Question;
using ms.question.api.Helpers.Services.Blocks.Question.Contracts;
using ms.question.api.Helpers.Services.Blocks.Question.Impls;
using NHibernate;
using NHibernate.Driver;
using NHibernate.Spatial.Dialect;
using NHibernate.Spatial.Mapping;
using NHibernate.Spatial.Metadata;
using soa.common.infrastructure.Exceptions.Repositories;
using soa.common.infrastructure.PropertyMappings.TypeHelpers;
using soa.common.infrastructure.Serializers;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;

namespace ms.question.api.Configurations
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

      services.AddScoped<IInquiryQuestionProcessor, InquiryQuestionProcessor>();
      services.AddScoped<IInquiryAllQuestionsProcessor, InquiryAllQuestionsProcessor>();
      services.AddScoped<ICreateQuestionProcessor, CreateQuestionProcessor>();
      services.AddScoped<IQuestionRepository, QuestionRepository>();
      services.AddScoped<IQuestionsControllerDependencyBlock, QuestionsControllerDependencyBlock>();
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
          .Mappings(x => x.FluentMappings.AddFromAssemblyOf<QuestionMap>())
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
