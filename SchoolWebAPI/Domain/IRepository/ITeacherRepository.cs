using SchoolWebAPI.Domain.Models;

namespace SchoolWebAPI.Domain.IRepository
{
    public interface ITeacherRepository
    {
        Task CreateTeacher(Teacher teacher);

        Task<List<Teacher>> GetAllTeachers();

        Task UpdateTecher(Teacher teacher);

        Task DeleteTeacher(Teacher teacher);

        Task<Teacher> GetTeacherByid(int id);
        

    }
}
