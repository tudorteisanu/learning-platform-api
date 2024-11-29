namespace LearningPlatform.Models;

public class Achievement
{
    
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<UserAchievement> UserAchievements { get; set; } = [];
}