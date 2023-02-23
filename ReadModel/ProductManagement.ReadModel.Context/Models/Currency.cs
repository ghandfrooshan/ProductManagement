using System;
using System.Collections.Generic;

namespace ProductManagement.ReadModel.Context.Models;

public partial class Currency
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ProductPrice? ProductPrice { get; set; }
}
