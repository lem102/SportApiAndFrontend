using System;
using System.Collections.Generic;

namespace SportsApi.Database;

public partial class Sport
{
    public int SportId { get; set; }

    public string Name { get; set; } = null!;

    public bool IsEnabled { get; set; }

    public virtual ICollection<Person> People { get; init; } = new List<Person>();
}
