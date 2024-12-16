using LearningPlatform.Services;

public static class DISetup
{
    public static IServiceCollection InjectServices(this IServiceCollection services)
    {   
        // Register application services
        services.AddScoped<IAchievementsService, AchievementsService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<ILessonService, LessonService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IQuestionsService, QuestionsService>();
        services.AddScoped<IAnswersService, AnswersService>();
        
        return services;
    }
}
