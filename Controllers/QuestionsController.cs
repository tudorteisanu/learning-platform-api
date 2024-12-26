using Microsoft.AspNetCore.Mvc;
using LearningPlatform.Models;
using LearningPlatform.Services;
using Microsoft.AspNetCore.Authorization;
using LearningPlatform.DTO;
using AutoMapper;
using LearningPlatform.Data;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class QuestionsController : ControllerBase
{
    private readonly IQuestionsService _questionsService;
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public QuestionsController(
        IQuestionsService questionsService,
        IMapper mapper,
        AppDbContext context
        )
    {
        _questionsService = questionsService;
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuestionResponseDTO>>> GetQuestionsByLesson([FromQuery] int lessonId)
    {
         var questions = await _context.Questions
            .Where(l => l.LessonId == lessonId)
            .Include(q => q.Answers)
            .ToListAsync();

        return questions.Select(_mapper.Map<QuestionResponseDTO>).ToList();
    }

    [HttpPost]
    public async Task<IActionResult> CreateQuestion(QuestionDTO questionDTO)
    {
        var question = _mapper.Map<Question>(questionDTO);

        _context.Questions.Add(question);

        await _context.SaveChangesAsync();
       
        return Ok(question);
    }

    [HttpPost("{questionId}/answer")]
    public async Task<IActionResult> Answer(int questionId, QuestionAnswerDTO dto)
    {   
        var userId = 1;
        
        var isRecordExists = await _context.UserAnswers
            .Where(ua => ua.QuestionId == questionId)
            .Where(ua => ua.UserId == userId)
            .SingleOrDefaultAsync();

        if (isRecordExists != null) {
            return BadRequest(new { Message = "Question already answered!" });
        }

        var record = new UserAnswer { AnswerId = dto.AnswerId, QuestionId = questionId, UserId = userId };
        _context.Add(record);
        await _context.SaveChangesAsync();
       
        return Ok( new { userAnswer = record.AnswerId, Id = record.QuestionId });
    }

    [HttpPatch("{questionId}")]
    public async Task<ActionResult<QuestionResponseDTO>> Update(int questionId, QuestionPatchTO dto)
    {
        var question = await _context.Questions
            .Include(q => q.Answers)
            .Where(q=> q.Id == questionId)
            .SingleOrDefaultAsync();

        if (question == null) {
            return NotFound(new { Message = "Question not found."});
        }

         _mapper.Map(dto, question);

        await _context.SaveChangesAsync();

        return Ok(_mapper.Map<QuestionResponseDTO>(question));
    }

    [HttpDelete("{questionId}")]
    public async Task<IActionResult> Delete(int questionId) {
        var question = await _context.Questions
            .Where(q => q.Id == questionId)
            .SingleOrDefaultAsync();
           
        if (question == null) {
            return NotFound(new { Message = "Question not found."});
        }

        var questionAnswers = _context.UserAnswers.Where(ua => ua.QuestionId == question.Id);

        _context.RemoveRange(questionAnswers);
        _context.Remove(question);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Successfull deleted" });
    }
}

