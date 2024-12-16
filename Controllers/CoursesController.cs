using Microsoft.AspNetCore.Mvc;
using LearningPlatform.Models;
using LearningPlatform.Services;
using Microsoft.AspNetCore.Authorization;
using LearningPlatform.DTO;
using AutoMapper;

namespace LearningPlatform.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;
    private readonly IMapper _mapper;

    public CoursesController(
        ICourseService courseService,
        IMapper mapper
        )
    {
        _courseService = courseService;
        _mapper = mapper;
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
        var course = await _courseService.GetCourseByIdAsync(courseId);

        if (course == null) {
            return NotFound();
        }

        return Ok(_mapper.Map<CourseResponseDTO>(course));
    }
}
