namespace SchoolWebAPI.Domain.IServices
{
    using SchoolWebAPI.Domain.Entities.Generic;
    using SchoolWebAPI.Domain.Models;

    /// <summary>
    /// Student service interface
    /// </summary>
    public interface IStudentService
    {
        /// <summary>
        /// Gets the student by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Result<Student>> GetStudentById(int id);

        /// <summary>
        /// Gets all students.
        /// </summary>
        /// <returns></returns>
        Task<Result<List<Student>>> GetAllStudents();

        /// <summary>
        /// Deletes the student.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Result> DeleteStudent(Student student);

        /// <summary>
        /// Creates the student.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns></returns>
        Task<Result> CreateStudent(Student student);

        /// <summary>
        /// Updates the student.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns></returns>
        Task<Result> UpdateStudent(Student student);
    }
}
