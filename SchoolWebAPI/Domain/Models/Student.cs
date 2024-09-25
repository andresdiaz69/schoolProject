using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SchoolWebAPI.Domain.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public byte IdGender { get; set; }

    public DateTime DateOfBirth { get; set; }

    public bool Active { get; set; }

    [JsonIgnore]
    public virtual ICollection<GradeStudent> GradeStudents { get; set; } = new List<GradeStudent>();

    [JsonIgnore]
    public virtual Gender? IdGenderNavigation { get; set; }
}
