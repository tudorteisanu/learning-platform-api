using System.Text.Json.Serialization;

namespace LearningPlatform.Models;

public class UserAnswer
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    [JsonIgnore]
    public Question? Question { get; set; }
    public Guid UserId { get; set; }
    [JsonIgnore]
    public User? User { get; set; }
    public Guid AnswerId { get; set; }
    [JsonIgnore]
    public Answer? Answer { get; set; }
}