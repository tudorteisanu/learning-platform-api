using AutoMapper;
using BCrypt.Net;
using LearningPlatform.DTO;
using LearningPlatform.Models;

public class PasswordHashResolver : IValueResolver<RegisterDTO, User, string>
{
    public string Resolve(RegisterDTO source, User destination, string destMember, ResolutionContext context)
    {
        // Hash the password using BCrypt
        return BCrypt.Net.BCrypt.HashPassword(source.Password);
    }
}
