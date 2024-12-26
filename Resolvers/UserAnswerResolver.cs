using AutoMapper;
using LearningPlatform.DTO;
using LearningPlatform.Models;
using LearningPlatform.Data;

public class UserAnswerResolver : IValueResolver<Question, QuestionResponseDTO, int?>
{
    private readonly AppDbContext _dbContext;

    public UserAnswerResolver(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public int? Resolve(Question source, QuestionResponseDTO destination, int? destMember, ResolutionContext context)
    {
        var userId = 1;

        var userAnswer = _dbContext.UserAnswers
            .Where(ua => 
            ua.UserId == userId && 
            ua.QuestionId == destination.Id)
            .SingleOrDefault();

        return userAnswer?.AnswerId;
    }
}
