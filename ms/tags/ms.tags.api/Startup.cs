using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreRateLimit;
using Autofac;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ms.tag.api.Configurations;
using ms.tag.api.Configurations.AutoMappingProfiles.Tags;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Serilog;
using Serilog.Events;

namespace ms.tag.api
{
  public class Startup
  {
    public Startup(IConfiguration configuration, IHostingEnvironment hostEnv)
    {
      Configuration = configuration;
      HostEnv = hostEnv;
    }

    private const string CorsPolicyName = "AllowSpecificOrigins";

    public IConfiguration Configuration { get; }
    public IHostingEnvironment HostEnv { get; }
    public IContainer ApplicationContainer { get; private set; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(options =>
      {
        options.AddPolicy(CorsPolicyName,
          builderCors => { builderCors.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin(); });
      });

      services.Configure<CookiePolicyOptions>(options =>
      {
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      var name = Assembly.GetExecutingAssembly().GetName();

      Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(Configuration)
        .MinimumLevel.Debug()
        .MinimumLevel.Override("soa.api", LogEventLevel.Information)
        .Enrich.FromLogContext()
        .Enrich.WithMachineName()
        .Enrich.WithProperty("Assembly", $"{name.Name}")
        .Enrich.WithProperty("Revision", $"{name.Version}")
        .WriteTo.Debug(
          outputTemplate:
          "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {NewLine}{HttpContext} {NewLine}{Exception}")
        .WriteTo.RollingFile(HostEnv.WebRootPath + "\\logs.txt", Serilog.Events.LogEventLevel.Information,
          retainedFileCountLimit: 7)
        .CreateLogger();

      services.AddLogging(loggingBuilder =>
        loggingBuilder
          .AddSerilog(dispose: true));

      var key = Encoding.ASCII.GetBytes(Configuration.GetSection("TokenAuthentication:SecretKey").Value);
      services.AddAuthentication(x =>
        {
          x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
          x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
          x.RequireHttpsMetadata = false;
          x.SaveToken = true;
          x.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,
            ValidAudience = Configuration.GetSection("TokenAuthentication:Audience").Value,
          };
        });
      
      services.AddMvc(
          options =>
          {
            options.EnableEndpointRouting = false;
            options.RespectBrowserAcceptHeader = true;
            options.ReturnHttpNotAcceptable = true;
          })
        .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
        .AddNewtonsoftJson(options =>
        {
          options.SerializerSettings.ContractResolver =
            new DefaultContractResolver();
        })
        .AddFluentValidation();
      ;

      services.AddResponseCaching();

      services.AddHttpCacheHeaders(
        (expirationModelOptions)
          =>
        {
          expirationModelOptions.MaxAge = 60;
          expirationModelOptions.SharedMaxAge = 30;
        },
        (validationModelOptions)
          =>
        {
          validationModelOptions.MustRevalidate = true;
          validationModelOptions.ProxyRevalidate = true;
        });

      services.AddMemoryCache();

      services.Configure<IpRateLimitOptions>((options) =>
      {
        options.GeneralRules = new System.Collections.Generic.List<RateLimitRule>()
        {
          new RateLimitRule()
          {
            Endpoint = "*",
            Limit = 1000,
            Period = "5m"
          },
          new RateLimitRule()
          {
            Endpoint = "*",
            Limit = 200,
            Period = "10s"
          }
        };
      });

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo()
        {
          Title = "ms.tag.qa99.api - HTTP API",
          Version = "v1",
          Description = "The Catalog Microservice HTTP API for ms.tag.qa99.api service",
        });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
          Description =
            "Authorization: Bearer {token}",
          Name = "Authorization",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.ApiKey
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
          {
            new OpenApiSecurityScheme
            {
              Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              }
            },
            new string[] { }
          }
        });
        // Set the comments path for the Swagger JSON and UI.
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
      });

      Config.ConfigureRepositories(services);
      Config.ConfigureAutoMapper(services);
      Config.ConfigureNHibernate(services, Configuration.GetConnectionString("PostgreSqlDatabase"));

      services.AddHealthChecks()
        .AddNpgSql(Configuration.GetConnectionString("PostgreSqlDatabase"), failureStatus: HealthStatus.Unhealthy,
          name: "PostgreSQL database", tags: new[] { "ready" });

      services.AddCors(options =>
      {
        options.AddPolicy(CorsPolicyName,
          builderCors => { builderCors.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin(); });
      });
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      app.UseHealthChecks("/health/ready",
        new HealthCheckOptions
        {

          ResultStatusCodes =
          {
            [HealthStatus.Healthy] = StatusCodes.Status200OK,
            [HealthStatus.Degraded] = StatusCodes.Status500InternalServerError,
            [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable,
          },

          Predicate = (check) => check.Tags.Contains("ready"),
          AllowCachingResponses = false,
          ResponseWriter = WriteHealthCheckReadyResponse
        });

      app.UseHealthChecks("/health/live",
        new HealthCheckOptions
        {
          Predicate = (check) => !check.Tags.Contains("live"),
          ResponseWriter = WriteHealthCheckLiveResponse,
          AllowCachingResponses = false
        });

      app.UseHealthChecks("/health", new HealthCheckOptions
      {
        Predicate = _ => true,
        ResultStatusCodes =
        {
          [HealthStatus.Healthy] = StatusCodes.Status200OK,
          [HealthStatus.Degraded] = StatusCodes.Status500InternalServerError,
          [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable,
        },
        AllowCachingResponses = false
      });

      app.UseSwagger()
        .UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "ms.tag.qa99.api - API V1"); });

      app.UseCors(CorsPolicyName);
      app.UseResponseCaching();
      app.UseHttpCacheHeaders();
      app.UseCookiePolicy();
      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      AutoMapper.Mapper.Initialize(cfg =>
      {
        cfg.AddProfile<TagEntityToTagUiAutoMapperProfile>();
      });

      app.UseEndpoints(endpoints => {
        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}");
        endpoints.MapRazorPages();
      });
    }
    private Task WriteHealthCheckLiveResponse(HttpContext httpContext, HealthReport result)
    {
      httpContext.Response.ContentType = "application/json";

      var json = new JObject(
        new JProperty("OverallStatus", result.Status.ToString()),
        new JProperty("TotalChecksDuration", result.TotalDuration.TotalSeconds.ToString("0:0.00"))
      );

      return httpContext.Response.WriteAsync(json.ToString(Formatting.Indented));
    }

    private Task WriteHealthCheckReadyResponse(HttpContext httpContext, HealthReport result)
    {
      httpContext.Response.ContentType = "application/json";

      var json = new JObject(
        new JProperty("OverallStatus", result.Status.ToString()),
        new JProperty("TotalChecksDuration", result.TotalDuration.TotalSeconds.ToString("0:0.00")),
        new JProperty("DependencyHealthChecks", new JObject(result.Entries.Select(dicItem =>
          new JProperty(dicItem.Key, new JObject(
            new JProperty("Status", dicItem.Value.Status.ToString()),
            new JProperty("Duration", dicItem.Value.Duration.TotalSeconds.ToString("0:0.00")),
            new JProperty("Exception", dicItem.Value.Exception?.Message),
            new JProperty("Data", new JObject(dicItem.Value.Data.Select(dicData =>
              new JProperty(dicData.Key, dicData.Value))))
          ))
        )))
      );

      return httpContext.Response.WriteAsync(json.ToString(Formatting.Indented));
    }
  }
}
