using Microsoft.AspNetCore.Mvc;
using LearningPlatform.Models;
using LearningPlatform.Services;
using Microsoft.AspNetCore.Authorization;
using LearningPlatform.DTO;
using AutoMapper;

namespace LearningPlatform.AdminControllers;

[Authorize(Roles = "admin")]
[ApiController]
[Route("/api/admin/courses")]
[ApiExplorerSettings(GroupName = "Admin")]
public class AdminCoursesController : ControllerBase
{
    private readonly ICourseService _courseService;
    private readonly IMapper _mapper;

    public AdminCoursesController(ICourseService courseService, IMapper mapper)
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

    [HttpPost]
    public async Task<IActionResult> CreateCourse(CourseDTO courseDto)
    {
        var course = _mapper.Map<Course>(courseDto);
        var result = await _courseService.CreateCourseAsync(course);

        if (!result)
        {
            return BadRequest("Failed to create course.");
        }

        return Ok("Course created successfully.");
    }

    [HttpPatch("{courseId}")]
    public async Task<IActionResult> UpdateCourse(Guid courseId, CoursePatchDto coursePatchDto)
    {
        var course = await _courseService.GetCourseByIdAsync(courseId);

        if (course == null) {
            return NotFound("Course not found");
        }
        
        _mapper.Map(coursePatchDto, course);

         await _courseService.UpdateCourse(course);

        return Ok("Course updated successfully.");
    }

    [HttpGet("{courseId}")]
    public async Task<IActionResult> GetCourseByid(Guid courseId)
    {
        return Ok( await _courseService.GetCourseByIdAsync(courseId));
    }

    [HttpDelete("{courseId}")]
    public async Task<IActionResult> RemoveCourse(Guid courseId)
    {
        await _courseService.DeleteCourse(courseId);

        return Ok("Course deleted successfully.");
    }
}
