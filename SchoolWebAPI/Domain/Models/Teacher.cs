using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SchoolWebAPI.Domain.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public byte IdGender { get; set; }

    public bool Active { get; set; }

    [JsonIgnore]
    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    [JsonIgnore]
    public virtual Gender? IdGenderNavigation { get; set; }
}
