using Microsoft.OpenApi.Models;

public static class SwaggerSetup
{
    public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
    {    
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Learning Platform API",
                Description = "API documentation for the ECommerce project",
            });

            // Admin API definition
            c.SwaggerDoc("v1-admin", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Admin API",
                Version = "v1"
            });

            // Use a filter to assign controllers to groups
            c.DocInclusionPredicate((docName, apiDesc) =>
            {
                if (docName == "v1")
                    return apiDesc.GroupName != "Admin";

                if (docName == "v1-admin")
                    return apiDesc.GroupName == "Admin";

                return false;
            });

            // Add JWT authentication to Swagger
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please insert JWT with Bearer into field",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });


        return services;
    }

    public static void UseCustomSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECommerce API V1");
            c.SwaggerEndpoint("/swagger/v1-admin/swagger.json", "Admin");
            c.RoutePrefix = "api/docs";
        });
    }
}
