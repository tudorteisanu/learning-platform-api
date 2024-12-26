using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningPlatform.Models;

public class Content {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int LessonId { get; set; }
    [JsonIgnore]
    public Lesson? Lesson { get; set; }
    public string? Type { get; set; }
    public int? Position { get; set; }
    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
    public string? Data {get; set;}
}