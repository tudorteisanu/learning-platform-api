using AutoMapper;
using LearningPlatform.Models;
using LearningPlatform.DTO;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDTO>();
        CreateMap<Achievement, AchievementDTO>();
        CreateMap<AchievementDTO, Achievement>();
        CreateMap<UserAchievement, UserAchievementDTO>();
        CreateMap<RegisterDTO, User>()
             .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom<PasswordHashResolver>());
        // Course maps end
        CreateMap<CourseDTO, Course>();
        CreateMap<Course, CourseResponseDTO>();
        CreateMap<CoursePatchDto, Course>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        // Course maps end
        // Question maps start 
        CreateMap<QuestionDTO, Question>()
            .ForMember(dest => dest.Answers, opt => opt.MapFrom<QuestionAnswersPostResolver>());
        CreateMap<QuestionPatchTO, Question>()
            .ForMember(dest => dest.Answers, opt => opt.MapFrom<QuestionAnswersPatchResolver>())
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<Question, QuestionResponseDTO>()
            .ForMember(dest => dest.UserAnswer, opt => opt.MapFrom<UserAnswerResolver>())
            .ForMember(dest => dest.Answers, opt => opt.MapFrom<QuestionAnswersResolver>()); 
        // Question maps end
        // Answer maps start
        CreateMap<AnswerDTO, Answer>()
            .ForMember(dest => dest.Id, opt => new Guid());
        CreateMap<AnswerPatchDTO, Answer>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        // Answer maps end
        // Lessons maps start
        CreateMap<LessonDTO, Lesson>();
        CreateMap<LessonPatchDTO, Lesson>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<Lesson, LessonResponseDTO>();
        CreateMap<Lesson, LessonListResponseDTO>();
        // Lessons maps end
        // Content maps start
        CreateMap<ContentDTO, Content>();
         CreateMap<ContentPatchDTO, Content>();
        // Content maps end
    }
}
