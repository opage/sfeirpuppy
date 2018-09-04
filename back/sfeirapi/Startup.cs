using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using sfeirapi.Infrastructure;

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
            services.Configure<SfeirApiSettings>(Configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();
            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            //.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint($"{ (!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty) }/swagger/v1/swagger.json", "Sfeir puppy API V1");
            //    c.OAuthClientId("locationsswaggerui");
            //    c.OAuthAppName("Locations Swagger UI");
            //});

            UsersContextSeed.SeedAsync(app, loggerFactory)
                .Wait();
        }
    }
}
