using AutoMapper;
using LearningPlatform.DTO;
using LearningPlatform.Models;

public class QuestionAnswersResolver : IValueResolver<Question, QuestionResponseDTO, List<int>>
{
    public List<int> Resolve(Question source, QuestionResponseDTO destination, List<int> destMember, ResolutionContext context)
    {
        return source.Answers.Select(answer => answer.Id).ToList();
    }
}
