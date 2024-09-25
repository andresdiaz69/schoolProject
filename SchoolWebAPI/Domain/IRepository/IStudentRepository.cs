namespace SchoolWebAPI.Domain.IRepository
{
    using SchoolWebAPI.Domain.Entities.Generic;
    using SchoolWebAPI.Domain.Models;

    /// <summary>
    /// Student Repository Interface
    /// </summary>
    public interface IStudentRepository
    {
        /// <summary>
        /// Gets the student by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Student> GetStudentById(int id);

        /// <summary>
        /// Gets all students.
        /// </summary>
        /// <returns></returns>
        Task<List<Student>> GetAllStudents();

        /// <summary>
        /// Deletes the student.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task DeleteStudent(Student student);

        /// <summary>
        /// Creates the student.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns></returns>
        Task CreateStudent(Student student);

        /// <summary>
        /// Updates the student.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns></returns>
        Task UpdateStudent(Student student);

    }
}
