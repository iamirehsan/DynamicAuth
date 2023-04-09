
using DynamicAuth.Base.JsonConverter;
using System.Text.Json.Serialization;
using System.Text.Json;
using FluentValidation.AspNetCore;
using DynamicAuth.Messages.Commands.Validator;
using DynamicAuth.Base;
using DynamicAuth.Repository.Implimentation;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DynamicAuth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
            builder.Services.RegisterJsonConverterAndCommandValidation();
            builder.Services.RegisterIdentityService();
           



            var app = builder.Build().Seed();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}