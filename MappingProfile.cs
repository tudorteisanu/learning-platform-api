using AutoMapper;
using LearningPlatform.Models;
using LearningPlatform.DTO;
using LearningPlatform.Data;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDTO>();
        CreateMap<Achievement, AchievementDTO>();
        CreateMap<AchievementDTO, Achievement>();
        CreateMap<UserAchievement, UserAchievementDTO>();
        CreateMap<RegisterDTO, User>();
        CreateMap<LessonDTO, Lesson>();
        CreateMap<CourseDTO, Course>();
        CreateMap<Course, CourseResponseDTO>();
        CreateMap<CoursePatchDto, Course>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<LessonPatchDTO, Lesson>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<QuestionDTO, Question>();
        CreateMap<QuestionPatchDTO, Question>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        
        CreateMap<AnswerDTO, Answer>();
        CreateMap<AnswerPatchDTO, Answer>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<LessonContentDTO, LessonContent>();
        CreateMap<Lesson, LessonResponseDTO>();
        CreateMap<LessonContentPatchDTO, Lesson>();
        CreateMap<Lesson, LessonListResponseDTO>();
        CreateMap<Question, QuestionResponseDTO>()
            .ForMember(dest => dest.UserAnswer, opt => opt.MapFrom<UserAnswerResolver>());         
    }
}
