namespace LearningPlatform.DTO;

public class LessonListResponseDTO {
    public Guid CourseId { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
}