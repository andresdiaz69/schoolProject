using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SchoolWebAPI.Domain.Models;

public partial class Grade
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdTeacher { get; set; }

    public bool Active { get; set; }

    [JsonIgnore]
    public virtual ICollection<GradeStudent> GradeStudents { get; set; } = new List<GradeStudent>();

    [JsonIgnore]
    public virtual Teacher? IdTeacherNavigation { get; set; } 
}
