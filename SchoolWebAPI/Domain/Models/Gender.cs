using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SchoolWebAPI.Domain.Models;

public partial class Gender
{
    public byte Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    [JsonIgnore]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [JsonIgnore]
    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
