using System;
using System.Collections.Generic;

namespace ShelterDAL.Models;

public partial class Good
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int NameKind { get; set; }

    public int? Price { get; set; }

    public virtual ICollection<ComentGood> ComentGoods { get; set; } = new List<ComentGood>();

    public virtual KindOfGood NameKindNavigation { get; set; } = null!;

    public virtual ICollection<VolontersGood> VolontersGoods { get; set; } = new List<VolontersGood>();
}
