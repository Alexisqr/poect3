using System;
using System.Collections.Generic;

namespace ShelterDAL.Models;

public partial class ComentKindAnimal
{
    public int Id { get; set; }

    public int Idvolonter { get; set; }

    public int IdkindAnimals { get; set; }

    public string? Text { get; set; }

    public DateTime? Date { get; set; }

    public virtual KindOfAnimal IdkindAnimalsNavigation { get; set; } = null!;

    public virtual Volonter IdvolonterNavigation { get; set; } = null!;
}
