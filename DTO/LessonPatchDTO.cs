namespace LearningPlatform.DTO;

public class LessonPatchDTO {
    public string? Title { get; set; }

    public ICollection<ContentDTO> Content { get; set; } = new List<ContentDTO>();
}