using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningPlatform.Models;

public class Lesson
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    [JsonIgnore]
    public Course? Course { get; set; } 
    public string Title { get; set; } = string.Empty;
    public ICollection<Question> Questions { get; set; } = new List<Question>();
    public ICollection<LessonContent> Content { get; set; } = new List<LessonContent>();
}