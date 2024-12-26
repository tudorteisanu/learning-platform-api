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
public class ContentController : ControllerBase
{
    private readonly ILessonService _lessonService;
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public ContentController(
        ILessonService lessonService,
        IMapper mapper,
        AppDbContext context)
    {
        _lessonService = lessonService;
        _mapper = mapper;
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Content>>> GetLessonsById([FromQuery] int? lessonId)
    {   var query = _context.Contents.AsQueryable();

        if (lessonId != null) {
            query = query.Where(item => item.LessonId == lessonId);
        }
        
         var content = await query.ToListAsync();

        return Ok(content);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLessonContent(ContentDTO lessonDto)
    {
        var lesson = _mapper.Map<Content>(lessonDto);
        _context.Add(lesson);
       
        await _context.SaveChangesAsync();
       
        return Ok(lesson);
    }

    [HttpPatch("{lessonContentId}")]
    public async Task<IActionResult> UpdateLesson(int lessonContentId, ContentPatchDTO lessonContentDto)
    {
        var content = await _context.Contents.FindAsync(lessonContentId);

        if (content == null) {
            return NotFound(new {Message = "Lesson content not found."});
        }
        
         _mapper.Map(lessonContentDto, content);
        await _context.SaveChangesAsync();
        return Ok(content);
    }


    [HttpDelete("{lessonContentId}")]
    public async Task<IActionResult> AddLessonContent(int lessonContentId)
    {
        var lessonContent = await _context.Contents.FindAsync(lessonContentId);

        if (lessonContent == null) {
            return NotFound(new {Message = "Lesson not found."});
        }
        
        _context.Remove(lessonContent);
        await _context.SaveChangesAsync();
        return Ok();
    }
}

