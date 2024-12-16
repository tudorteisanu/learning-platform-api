using LearningPlatform.Data;
using LearningPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Services;

public interface IAnswersService {
    Task<IEnumerable<Answer>> GetOptionsByQuestionId(Guid questionId);
    Task<Answer> CreateOption(Answer option);
    Task<bool> DeleteQuestion(Guid questionId);
}

public class AnswersService : IAnswersService {
    private readonly AppDbContext _context;

    public AnswersService(AppDbContext context) {
        _context = context;
    }

    public async Task<IEnumerable<Answer>> GetOptionsByQuestionId(Guid questionId) {
        return await _context.Answers
            .ToListAsync();
    }    

    public async Task<Answer> CreateOption(Answer option) {
        var record = _context.Add(option);
        await _context.SaveChangesAsync();
        return record.Entity;
    }    

    public async  Task<bool> DeleteQuestion(Guid questionId) {
        var question = await _context.Questions.FindAsync(questionId);

        if (question == null) {
            return false;
        }

        _context.Questions.Remove(question);
       return await _context.SaveChangesAsync() > 1;
    }
}