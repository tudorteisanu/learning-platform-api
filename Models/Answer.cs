using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningPlatform.Models;

public class Answer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;

    [JsonIgnore]
    public ICollection<Question> Questions {get; set; } = new List<Question>();
}