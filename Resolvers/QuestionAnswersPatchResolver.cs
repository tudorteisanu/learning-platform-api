using AutoMapper;
using LearningPlatform.Data;
using LearningPlatform.DTO;
using LearningPlatform.Models;

public class QuestionAnswersPatchResolver : IValueResolver<QuestionPatchTO, Question, ICollection<Answer>>
{
    private AppDbContext _context;

    public QuestionAnswersPatchResolver(AppDbContext context) {
        _context = context;
    }

    public ICollection<Answer> Resolve(QuestionPatchTO  source, Question destination, ICollection<Answer> destMember, ResolutionContext context)
    {
        return source.Answers.Select(Id => _context.Answers.Find(Id)!).ToList();
    }
}
