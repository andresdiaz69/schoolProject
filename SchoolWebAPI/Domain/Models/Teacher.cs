using System;
using System.Collections.Generic;

namespace SchoolWebAPI.Domain.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public byte IdGender { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual Gender IdGenderNavigation { get; set; } = null!;
}
