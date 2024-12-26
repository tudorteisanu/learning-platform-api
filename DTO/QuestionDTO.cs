using LearningPlatform.Models;

namespace LearningPlatform.DTO;

public class QuestionDTO {
    public int LessonId { get; set; }
    public string QuestionText { get; set; } = string.Empty;
    public int? CorrectAnswer { get; set; }
    public List<int> Answers { get; set; } = new List<int>();
}