using System.Runtime.Serialization;

namespace LearningPlatform.Enum;

public enum UserRole
{ 
    [EnumMember(Value = "user")]
   User,
   [EnumMember(Value = "admin")]
   Admin,
}