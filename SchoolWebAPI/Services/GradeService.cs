namespace SchoolWebAPI.Services
{
    using SchoolWebAPI.Domain.Entities.Generic;
    using SchoolWebAPI.Domain.IRepository;
    using SchoolWebAPI.Domain.IServices;
    using SchoolWebAPI.Domain.Models;
    using SchoolWebAPI.DTO;
    using SchoolWebAPI.Persistence.Repositories;

    public class GradeService : IGradeService
    {
        public readonly IGradeRepository _gradeRepository;

        public GradeService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public async Task<Result> AddStudentGrade(int idGrade, List<int> listStudents)
        {
            try
            {
                /*var studentgrade = await this.GetStudentsByGrade(idGrade);

                if (!studentgrade.IsSuccess)
                    return Result.Failure(studentgrade.ErrorMessage);

                var listStudentUpdate = studentgrade*/

                await _gradeRepository.AddStudentGrade(idGrade, listStudents);
                
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error adding students to grade: {ex.Message}");
            }
        }

        public async Task<Result> CreateGrade(Grade grade)
        {
            try
            {
                await _gradeRepository.CreateGrade(grade);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error creting grade: {ex.Message}");
            }
        }

        public async Task<Result> DeleteGrade(Grade grade)
        {
            try
            {
                await _gradeRepository.DeleteGrade(grade);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error deleting grade: {ex.Message}");
            }
        }

        public async Task<Result> DeleteStudentGrade(int idGrade, List<int> listStudents)
        {
            try
            {
                await _gradeRepository.UpdateStudentGrade(idGrade, listStudents, false);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error deleting students to grade: {ex.Message}");
            }
        }

        public async Task<Result<List<Grade>>> GetAllGrades()
        {
            try
            {
                var grades = await _gradeRepository.GetAllGrades();

                if (grades == null)
                    return Result<List<Grade>>.Failure("No Grades");

                return Result<List<Grade>>.Success(grades);
            }
            catch (Exception ex)
            {
                return Result<List<Grade>>.Failure($"Error getting Grades: {ex.Message}");
            }
        }

        public async Task<Result<Grade>> GetGradeByid(int id)
        {
            try
            {
                var grade = await _gradeRepository.GetGradeByid(id);

                if (grade == null)
                    return Result<Grade>.Failure("No Grade info");

                return Result<Grade>.Success(grade);
            }
            catch (Exception ex)
            {
                return Result<Grade>.Failure($"Error getting Grade: {ex.Message}");
            }
        }

        public async Task<Result<GradeStudentDTO>> GetStudentsByGrade(int id)
        {
            try
            {
                var students = await _gradeRepository.GetStudentsByGrade(id);

                if (students == null)
                    return Result<GradeStudentDTO>.Failure("No students info");

                return Result<GradeStudentDTO>.Success(students);
            }
            catch (Exception ex)
            {
                return Result<GradeStudentDTO>.Failure($"Error getting students: {ex.Message}");
            }
        }

        public async Task<Result> UpdateGrade(Grade grade)
        {
            try
            {
                await _gradeRepository.UpdateGrade(grade);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error updating grade: {ex.Message}");
            }
        }
    }
}
