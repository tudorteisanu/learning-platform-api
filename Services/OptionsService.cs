using LearningPlatform.Data;
using LearningPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Services;

public interface IOptionsService {
    Task<IEnumerable<Option>> GetOptionsByQuestionId(Guid questionId);
    Task<Option> CreateOption(Option option);
    Task<bool> DeleteQuestion(Guid questionId);
}

public class OptionsService : IOptionsService {
    private readonly AppDbContext _context;

    public OptionsService(AppDbContext context) {
        _context = context;
    }

    public async Task<IEnumerable<Option>> GetOptionsByQuestionId(Guid questionId) {
        return await _context.Options
            .Where(o => o.QuestionId == questionId)
            .ToListAsync();
    }    

    public async Task<Option> CreateOption(Option option) {
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