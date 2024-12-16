namespace LearningPlatform.DTO;

public class LessonPatchDTO {
    public string? Title { get; set; }

    public ICollection<LessonContentDTO> Content { get; set; } = new List<LessonContentDTO>();
}