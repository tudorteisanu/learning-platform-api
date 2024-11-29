using System.Security.Claims;
using LearningPlatform.Data;
using LearningPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Services;

public interface IUserService
{
    Task<bool> RegisterUserAsync(User user);
    Task<User?> GetUserByIdAsync(Guid userId);
    public Guid GetCurrentUserId();
}

public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> RegisterUserAsync(User user)
        {
            user.Id = Guid.NewGuid();
            user.CreatedAt = DateTime.UtcNow;

            _context.Users.Add(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User?> GetUserByIdAsync(Guid userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }
    
        public Guid GetCurrentUserId() {
            var userId = _httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId != null) {
                 return new Guid(userId);
            }
           
           return Guid.Empty;
        }
    }