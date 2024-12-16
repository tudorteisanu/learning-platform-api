using System.Text.Json.Serialization;

namespace LearningPlatform.Models;

public class Answer
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public ICollection<Question> Questions { set; get; } = new List<Question>();
}