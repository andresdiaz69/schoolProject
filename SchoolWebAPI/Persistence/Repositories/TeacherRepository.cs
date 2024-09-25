namespace SchoolWebAPI.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using SchoolWebAPI.Domain.IRepository;
    using SchoolWebAPI.Domain.Models;
    using SchoolWebAPI.Persistence.Context;

    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolDbContext _context;

        public TeacherRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task CreateTeacher(Teacher teacher)
        {
            await this._context.Teachers.AddAsync(teacher);
            await this._context.SaveChangesAsync();
        }

        public async Task DeleteTeacher(Teacher teacher)
        {
            teacher.Active = false;

            this._context.Entry(teacher).State = EntityState.Modified;

            await this._context.SaveChangesAsync();
        }

        public async Task<List<Teacher>> GetAllTeachers()
        {
            return await this._context.Teachers.Where(t => t.Active).ToListAsync();
        }

        public async Task<Teacher> GetTeacherByid(int id)
        {
            var teacher = await this._context.Teachers
                .Where(t => t.Id == id && t.Active).FirstOrDefaultAsync();

            return teacher;
        }

        public async Task UpdateTecher(Teacher teacher)
        {
            this._context.Teachers.Update(teacher);
            await this._context.SaveChangesAsync();
        }
    }
}
