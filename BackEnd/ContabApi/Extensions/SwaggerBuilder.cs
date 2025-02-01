using Microsoft.OpenApi.Models;

namespace ContabApi.Extensions
{
    public static class SwaggerBuilder
    {
        public static void AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(o =>
            {
                o.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        ClientCredentials = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri("https://localhost:5001/connect/token"),
                            //TokenUrl = new Uri("https://localhost:5001/connect/authorize"),
                            Scopes = new Dictionary<string, string>
                            {
                                {"ContabApi_fullaccess","Basic access to Contab API" },
                            }
                        }
                    }
                });

                o.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2"
                            }
                        },
                        new List<string>()
                    }
                });
            });

            //builder.Services.AddSwaggerGen(o =>
            //{
            //    o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            //    {
            //        Name = "Authorization",
            //        Type = SecuritySchemeType.ApiKey,
            //        Scheme = "Bearer",
            //        BearerFormat = "JWT",
            //        In = ParameterLocation.Header,
            //        Description = "JWT Authorization header using the Bearer scheme."
            //    });
            //    o.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference
            //                {
            //                    Type = ReferenceType.SecurityScheme,
            //                    Id = "Bearer"
            //                }
            //            },
            //            new string[] {}
            //        }
            //    });
            //    });
            }
        }
}
