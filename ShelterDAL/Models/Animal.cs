using System;
using System.Collections.Generic;

namespace ShelterDAL.Models;

public partial class Animal
{
    public int Idanimal { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public int Kind { get; set; }

    public string? Gender { get; set; }

    public virtual KindOfAnimal KindNavigation { get; set; } = null!;

    public virtual VolontersAnimal? VolontersAnimal { get; set; }
}
