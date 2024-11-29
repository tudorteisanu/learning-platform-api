using Microsoft.AspNetCore.Mvc;
using LearningPlatform.Models;
using LearningPlatform.Services;
using Microsoft.AspNetCore.Authorization;

namespace LearningPlatform.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public ActionResult<PaginatedList<Course>> GetAllCourses([FromQuery] PaginationQueryParamsDTO paginationQuery)
    {
        return Ok(_courseService.GetAllCoursesAsync(paginationQuery));
    }

    [HttpGet("{courseId}/lessons")]
    public async Task<ActionResult<IEnumerable<Course>>> GetCourseLessons(Guid courseId)
    {
        return Ok(await _courseService.GetCourseLessonsAsync(courseId));
    }

    [HttpGet("{courseId}")]
    public async Task<IActionResult> GetCourseByid(Guid courseId)
    {
        return Ok( await _courseService.GetCourseByIdAsync(courseId));
    }
}
