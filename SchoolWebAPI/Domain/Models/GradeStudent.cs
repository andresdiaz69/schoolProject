using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SchoolWebAPI.Domain.Models;

public partial class GradeStudent
{
    public long Id { get; set; }

    public int IdStudent { get; set; }

    public int IdGrade { get; set; }

    public string Group { get; set; } = null!;

    public bool Active { get; set; }

    [JsonIgnore]
    public virtual Grade IdGradeNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual Student IdStudentNavigation { get; set; } = null!;
}
