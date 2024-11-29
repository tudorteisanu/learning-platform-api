using LearningPlatform.Enum;

namespace LearningPlatform.Models;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string? Role { get; set; } = UserRole.User.ToString();
    public string? AvatarUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public ICollection<UserProgress> Progress { get; set; } = new List<UserProgress>();
}