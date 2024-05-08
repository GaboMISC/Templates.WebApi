using AutoMapper;
using GaboMisc.Templates.WebApi.Microservice._02.Application.Business.Contracts;
using GaboMisc.Templates.WebApi.Microservice._02.Application.Business.Handlers;
using GaboMisc.Templates.WebApi.Microservice._02.Application.Business;
using Microsoft.AspNetCore.Mvc;
using GaboMisc.Templates.WebApi.Microservice._03.Infraestructure.AutoMapper;

namespace GaboMisc.Templates.WebApi.Microservice
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // *** Auto Mapper ***
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles()); // Clase Mapper en Handdlers
            });
            var mapper = mapperConfiguration.CreateMapper();
            builder.Services.AddSingleton(mapper);
            // --------------------------------------------------

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // *** Business ***
            builder.Services.AddTransient<IValidationBusiness, ValidationBusiness>();
            // --------------------------------------------------

            // *** Control de errores en todos los controladores ***
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<ErrorHandler>();
            });
            // --------------------------------------------------

            // Errores Data Notations
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    return DataNotationsErrorHandler.CustomErrorResponse(actionContext);
                };
            });
            // --------------------------------------------------

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}