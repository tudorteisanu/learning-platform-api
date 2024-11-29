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

    [HttpGet("{lessonId}")]
    public async Task<ActionResult<IEnumerable<Question>>> GetQuestionsByLesson(Guid lessonId)
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
            return BadRequest("Failed to create question.");
        }
       
        return Ok("Question created successfully.");
    }

    [HttpPatch("{questionId}")]
    public async Task<IActionResult> UpdateLesson(Guid questionId, QuestionPatchDTO dto)
    {
        var question = await _context.Questions
        .Include(q => q.Options)
        .Where(q=> q.Id == questionId)
        .SingleAsync();

        if (question == null) {
            return NotFound("Question not found.");
        }

        Console.WriteLine(question.CorrectAnswer);
        
         _mapper.Map(dto, question);
        await _context.SaveChangesAsync();
        return Ok(question);
    }
}

