using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningPlatform.Models;

public class UserAchievement
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    [JsonIgnore]
    public User User { get; set; }
    public Guid AchievementId { get; set; }
    public virtual Achievement Achievement { get; set; }
    public DateTime UnlockedAt { get; set; }
}
