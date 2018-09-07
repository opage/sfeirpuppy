using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.HealthChecks;
using Microsoft.Extensions.Logging;
using sfeirapi.Infrastructure;
using sfeirapi.Infrastructure.Extensions;
using System.Threading.Tasks;

namespace sfeirapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .AddControllersAsServices();

            services.Configure<SfeirApiSettings>(Configuration);

            services.AddHealthChecks(
                checks =>
                {
                    checks.AddValueTaskCheck(
                        "HTTP Endpoint",
                        () => new ValueTask<IHealthCheckResult>(HealthCheckResult.Healthy("Ok")));
                });

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = " Sfeir Puppy HTTP API",
                    Version = "v1",
                    Description = "The Sfeir puppy Microservice HTTP API.",
                    TermsOfService = "Terms Of Service"
                });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
            services.AddOptions();
            services.AddInfrastructureRegistry(Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();
            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseMvcWithDefaultRoute();
            app.UseSwagger()
            .UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sfeir puppy API V1");
                c.OAuthClientId("usersswaggerui");
                c.OAuthAppName("Users Swagger UI");
            });

            // Seed Data
            UsersContextSeed.SeedAsync(app, loggerFactory).Wait();
        }
    }
}
