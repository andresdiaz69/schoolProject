namespace SchoolWebAPI.Services
{
    using SchoolWebAPI.Domain.Entities.Generic;
    using SchoolWebAPI.Domain.IRepository;
    using SchoolWebAPI.Domain.IServices;
    using SchoolWebAPI.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repository;

        public TeacherService(ITeacherRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> CreateTeacher(Teacher teacher)
        {
            try
            {
                await _repository.CreateTeacher(teacher);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error creating teacher: { ex.Message }");
            }
        }

        public async Task<Result> DeleteTeacher(Teacher teacher)
        {
            try
            {
                await _repository.DeleteTeacher(teacher);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error deleting teacher: {ex.Message}");
            }
        }

        public async Task<Result<List<Teacher>>> GetAllTeachers()
        {
            try
            {
                var teachers = await _repository.GetAllTeachers();

                if (teachers == null)
                    return Result<List<Teacher>>.Failure("No teachers info");

                return Result<List<Teacher>>.Success(teachers);
            }
            catch (Exception ex)
            {
                return Result<List<Teacher>>.Failure($"Error getting teachers:  {ex.Message}");
            }
        }

        public async Task<Result<Teacher>> GetTeacherById(int id)
        {
            try
            {
                var teacher = await _repository.GetTeacherByid(id);

                if (teacher == null)
                    return Result<Teacher>.Failure("No teachers found");

                return Result<Teacher>.Success(teacher);
            }
            catch (Exception ex)
            {
                return Result<Teacher>.Failure($"Error getting teacher: {ex.Message} ");
            }
        }

        public async Task<Result> UpdateTeacher(Teacher teacher)
        {
            try
            {
                await _repository.UpdateTecher(teacher);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error updating teacher + {ex.Message}");
            }
        }
    }
}
