using System;
using System.Collections.Generic;

namespace SportsApi.Database;

public partial class Person
{
    public int PersonId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public bool IsAuthorised { get; set; }

    public bool IsValid { get; set; }

    public bool IsEnabled { get; set; }

    public virtual ICollection<Sport> Sports { get; init; } = new List<Sport>();
}
