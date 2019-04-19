using EnglishLearning.Multimedia.Application.Configuration;
using EnglishLearning.Multimedia.Host.Infrastructure;
using EnglishLearning.Multimedia.Persistence.Configuration;
using EnglishLearning.Multimedia.Web.Configuration;
using EnglishLearning.Utilities.General.Extensions;
using EnglishLearning.Utilities.Identity.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishLearning.Multimedia.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddMvc(options => { options.AddEnglishLearningIdentityFilters(); });
            
            services
                .PersistenceConfiguration(Configuration)
                .AddApplicationConfiguration(Configuration)
                .AddWebConfiguration();
        
            services.AddSwaggerDocumentation();
            
            services.AddEnglishLearningIdentity();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseEnglishLearningExceptionMiddleware();
            
            app.UseCors("CorsPolicy");
            app.UseSwaggerDocumentation();
            app.UseMvc();
        }
    }
}
