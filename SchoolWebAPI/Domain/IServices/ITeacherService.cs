namespace SchoolWebAPI.Domain.IServices
{
    using SchoolWebAPI.Domain.Entities.Generic;
    using SchoolWebAPI.Domain.Models;

    public interface ITeacherService
    {
        Task<Result> CreateTeacher(Teacher teacher);
        Task<Result> UpdateTeacher(Teacher teacher);
        Task<Result> DeleteTeacher(Teacher teacher);

        Task<Result<Teacher>> GetTeacherById(int id);

        Task<Result<List<Teacher>>> GetAllTeachers();


    }
}
