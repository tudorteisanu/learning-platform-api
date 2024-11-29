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
    public ActionResult<IEnumerable<Lesson>> GetAllLessons([FromQuery] PaginationQueryParamsDTO paginationQueryParams)
    {
        var lesson = _lessonService.GetAllLessons(paginationQueryParams);
        
        if (lesson == null) {
            return NotFound("Lesson not Found");
        }

        return Ok(lesson);
    }


    [HttpGet("{lessonId}")]
    public async Task<ActionResult<IEnumerable<Lesson>>> GetLessonsById(Guid lessonId)
    {
        var lesson = await _lessonService.GetLessonsByIdAsync(lessonId);
        
        if (lesson == null) {
            return NotFound("Lesson not Found");
        }

        return Ok(lesson);
    }


    [HttpPost]
    public async Task<IActionResult> CreateLesson(LessonDTO lessonDto)
    {
        var lesson = _mapper.Map<Lesson>(lessonDto);
        var result = await _lessonService.CreateLessonAsync(lesson);
       
        if (!result)
        {
            return BadRequest("Failed to create lesson.");
        }
       
        return Ok("Lesson created successfully.");
    }

    [HttpPatch("{lessonId}")]
    public async Task<IActionResult> UpdateLesson(Guid lessonId, PatchLessonDTO lessonDto)
    {
        var lesson = await _context.Lessons
            .Where(l => l.Id == lessonId)
            .SingleAsync();

        if (lesson == null) {
            return NotFound("Lesson not found.");
        }
        
         _mapper.Map(lessonDto, lesson);
        await _context.SaveChangesAsync();
        return Ok(lesson);
    }
}

