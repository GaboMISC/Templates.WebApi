using GaboMisc.Templates.WebApi.MinimalApi.Services.Contracts;
using GaboMisc.Templates.WebApi.MinimalApi.Services;

namespace GaboMisc.Templates.WebApi.MinimalApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // ---------- *** Services *** ----------
            builder.Services.AddScoped<IOperacionService, OperacionService>();
            // --------------------------------------------------

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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