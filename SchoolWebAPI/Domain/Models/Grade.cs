using System;
using System.Collections.Generic;

namespace SchoolWebAPI.Domain.Models;

public partial class Grade
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdTeacher { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<GradeStudent> GradeStudents { get; set; } = new List<GradeStudent>();

    public virtual Teacher IdTeacherNavigation { get; set; } = null!;
}
