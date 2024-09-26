namespace SchoolWebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SchoolWebAPI.Domain.IServices;
    using SchoolWebAPI.Domain.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Grade grade)
        {
            try
            {
                grade.Active = true;

                var result = await _gradeService.CreateGrade(grade);

                if (result.IsSuccess)
                    return Ok(new { message = "Grade created!" });
                else return BadRequest(result.ErrorMessage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Grade grade)
        {
            try
            {
                var result = await _gradeService.UpdateGrade(grade);

                if (result.IsSuccess)
                    return Ok(new { message = "Grade updated!" });
                else return BadRequest(result.ErrorMessage);
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
                var grade = await _gradeService.GetGradeByid(id);

                if (!grade.IsSuccess)
                    return BadRequest(grade.ErrorMessage);

                var result = await _gradeService.DeleteGrade(grade.Value);

                if (result.IsSuccess)
                    return Ok(new { message = "Grade deleted!" });
                else return BadRequest(result.ErrorMessage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetAllGrades")]
        [HttpGet]
        public async Task<ActionResult> GetAllGrades()
        {
            try
            {
                var listGrades = await _gradeService.GetAllGrades();

                if (!listGrades.IsSuccess)
                    return BadRequest(listGrades.ErrorMessage);


                return Ok(listGrades.Value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var grade = await _gradeService.GetGradeByid(id);

                if (!grade.IsSuccess)
                    return BadRequest(grade.ErrorMessage);


                return Ok(grade.Value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetStudentByGradeId/{id}")]
        public async Task<ActionResult> GetStudentByGradeId(int id)
        {
            try
            {
                var students = await _gradeService.GetStudentsByGrade(id);

                if (!students.IsSuccess)
                    return BadRequest(students.ErrorMessage);


                return Ok(students.Value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        //[Route("AddStudents")]
        [HttpPost("AddStudents/{id}")]
        public async Task<ActionResult> AddStudents(int id, [FromBody] List<int> studentsId)
        {
            try
            {
                var students = await _gradeService.AddStudentGrade(id, studentsId);

                if (!students.IsSuccess)
                    return BadRequest(students.ErrorMessage);


                return Ok(new { message = "Students added!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[Route("DeleteStudents")]
        [HttpDelete("DeleteStudents/{id}")]
        public async Task<ActionResult> DeleteStudents(int id, [FromBody] List<int> studentsId)
        {
            try
            {
                var students = await _gradeService.DeleteStudentGrade(id, studentsId);

                if (!students.IsSuccess)
                    return BadRequest(students.ErrorMessage);


                return Ok(new { message = "Students deleted!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
