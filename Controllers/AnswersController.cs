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
public class AnswersController : ControllerBase {
    private readonly IAnswersService _answersService;
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public AnswersController(
        IAnswersService answersService,
         IMapper mapper,
         AppDbContext context
         ) {
        _answersService = answersService;
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Answer>>> GetOptionsByQuestionId() {
        var answers = await _context.Answers.ToListAsync();
 
        return Ok(answers);
    }

    [HttpPost]
    public async Task<ActionResult<Answer>> CreateOption(AnswerDTO optionDto) {
        var option = _mapper.Map<Answer>(optionDto);
        return Ok(await _answersService.CreateOption(option));
    }

    [HttpDelete("{answerId}")]
    public async Task<ActionResult> CreateOption(int answerId) {
        var answer = await _context.Answers.FindAsync(answerId);

        if (answer == null) {
            return NotFound(new {Message = "Answer not Found"});
        }

        _context.Remove(answer);
        await _context.SaveChangesAsync();

        return Ok();
    }

     [HttpPatch("{optionId}")]
    public async Task<IActionResult> CreateLesson(int optionId, AnswerPatchDTO dto)
    {
        var option = await _context.Answers.FindAsync(optionId);

        if (option == null) {
            return NotFound(new {Message = "Answer not Found"});
        }
        
         _mapper.Map(dto, option);
        await _context.SaveChangesAsync();
        return Ok(option);
    }
}