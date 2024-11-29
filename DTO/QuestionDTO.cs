namespace LearningPlatform.DTO;

public class QuestionDTO {
    public Guid LessonId { get; set; }
    public string QuestionText { get; set; } = string.Empty;
    public Guid? CorrectAnswer { get; set; }
}