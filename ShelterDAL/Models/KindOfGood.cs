using System;
using System.Collections.Generic;

namespace ShelterDAL.Models;

public partial class KindOfGood
{
    public int Id { get; set; }

    public string? NameKind { get; set; }

    public virtual ICollection<Good> Goods { get; set; } = new List<Good>();
}
