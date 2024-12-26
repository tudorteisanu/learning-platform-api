using LearningPlatform.Data;
using LearningPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Services;

public interface ILessonService
{
    Task<Lesson?> GetLessonsByIdAsync(int lessonId);
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
                        .Include(l => l.Questions);

            return new PaginatedList<Lesson>(query, paginationParams);
        }

        public async Task<Lesson?> GetLessonsByIdAsync(int lessonId)
        {
            return await _context.Lessons
                .Where(l => l.Id == lessonId)
                .SingleAsync();
        }

        public async Task<bool> CreateLessonAsync(Lesson lesson)
        {
            _context.Lessons.Add(lesson);
            return await _context.SaveChangesAsync() > 0;
        }
    }