using Microsoft.EntityFrameworkCore;
using SchoolWebAPI.Domain.Entities.Generic;
using SchoolWebAPI.Domain.IRepository;
using SchoolWebAPI.Domain.Models;
using SchoolWebAPI.Persistence.Context;

namespace SchoolWebAPI.Persistence.Repositories
{
    /// <summary>
    /// Student Repository Class
    /// </summary>
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentRepository"/> class.
        /// </summary>
        /// <param name="schoolDbContext">The school database context.</param>
        public StudentRepository(SchoolDbContext schoolDbContext)
        {
            _context = schoolDbContext;
        }

        /// <summary>
        /// Creates the student.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns></returns>
        public async Task CreateStudent(Student student)
        {
            await this._context.Students.AddAsync(student);
            await this._context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the student.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task DeleteStudent(Student student)
        {
            student.Active = false;
            this._context.Entry(student).State =
                EntityState.Modified;
            await this._context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all students.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Student>> GetAllStudents()
        {
            return await this._context.Students.Where(x =>
                x.Active).ToListAsync();

        }

        /// <summary>
        /// Gets the student by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Student> GetStudentById(int id)
        {
            var student = await this._context.Students.Where(
                    x => x.Active && x.Id == id).FirstOrDefaultAsync();
            return student;
        }

        /// <summary>
        /// Updates the student.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns></returns>
        public async Task UpdateStudent(Student student)
        {
            this._context.Students.Update(student);
            await this._context.SaveChangesAsync();
        }
    }
}
