using LearningPlatform.Data;
using LearningPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Services;

public interface ILessonService
{
    Task<Lesson?> GetLessonsByIdAsync(Guid lessonId);
    Task<IEnumerable<Question>> GetLessonsQuestionsAsync(Guid lessonId);
    PaginatedList<Lesson> GetAllLessons(PaginationQueryParamsDTO paginationParams);
    Task<bool> CreateLessonAsync(Lesson lesson);
}

public class LessonService : ILessonService
    {
        private readonly AppDbContext _context;

        public LessonService(AppDbContext context)
        {
            _context = context;
        }

        public PaginatedList<Lesson> GetAllLessons(PaginationQueryParamsDTO paginationParams) {
            var query = _context.Lessons
                            .Include(l => l.Questions.Where(q => q.Answers.Count() > 0))
                            .ThenInclude(q => q.Answers);

            return new PaginatedList<Lesson>(query, paginationParams);
        }

        public async Task<Lesson?> GetLessonsByIdAsync(Guid lessonId)
        {
            return await _context.Lessons
                .Include(l => l.Content)
                .Include(l => l.Questions.Where(q => q.Answers.Count() > 0))
                .ThenInclude(q => q.Answers)
                .Where(l => l.Id == lessonId)
                .SingleAsync();
        }

        public async Task<IEnumerable<Question>> GetLessonsQuestionsAsync(Guid lessonId)
        {
            return await _context.Questions
                .Include(q => q.Answers)
                .Where(q => q.LessonId == lessonId)
                .ToListAsync();
        }

        public async Task<bool> CreateLessonAsync(Lesson lesson)
        {
            lesson.Id = Guid.NewGuid();
            _context.Lessons.Add(lesson);
            return await _context.SaveChangesAsync() > 0;
        }
    }