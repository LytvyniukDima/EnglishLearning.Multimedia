﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EnglishLearning.Multimedia.Host.Infrastructure
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "EnglishLearning.Multimedia service API",
                    Contact = new OpenApiContact { Name = "Dima Lytvyniuk" },
                });
 
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Please insert JWT with Bearer into field. Example: Bearer {token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
                        },
                        new string[0]
                    },
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