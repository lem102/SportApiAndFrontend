using System;
using System.Collections.Generic;

namespace SportsApi.Models;

public partial class Person
{
    public int Personid { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public bool IsAuthorised { get; set; }

    public bool IsValid { get; set; }

    public bool IsEnabled { get; set; }

    public virtual ICollection<Sport> Sports { get; } = new List<Sport>();
}
