namespace SchoolWebAPI.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using SchoolWebAPI.Domain.IRepository;
    using SchoolWebAPI.Domain.Models;
    using SchoolWebAPI.DTO;
    using SchoolWebAPI.Persistence.Context;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GradeRepository : IGradeRepository
    {
        private readonly SchoolDbContext _context;

        public GradeRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task CreateGrade(Grade grade)
        {
            await this._context.Grades.AddAsync(grade);
            await this._context.SaveChangesAsync();
        }
        public async Task DeleteGrade(Grade grade)
        {
            grade.Active = false;

            this._context.Entry(grade).State =
                EntityState.Modified;

            await this._context.SaveChangesAsync();
        }

        public async Task AddStudentGrade(int idGrade, List<int> listStudents)
        {
            listStudents.ForEach(student =>
            {
                this._context.GradeStudents.Add(new GradeStudent
                {
                    IdGrade = idGrade,
                    IdStudent = student,
                    Active = true,
                    Group = ""
                });
            });

            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudentGrade(int idGrade, List<int> listStudents, bool active)
        {
            var studentsGrade = this._context.GradeStudents
                .Where(x => listStudents.Contains(x.IdStudent)
                       && x.IdGrade == idGrade)
                .ToList();

            studentsGrade.ForEach(x=> x.Active = active);

            //_context.GradeStudents.RemoveRange(studentsGrade);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Grade>> GetAllGrades()
        {
            return await this._context.Grades.Where(x =>
               x.Active).ToListAsync();
        }

        public async Task<Grade> GetGradeByid(int id)
        {
            var grade = await this._context.Grades.Where(x =>
              x.Active && x.Id == id ).FirstOrDefaultAsync();

            return grade;
        }

        public async Task<GradeStudentDTO> GetStudentsByGrade(int id)
        {
            var grade = await this._context.Grades
                .Include(gs => gs.GradeStudents)
                .ThenInclude(s => s.IdStudentNavigation)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (grade == null) return null;

            var gradeStudentsDTO = new GradeStudentDTO()
            {
                id_grade = id,
                listStudents = grade.GradeStudents
                .Select(x => x.IdStudentNavigation).ToList()
            };

            return gradeStudentsDTO;
        }

        public async Task UpdateGrade(Grade grade)
        {
            this._context.Grades.Update(grade);
            await this._context.SaveChangesAsync();
        }
    }
}
