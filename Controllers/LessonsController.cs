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
public class LessonsController : ControllerBase
{
    private readonly ILessonService _lessonService;
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public LessonsController(
        ILessonService lessonService,
        IMapper mapper,
        AppDbContext context)
    {
        _lessonService = lessonService;
        _mapper = mapper;
        _context = context;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Lesson>> GetAllLessons([FromQuery] PaginationQueryParamsDTO paginationQueryParams, [FromQuery] string? responseType)
    {
        var query = _context.Lessons;

        if (responseType == "short") {
            return Ok(query.ToList().Select(item => _mapper.Map<LessonListResponseDTO>(item)));
        }

        var paginated = new PaginatedList<Lesson>(query, paginationQueryParams);

        return Ok(paginated);
    }


    [HttpGet("{lessonId}")]
    public async Task<ActionResult<IEnumerable<LessonResponseDTO>>> GetLessonsById(int lessonId)
    {
        var lesson = await _lessonService.GetLessonsByIdAsync(lessonId);
        
        if (lesson == null) {
            return NotFound(new { Message = "Lesson not Found" });
        }

        return Ok(_mapper.Map<LessonResponseDTO>(lesson));
    }


    [HttpPost]
    public async Task<IActionResult> CreateLesson(LessonDTO lessonDto)
    {
        var lesson = _mapper.Map<Lesson>(lessonDto);
        var result = await _lessonService.CreateLessonAsync(lesson);
       
        if (!result)
        {
            return BadRequest(new { Message = "Failed to create lesson."});
        }
       
        return Ok(_mapper.Map<LessonListResponseDTO>(lesson));
    }

    [HttpPatch("{lessonId}")]
    public async Task<IActionResult> UpdateLesson(int lessonId, LessonPatchDTO lessonDto)
    {
        var lesson = await _context.Lessons
            .Include(l => l.Content)
            .Include(l => l.Questions)
            .Where(l => l.Id == lessonId)
            .SingleAsync();

        if (lesson == null) {
            return NotFound(new {Message = "Lesson not Found"});
        }
        
         _mapper.Map(lessonDto, lesson);
        await _context.SaveChangesAsync();
        return Ok(lesson);
    }
}

