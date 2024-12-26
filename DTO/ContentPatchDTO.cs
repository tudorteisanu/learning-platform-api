namespace LearningPlatform.DTO;

public class ContentPatchDTO {
    
    public ICollection<ContentDTO> Content { get; set; } = new List<ContentDTO>();
}