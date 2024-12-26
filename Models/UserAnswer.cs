using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Models;

[PrimaryKey(nameof(QuestionId), nameof(UserId), nameof(AnswerId))]
public class UserAnswer
{
    [Key, Column(Order = 0)]
    public int QuestionId { get; set; }
    [JsonIgnore]
    [ForeignKey(nameof(QuestionId))]
    public Question? Question { get; set; }
    
    [Key, Column(Order = 1)]
    public int UserId { get; set; }
    [JsonIgnore]
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
    
    [Key, Column(Order = 2)]
    public int AnswerId { get; set; }
    [JsonIgnore]
    [ForeignKey(nameof(AnswerId))]
    public Answer? Answer { get; set; }
}