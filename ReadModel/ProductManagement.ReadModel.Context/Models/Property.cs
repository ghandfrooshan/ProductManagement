using System;
using System.Collections.Generic;

namespace ProductManagement.ReadModel.Context.Models;

public partial class Property
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ProductProperty? ProductProperty { get; set; }
}
