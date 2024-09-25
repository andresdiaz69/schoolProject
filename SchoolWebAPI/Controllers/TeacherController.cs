using Microsoft.AspNetCore.Mvc;
using SchoolWebAPI.Domain.IServices;
using SchoolWebAPI.Domain.Models;

namespace SchoolWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        public readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Teacher teacher)
        {
            try
            {
                teacher.Active = true;

                var result = await _teacherService.CreateTeacher(teacher);

                if (result.IsSuccess) 
                    return Ok(new { message = "Teacher created!"});
                else
                    return BadRequest(result.ErrorMessage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var teacher = await _teacherService.GetTeacherById(id);

                if (!teacher.IsSuccess)
                    return BadRequest(teacher.ErrorMessage);

                var result = await _teacherService.DeleteTeacher(teacher.Value);

                if (result.IsSuccess)
                    return Ok(new { message = "Teacher deleted Ok" });
                else
                    return BadRequest($"{result.ErrorMessage}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
