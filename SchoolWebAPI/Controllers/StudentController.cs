namespace SchoolWebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SchoolWebAPI.Domain.IServices;
    using SchoolWebAPI.Domain.Models;

    /// <summary>
    /// Controller 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentController"/> class.
        /// </summary>
        /// <param name="studentService">The student service.</param>
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Student student)
        {
            try
            {
                student.Active = true;

                var result = await _studentService.CreateStudent(student);

                if (result.IsSuccess)
                    return Ok(new { message = "Student created!" });
                else return BadRequest(result.ErrorMessage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Student student)
        {
            try
            {
                // validate id not null
                // validate if exists user

                var result = await _studentService.UpdateStudent(student);

                if (result.IsSuccess)
                    return Ok(new { message = "Student updated!" });
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

                var student = await _studentService.GetStudentById(id);
                
                if (!student.IsSuccess)
                    return BadRequest(student.ErrorMessage);

                var result = await _studentService.DeleteStudent(student.Value);

                if (result.IsSuccess)
                    return Ok(new { message = "Student deleted!" });
                else return BadRequest(result.ErrorMessage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetAllStudents")]
        [HttpGet]
        public async Task<ActionResult> GetAllStudents()
        {
            try
            {
                var listStudents = await _studentService.GetAllStudents();

                if (!listStudents.IsSuccess)
                    return BadRequest(listStudents.ErrorMessage);


                return Ok(listStudents.Value);
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
                var student = await _studentService.GetStudentById(id);

                if (!student.IsSuccess)
                    return BadRequest(student.ErrorMessage);


                return Ok(student.Value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
