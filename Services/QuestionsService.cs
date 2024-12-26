using LearningPlatform.Data;
using LearningPlatform.DTO;
using LearningPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Services;

public interface IQuestionsService
{
    Task<bool> CreateQuestionAsync(Question question);
}

public class QuestionsService : IQuestionsService
    {
        private readonly AppDbContext _context;

        public QuestionsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateQuestionAsync(Question question)
        {
            _context.Questions.Add(question);
            return await _context.SaveChangesAsync() > 0;
        }        
    }