using LearningPlatform.Services;

public static class CorsSetup
{
    public static IServiceCollection SetupCors(this IServiceCollection services)
    {   
       services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy =>
                {
                    policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
                    ;
                });
        });

        return services;
    }

    public static void EnableCors(this IApplicationBuilder app)
    {
       app.UseCors();
    }
}
