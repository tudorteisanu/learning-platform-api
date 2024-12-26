using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningPlatform.Models;

public class Question
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int LessonId { get; set; }
    [JsonIgnore]
    public Lesson? Lesson { get; set; }
    public string QuestionText { get; set; } = string.Empty;
    public int? CorrectAnswer { get; set; }
    public ICollection<Answer> Answers {get; set; } = new List<Answer>();
}