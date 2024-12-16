using LearningPlatform.Models;

namespace LearningPlatform.DTO;

public class QuestionResponseDTO {
    public Guid Id { get; set; }
    public Guid LessonId { get; set; }
    public string QuestionText { get; set; } = string.Empty;
    public Guid? CorrectAnswer { get; set; }
    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    public Guid? UserAnswer { get; set; }
}