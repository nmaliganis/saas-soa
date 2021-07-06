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
using soa.common.infrastructure.Exceptions.Repositories;
using soa.common.infrastructure.PropertyMappings.TypeHelpers;
using soa.common.infrastructure.Serializers;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;
using soa.qa.contracts.Answers;
using soa.qa.contracts.Categories;
using soa.qa.contracts.Persons;
using soa.qa.contracts.Questions;
using soa.qa.contracts.Tags;
using soa.qa.contracts.V1;
using soa.qa.repository.ContractRepositories;
using soa.qa.repository.Mappings.Questions;
using soa.qa.repository.NhUnitOfWork;
using soa.qa.repository.Repositories;
using soa.qa.services.Answers;
using soa.qa.services.Categories;
using soa.qa.services.Persons;
using soa.qa.services.Questions;
using soa.qa.services.Tags;
using soa.services.V1;

namespace soa.qa.api.Configurations
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
      services.AddScoped<IUpdateQuestionProcessor, UpdateQuestionProcessor>();
      services.AddScoped<IDeleteQuestionProcessor, DeleteQuestionProcessor>();
      services.AddScoped<IQuestionRepository, QuestionRepository>();
      services.AddScoped<IQuestionsControllerDependencyBlock, QuestionsControllerDependencyBlock>();

      services.AddScoped<IInquiryAnswerProcessor, InquiryAnswerProcessor>();
      services.AddScoped<IInquiryAllAnswersProcessor, InquiryAllAnswersProcessor>();
      services.AddScoped<ICreateAnswerProcessor, CreateAnswerProcessor>();
      services.AddScoped<IUpdateAnswerProcessor, UpdateAnswerProcessor>();
      services.AddScoped<IDeleteAnswerProcessor, DeleteAnswerProcessor>();
      services.AddScoped<IAnswerRepository, AnswerRepository>();
      services.AddScoped<IAnswersControllerDependencyBlock, AnswersControllerDependencyBlock>();

      services.AddScoped<IInquiryCategoryProcessor, InquiryCategoryProcessor>();
      services.AddScoped<IInquiryAllCategoriesProcessor, InquiryAllCategoriesProcessor>();
      services.AddScoped<ICreateCategoryProcessor, CreateCategoryProcessor>();
      services.AddScoped<IUpdateCategoryProcessor, UpdateCategoryProcessor>();
      services.AddScoped<IDeleteCategoryProcessor, DeleteCategoryProcessor>();
      services.AddScoped<ICategoryRepository, CategoryRepository>();
      services.AddScoped<ICategoriesControllerDependencyBlock, CategoriesControllerDependencyBlock>();
      
      services.AddScoped<IInquiryPersonProcessor, InquiryPersonProcessor>();
      services.AddScoped<IInquiryAllPersonsProcessor, InquiryAllPersonsProcessor>();
      services.AddScoped<ICreatePersonProcessor, CreatePersonProcessor>();
      services.AddScoped<IUpdatePersonProcessor, UpdatePersonProcessor>();
      services.AddScoped<IDeletePersonProcessor, DeletePersonProcessor>();
      services.AddScoped<IPersonRepository, PersonRepository>();
      services.AddScoped<IPersonsControllerDependencyBlock, PersonsControllerDependencyBlock>();
      
      services.AddScoped<IInquiryTagProcessor, InquiryTagProcessor>();
      services.AddScoped<IInquiryAllTagsProcessor, InquiryAllTagsProcessor>();
      services.AddScoped<ICreateTagProcessor, CreateTagProcessor>();
      services.AddScoped<IUpdateTagProcessor, UpdateTagProcessor>();
      services.AddScoped<IDeleteTagProcessor, DeleteTagProcessor>();
      services.AddScoped<ITagRepository, TagRepository>();
      services.AddScoped<ITagsControllerDependencyBlock, TagsControllerDependencyBlock>();
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
