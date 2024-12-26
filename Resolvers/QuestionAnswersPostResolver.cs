using AutoMapper;
using LearningPlatform.Data;
using LearningPlatform.DTO;
using LearningPlatform.Models;

public class QuestionAnswersPostResolver : IValueResolver<QuestionDTO, Question, ICollection<Answer>>
{
    private AppDbContext _context;

    public QuestionAnswersPostResolver(AppDbContext context) {
        _context = context;
    }

    public ICollection<Answer> Resolve(QuestionDTO  source, Question destination, ICollection<Answer> destMember, ResolutionContext context)
    {
        return source.Answers.Select(Id => _context.Answers.Find(Id)!).ToList();
    }
}
