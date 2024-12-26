using LearningPlatform.Models;

namespace LearningPlatform.DTO;

public class LessonResponseDTO {
    public int Id { get; set; }
    public int CourseId { get; set; }
    public string Title { get; set; } = string.Empty;
    public ICollection<Content> Content { get; set; } = new List<Content>();
}