using System.Text.Json.Serialization;

namespace LearningPlatform.Models;

public class LessonContent {
    public Guid Id { get; set; }
    public Guid LessonId { get; set; }
    [JsonIgnore]
    public Lesson? Lesson { get; set; }
    public string? Type { get; set; }
    public int? Position { get; set; }
    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
    public string? Data {get; set;}
}