using LearningPlatform.Models;
using Microsoft.EntityFrameworkCore;
using LearningPlatform.Data;

namespace LearningPlatform.Services;

public interface ICourseService
{
    PaginatedList<Course> GetAllCoursesAsync(PaginationQueryParamsDTO paginationQuery);
    Task<bool> CreateCourseAsync(Course course);
    Task UpdateCourse(Course course);
    Task<IEnumerable<Lesson>> GetCourseLessonsAsync(int courseId);
    Task<Course?> GetCourseByIdAsync(int courseId);
    Task DeleteCourse(int courseId);
}

public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;

        public CourseService(AppDbContext context)
        {
            _context = context;
        }

        public PaginatedList<Course> GetAllCoursesAsync(PaginationQueryParamsDTO paginationQuery)
        {
            var query = _context.Courses.Include(c => c.Lessons).AsQueryable();
            var list = new PaginatedList<Course>(query, paginationQuery);
            return list;
        }

         public async Task<Course?> GetCourseByIdAsync(int courseId) {
            return await _context.Courses
                .Include(c => c.Lessons)
                .Where(c => c.Id == courseId)
                .SingleOrDefaultAsync();
         }

        public async Task<bool> CreateCourseAsync(Course course)
        {
            _context.Courses.Add(course);
            return await _context.SaveChangesAsync() > 0;
        }

         public async Task<IEnumerable<Lesson>> GetCourseLessonsAsync(int courseId)
        {
            return await _context.Lessons
                .Where(l => l.CourseId == courseId)
                // .Where(l => l.Content.Count() > 0)
                .ToListAsync();
        }

        public async Task UpdateCourse(Course course) {
             _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        public async  Task DeleteCourse(int courseId) {
            var course = await _context.Courses.FindAsync(courseId);

            _context.Courses.Remove(course!);

            await _context.SaveChangesAsync();
        }
    }