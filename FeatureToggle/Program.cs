using Microsoft.EntityFrameworkCore;
using FeatureToggle.Models;
using FeatureToggle.Data;
using Microsoft.Extensions.Options;
using FeatureToggle.Services;

namespace FeatureToggle
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
            builder.Services.AddDbContext<FeatureDbContext>(Options => Options.UseNpgsql(builder.Configuration.GetConnectionString("Defaultconnection")));
            builder.Services.AddScoped<FeatureService>();
            builder.Services.AddScoped<FeatureRepository>();


            var app = builder.Build();

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
