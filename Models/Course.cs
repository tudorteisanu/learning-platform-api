using System.Text.Json.Serialization;

namespace LearningPlatform.Models;

public class Course
{
    public Guid Id { get; set; }
    public string Language { get; set; } = string.Empty;
    public string Level { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    [JsonIgnore]
    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}