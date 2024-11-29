using System.Text.Json.Serialization;

namespace LearningPlatform.Models;

public class Option
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    [JsonIgnore]
    public Question? Question { get; set; }
    public string OptionText { get; set; } = string.Empty;
}