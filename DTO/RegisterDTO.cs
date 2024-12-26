using System.ComponentModel.DataAnnotations;
using LearningPlatform.Enum;

namespace LearningPlatform.DTO;

public class RegisterDTO {
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    [EnumDataType(typeof(UserRole))]
    public string? Role { get; set; }
}