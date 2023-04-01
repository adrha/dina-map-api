using Microsoft.EntityFrameworkCore;
using OpenParticipationPlatform.Api.Context;
using OpenParticipationPlatform.Api.Repository;
using OpenParticipationPlatform.Api.Services;
using System.Reflection;

namespace OpenParticipationPlatform.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var serverVersion = new MySqlServerVersion(new Version(10, 7));
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, serverVersion)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                );

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(name: "any",
                    policy =>
                    {
                        policy
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            ;
                    });
            });

            services.AddAutoMapper(new Assembly[] {
                Assembly.Load("OpenParticipationPlatform.Api")});

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<BasicDataRepository>();
            services.AddScoped<GeoJsonTransformationService>();
        }

        public void Configure(IApplicationBuilder app, IHostApplicationLifetime lifetime)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("any");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
