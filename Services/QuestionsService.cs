using LearningPlatform.Data;
using LearningPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Services;

public interface IQuestionsService
{
    Task<IEnumerable<Question>> GetQuestionsByLessonIdAsync(Guid lessonId);
    Task<bool> CreateQuestionAsync(Question question);
}

public class QuestionsService : IQuestionsService
    {
        private readonly AppDbContext _context;

        public QuestionsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Question>> GetQuestionsByLessonIdAsync(Guid lessonId)
        {
            return await _context.Questions
                .Include(q => q.Options)
                .Where(l => l.LessonId == lessonId)
                .ToListAsync();
        }

        public async Task<bool> CreateQuestionAsync(Question question)
        {
            question.Id = Guid.NewGuid();
            _context.Questions.Add(question);
            return await _context.SaveChangesAsync() > 0;
        }
    }