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
    public async Task<ActionResult<IEnumerable<Question>>> GetQuestionsByLesson([FromQuery] Guid lessonId)
    {
        return Ok(await _questionsService.GetQuestionsByLessonIdAsync(lessonId));
    }

    [HttpPost]
    public async Task<IActionResult> CreateQuestion(QuestionDTO questionDTO)
    {
        var question = _mapper.Map<Question>(questionDTO);
        var result = await _questionsService.CreateQuestionAsync(question);
       
        if (!result)
        {
            return BadRequest(new { Message = "Failed to create question." });
        }
       
        return Ok(question);
    }

    [HttpPost("{questionId}/answer")]
    public async Task<IActionResult> Answer(Guid questionId, QuestionAnswerDTO dto)
    {   
        var userId = new Guid("c93cbb80-fbff-45a5-8934-a58813ae42a7");
        
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
       
        return Ok(new { Message = "Success." });
    }

    [HttpPost("{questionId}/add-answer")]
    public async Task<IActionResult> AddAnswer(Guid questionId, AnswerDTO dto)
    {   
        var option = _mapper.Map<Answer>(dto);
        _context.Add(option);
        await _context.SaveChangesAsync();
       
        return Ok(option);
    }

    [HttpPatch("{questionId}")]
    public async Task<IActionResult> UpdateLesson(Guid questionId, QuestionPatchDTO dto)
    {
        var question = await _context.Questions
        .Include(q => q.Answers)
        .Where(q=> q.Id == questionId)
        .SingleAsync();

        if (question == null) {
            return NotFound(new { Message = "Question not found."});
        }

        Console.WriteLine(question.CorrectAnswer);
        
         _mapper.Map(dto, question);
        await _context.SaveChangesAsync();
        return Ok(question);
    }
}

