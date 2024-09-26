namespace SchoolWebAPI.DTO
{
    using SchoolWebAPI.Domain.Models;
    public class GradeStudentDTO
    {
        public int id_grade { get; set; }
        public List<Student> listStudents { get; set; }
    }
}
