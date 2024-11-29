namespace LearningPlatform.DTO;

public class LessonContentDTO {
    public Guid LessonId {get; set; }
    public string Type { get; set; }
    public string Data { get; set; }
    public int? Position { get; set; }
}