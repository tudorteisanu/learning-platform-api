namespace LearningPlatform.DTO;

public class LessonContentPatchDTO {
    
    public ICollection<LessonContentDTO> Content { get; set; } = new List<LessonContentDTO>();
}