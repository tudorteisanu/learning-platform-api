using LearningPlatform.Models;

namespace LearningPlatform.DTO;

public class QuestionPatchTO {
    public string? QuestionText { get; set; }
    public int? CorrectAnswer { get; set; }
    public List<int> Answers { get; set; } = new List<int>();
}