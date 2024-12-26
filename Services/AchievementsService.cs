using LearningPlatform.Data;
using LearningPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Services
{
    public interface IAchievementsService
    {
        Task<IEnumerable<Achievement>> GetUserAchievementsAsync(int userId);
    }

    public class AchievementsService : IAchievementsService
    {
        private readonly AppDbContext _context;

        public AchievementsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Achievement>> GetUserAchievementsAsync(int userId)
        {
            return await _context.UserAchievements
                .Where(ua => ua.UserId == userId)
                .Select(ua => ua.Achievement)
                .ToListAsync();
        }
    }
}
