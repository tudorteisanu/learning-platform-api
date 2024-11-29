using Microsoft.AspNetCore.Mvc;
using LearningPlatform.Models;
using LearningPlatform.Services;
using Microsoft.AspNetCore.Authorization;
using LearningPlatform.DTO;
using AutoMapper;
using LearningPlatform.Data;

namespace LearningPlatform.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class LessonsContentController : ControllerBase
{
    private readonly ILessonService _lessonService;
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public LessonsContentController(
        ILessonService lessonService,
        IMapper mapper,
        AppDbContext context)
    {
        _lessonService = lessonService;
        _mapper = mapper;
        _context = context;
    }


    [HttpGet("{lessonContentId}")]
    public async Task<ActionResult<IEnumerable<Lesson>>> GetLessonsById(Guid lessonContentId)
    {
        var lesson = await _lessonService.GetLessonsByIdAsync(lessonContentId);
        
        if (lesson == null) {
            return NotFound("Lesson not Found");
        }

        return Ok(lesson);
    }


    [HttpPost]
    public async Task<IActionResult> CreateLessonContent(LessonContentDTO lessonDto)
    {
        var lesson = _mapper.Map<LessonContent>(lessonDto);
        _context.Add(lesson);
       
        await _context.SaveChangesAsync();
       
        return Ok("Lesson created successfully.");
    }

    [HttpPatch("{lessonContentId}")]
    public async Task<IActionResult> UpdateLesson(Guid lessonContentId, LessonContentPatchDTO lessonContentDto)
    {
        var lessonContent = await _context.LessonContent.FindAsync(lessonContentId);

        if (lessonContent == null) {
            return NotFound("Lesson content not found.");
        }
        
         _mapper.Map(lessonContentDto, lessonContent);
        await _context.SaveChangesAsync();
        return Ok(lessonContent);
    }


    [HttpDelete("{lessonContentId}")]
    public async Task<IActionResult> AddLessonContent(Guid lessonContentId)
    {
        var lessonContent = await _context.LessonContent.FindAsync(lessonContentId);

        if (lessonContent == null) {
            return NotFound("Lesson not found.");
        }
        
        _context.Remove(lessonContent);
        await _context.SaveChangesAsync();
        return Ok();
    }
}

