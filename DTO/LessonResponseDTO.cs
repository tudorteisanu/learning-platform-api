using LearningPlatform.Models;

namespace LearningPlatform.DTO;

public class LessonResponseDTO {
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public string Title { get; set; } = string.Empty;
    public ICollection<QuestionResponseDTO> Questions { get; set; } = new List<QuestionResponseDTO>();
    public ICollection<LessonContent> Content { get; set; } = new List<LessonContent>();
}