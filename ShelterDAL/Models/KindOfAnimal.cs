using System;
using System.Collections.Generic;

namespace ShelterDAL.Models;

public partial class KindOfAnimal
{
    public int Id { get; set; }

    public string? NameKind { get; set; }

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();

    public virtual ICollection<ComentKindAnimal> ComentKindAnimals { get; set; } = new List<ComentKindAnimal>();
}
