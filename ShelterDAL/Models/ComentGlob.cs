using System;
using System.Collections.Generic;

namespace ShelterDAL.Models;

public partial class ComentGlob
{
    public int Id { get; set; }

    public int Idvolonter { get; set; }

    public string? Text { get; set; }

    public DateTime? Date { get; set; }

    public virtual Volonter IdvolonterNavigation { get; set; } = null!;
}
