namespace SchoolWebAPI.Services
{
    using SchoolWebAPI.Domain.Entities.Generic;
    using SchoolWebAPI.Domain.IRepository;
    using SchoolWebAPI.Domain.IServices;
    using SchoolWebAPI.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentService"/> class.
        /// </summary>
        /// <param name="studentRepository">The student repository.</param>
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// Creates the student.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<Result> CreateStudent(Student student)
        {
            try
            {
                await _studentRepository.CreateStudent(student);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error creating student: { ex.Message }");
            }
        }

        /// <summary>
        /// Deletes the student.
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<Result> DeleteStudent(Student student)
        {
            try
            {
                await _studentRepository.DeleteStudent(student);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error deleting student: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets all students.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<Student>>> GetAllStudents()
        {
            try
            {
                var students = await _studentRepository.GetAllStudents();
                
                if (students == null)
                    return Result<List<Student>>.Failure("No students");

                return Result<List<Student>>.Success(students);
            }
            catch (Exception ex)
            {
                return Result<List<Student>>.Failure($"Error getting student: {ex.Message}");
            }

        }

        /// <summary>
        /// Gets the student by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Result<Student>> GetStudentById(int id)
        {
            try
            {
                var student = await _studentRepository.GetStudentById(id);

                if (student == null)
                    return Result<Student>.Failure("No students");

                return Result<Student>.Success(student);
            }
            catch (Exception ex)
            {
                return Result<Student>.Failure($"Error getting student: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates the student.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns></returns>
        public async Task<Result> UpdateStudent(Student student)
        {
            try
            {
                await _studentRepository.UpdateStudent(student);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error updating student: {ex.Message}");
            }
        }
    }
}
