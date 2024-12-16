using LearningPlatform.Models;

namespace LearningPlatform.DTO;

public class QuestionDTO {
    public Guid LessonId { get; set; }
    public string QuestionText { get; set; } = string.Empty;
    public Guid? CorrectAnswer { get; set; }
    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
}