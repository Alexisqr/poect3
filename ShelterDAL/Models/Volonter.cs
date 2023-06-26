using System;
using System.Collections.Generic;

namespace ShelterDAL.Models;

public partial class Volonter
{
    public int Idvolonters { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNamber { get; set; }

    public string? EMail { get; set; }

    public string? Role { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<ComentGlob> ComentGlobs { get; set; } = new List<ComentGlob>();

    public virtual ICollection<ComentGood> ComentGoods { get; set; } = new List<ComentGood>();

    public virtual ICollection<ComentKindAnimal> ComentKindAnimals { get; set; } = new List<ComentKindAnimal>();

    public virtual ICollection<VolontersAnimal> VolontersAnimals { get; set; } = new List<VolontersAnimal>();

    public virtual ICollection<VolontersGood> VolontersGoods { get; set; } = new List<VolontersGood>();
}
