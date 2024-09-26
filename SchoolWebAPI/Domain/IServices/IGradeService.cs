using SchoolWebAPI.Domain.Entities.Generic;
using SchoolWebAPI.Domain.Models;
using SchoolWebAPI.DTO;

namespace SchoolWebAPI.Domain.IServices
{
    public interface IGradeService
    {
        // Grade
        Task<Result> CreateGrade(Grade grade);

        Task<Result<List<Grade>>> GetAllGrades();

        Task<Result> UpdateGrade(Grade grade);

        Task<Result> DeleteGrade(Grade grade);

        Task<Result<Grade>> GetGradeByid(int id);

        // Grade - Estudent
        Task<Result<GradeStudentDTO>> GetStudentsByGrade(int id);

        Task<Result> AddStudentGrade(int idGrade, List<int> listStudents);
        Task<Result> DeleteStudentGrade(int idGrade, List<int> listStudents);
    }
}
