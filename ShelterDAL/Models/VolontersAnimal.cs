using System;
using System.Collections.Generic;

namespace ShelterDAL.Models;

public partial class VolontersAnimal
{
    public int Id { get; set; }

    public int Idvolonter { get; set; }

    public int Idanimals { get; set; }

    public DateTime? Date { get; set; }

    public virtual Animal IdanimalsNavigation { get; set; } = null!;

    public virtual Volonter IdvolonterNavigation { get; set; } = null!;
}
