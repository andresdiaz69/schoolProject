namespace SchoolWebAPI.Domain.IRepository
{
    using SchoolWebAPI.Domain.Models;
    using SchoolWebAPI.DTO;

    public interface IGradeRepository
    {
        // Grade
        Task CreateGrade(Grade grade);

        Task<List<Grade>> GetAllGrades();

        Task UpdateGrade(Grade grade);

        Task DeleteGrade(Grade grade);

        Task<Grade> GetGradeByid(int id);

        // Grade - Estudent
        Task<GradeStudentDTO> GetStudentsByGrade(int id);

        Task AddStudentGrade(int idGrade, List<int> listStudents);
        Task UpdateStudentGrade(int idGrade, List<int> listStudents, bool active);

    }
}
