using DynamicAuth.Base.JsonConverter;
using System.Text.Json.Serialization;
using System.Text.Json;
using FluentValidation.AspNetCore;
using DynamicAuth.Messages.Commands.Validator;
using DynamicAuth.Domain.Entites;
using DynamicAuth.Repository.Implimentation;
using Microsoft.AspNetCore.Identity;
using DynamicAuth.Service.Interfaces;
using DynamicAuth.Repository;
using DynamicAuth.Service.Implimentation.Implementations;

namespace DynamicAuth.Base
{
    public static  class ServiceCollectionExtensions
    {
        public static void RegisterJsonConverterAndCommandValidation(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
            }).AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                opt.JsonSerializerOptions.Converters.Add(new PersianDateTimeConverter());
                opt.JsonSerializerOptions.Converters.Add(new GuidJsonConverter());
                opt.JsonSerializerOptions.Converters.Add(new IntToStringConverter());
                opt.JsonSerializerOptions.Converters.Add(new LongToStringConverter());
                opt.JsonSerializerOptions.Converters.Add(new DictionaryInt32Converter());
                opt.JsonSerializerOptions.Converters.Add(new DictionaryInt64Converter());
                opt.JsonSerializerOptions.WriteIndented = true;

            }).AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<SigninCommandValidator>());
        }
        public static void RegisterIdentityService(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                .AddErrorDescriber<CustomErrorDescriber>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
            
         
            });
     


        }
        public static void RegisterAllServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceHolder, ServiceHolder>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }


    }
}
