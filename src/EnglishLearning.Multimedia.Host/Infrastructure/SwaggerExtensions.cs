﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace EnglishLearning.Multimedia.Host.Infrastructure
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "EnglishLearning.Multimedia service API",
                    Contact = new Contact { Name = "Dima Lytvyniuk" },
                });
 
                s.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "Please insert JWT with Bearer into field. Example: Bearer {token}",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey",
                });

                s.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { } },
                });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger(s => { s.RouteTemplate = "api/multimedia/swagger/{documentName}/swagger.json"; });
            app.UseSwaggerUI(s =>
            {
                s.RoutePrefix = "api/multimedia/swagger";
                s.SwaggerEndpoint("v1/swagger.json", "EnglishLearning.Multimedia service API");
            });

            return app;
        }
    }
}