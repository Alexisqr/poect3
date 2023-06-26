using System;
using System.Collections.Generic;

namespace ShelterDAL.Models;

public partial class VolontersGood
{
    public int Id { get; set; }

    public int Idvolonter { get; set; }

    public int Idgood { get; set; }

    public DateTime? Date { get; set; }

    public virtual Good IdgoodNavigation { get; set; } = null!;

    public virtual Volonter IdvolonterNavigation { get; set; } = null!;
}
