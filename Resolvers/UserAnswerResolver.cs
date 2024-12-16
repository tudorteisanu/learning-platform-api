using AutoMapper;
using LearningPlatform.DTO;
using LearningPlatform.Models;
using LearningPlatform.Data;

public class UserAnswerResolver : IValueResolver<Question, QuestionResponseDTO, Guid?>
{
    private readonly AppDbContext _dbContext;

    public UserAnswerResolver(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Guid? Resolve(Question source, QuestionResponseDTO destination, Guid? destMember, ResolutionContext context)
    {
        var userId = new Guid("c93cbb80-fbff-45a5-8934-a58813ae42a7	");

        var userAnswer = _dbContext.UserAnswers
            .Where(ua => ua.UserId == userId && ua.QuestionId == source.Id)
            .SingleOrDefault();

        return userAnswer?.AnswerId ;
    }
}
