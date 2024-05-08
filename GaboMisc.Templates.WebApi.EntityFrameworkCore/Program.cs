using GaboMisc.Templates.WebApi.EntityFrameworkCore.Data;
using GaboMisc.Templates.WebApi.EntityFrameworkCore.Handlers;
using GaboMisc.Templates.WebApi.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

/* ---------- *** Nuggets *** ----------
 * Microsoft.EntityFrameworkCore.Design
 * Microsoft.EntityFrameworkCore.SqlServer
 * 
 * Cambiar la siguiente etiqueta de true a false o eliminarla para Entity Framework por el tema del idioma.
    <InvariantGlobalization>false</InvariantGlobalization>
// -------------------------------------------------- */

namespace GaboMisc.Templates.WebApi.EntityFrameworkCore
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // ---------- *** Entity Framework *** ----------
            builder.Configuration.AddJsonFile("appsettings.json");

            builder.Services.AddDbContext<EmployeeContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                    sqlServerOptionsAction => sqlServerOptionsAction.EnableRetryOnFailure()));
            // --------------------------------------------------

            // ---------- *** Repositories *** ----------
            builder.Services.AddScoped<EmployeeRepository>();
            // --------------------------------------------------

            // ---------- *** Control de errores en todos los controladores *** ----------
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<ErrorHandler>();
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