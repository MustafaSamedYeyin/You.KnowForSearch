using Business.Services;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Ollama;
using Data.Repositories;
using DeckSpace;
using Elastic.Transport;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OllamaKafka;
using QuestionSpace;
using System.Text;
using TabSpace;
using Test.English.WebAPI.Ollama;
using UserSpace;

namespace API.ExtensionsMethods;

public static class ServiceContainer
{

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IQuestionsRepository, QuestionsRepository>();
        services.AddScoped<IQuestionsService, QuestionsService>();
        services.AddScoped<IQuestionTypeRepository, QuestionTypeRepository>();
        services.AddScoped<IQuestionTypeService, QuestionTypeService>();
        services.AddScoped<IQuestionTabRepository, QuestionTabRepository>();
        services.AddScoped<IQuestionTabService, QuestionTabService>();
        services.AddScoped<ITabRepository, TabRepository>();
        services.AddScoped<ITabService, TabService>();
        services.AddScoped<IDeckRepository, DeckRepository>();
        services.AddScoped<IDeckService, DeckService>();
        services.AddScoped<IKafkaService, KafkaService>();
        services.AddScoped<IKafkaMessageToDb, KafkaMessageToDb>();
        services.AddScoped<IOllamaKafkaService, OllamaKafkaService>();
        services.AddScoped<IOllamaMessageToKafka, OllamaMessageToKafka>();
        services.AddScoped<IOllamaService, OllamaService>();
        services.AddScoped<IDeckItemRepository, DeckItemRepository>();
        services.AddScoped<IDeckItemService, DeckItemService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
        return services;
    }

    public static IServiceCollection AddRedis(this IServiceCollection services)
    {
        //services.AddSingleton<IRedisClientsManagerAsync>(new RedisManagerPool("localhost:6379"));
        //services.AddSingleton(typeof(IRedisSessionService), typeof(RedisSessionService));
        return services;
    }

    public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration _configuration)
    {

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(jwtOptions =>
        {
            jwtOptions.Audience = _configuration["Api:Audience"];
            jwtOptions.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidAudiences = _configuration.GetSection("Api:ValidAudiences").Get<string[]>(),
                ValidIssuers = _configuration.GetSection("Api:ValidIssuers").Get<string[]>(),
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Api:SecretKey"]))
            };

            jwtOptions.MapInboundClaims = false;
        });
        return services;
    }

    public static IServiceCollection AddElasticSearch(this IServiceCollection services, IConfiguration _configuration)
    {
        //services.AddSingleton(sp =>
        //{
        //    var settings = new ElasticsearchClientSettings(new Uri("http://localhost:9200"))
        //      .Authentication(new BasicAuthentication("elastic", "eMHG70*GcVTrDSaAWlYq")).DefaultIndex("question")
        //      .GlobalHeaders(new NameValueCollection()
        //      {
        //               { "Accept", "application/vnd.elasticsearch+json;compatible-with=8" },
        //               { "Content-Type", "application/vnd.elasticsearch+json;compatible-with=8" }
        //      });
        //    return new ElasticsearchClient(settings);
        //});
        //services.AddScoped<IElasticSearchQuestionService, ElasticSearchQuestionService>();
        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
            var securityScheme = new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };
            c.AddSecurityDefinition("Bearer", securityScheme);
            var securityRequirement = new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                    {
                        { securityScheme, new[] { "Bearer" } }
                    };
            c.AddSecurityRequirement(securityRequirement);
        });

        return services;
    }

    public static IServiceCollection AddCORS(this IServiceCollection services)
    {

        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                 builder => builder.WithOrigins("https://questionsapp.mustafasamedyeyin.com")
                                  .AllowAnyMethod()
                                  .AllowAnyHeader()
                                  .AllowCredentials());

            options.AddPolicy("AllowDevOrigin",
                builder => builder.WithOrigins("https://localhost:4201")
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials());
        });
        return services;
    }



    public static IServiceCollection AddSessionServices(this IServiceCollection services)
    {
        //services.AddSession(options =>
        //{
        //    options.IdleTimeout = TimeSpan.FromMinutes(30);
        //    options.Cookie.HttpOnly = true;
        //    options.Cookie.IsEssential = true;
        //});

        //services.AddStackExchangeRedisCache(options =>
        //{
        //    options.Configuration = "localhost:6379,allowAdmin=true";
        //    options.InstanceName = "YouKnowForSearch_";
        //});
        return services;
    }
}
