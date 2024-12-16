namespace LearningPlatform.DTO;

public class CourseResponseDTO
{    
    public Guid Id { get; set; }
    public string Language { get; set; } = string.Empty;
    public string Level { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<LessonListResponseDTO> Lessons { get; set; } = new List<LessonListResponseDTO>();
}
