using System.Text.Json.Serialization;

namespace LearningPlatform.Models;

public class Question
{
    public Guid Id { get; set; }
    public Guid LessonId { get; set; }

    [JsonIgnore]
    public Lesson? Lesson { get; set; }
    public string QuestionText { get; set; } = string.Empty;
    public Guid? CorrectAnswer { get; set; }
    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
}