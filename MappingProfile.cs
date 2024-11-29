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
        CreateMap<RegisterDTO, User>();
        CreateMap<LessonDTO, Lesson>();
        CreateMap<CourseDTO, Course>();
        CreateMap<CoursePatchDto, Course>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<PatchLessonDTO, Lesson>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<QuestionDTO, Question>();
        CreateMap<QuestionPatchDTO, Question>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        
        CreateMap<OptionDTO, Option>();
        CreateMap<OptionPatchDTO, Option>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<LessonContentDTO, LessonContent>();
        CreateMap<LessonContentPatchDTO, LessonContent>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));;
        
    }
}
