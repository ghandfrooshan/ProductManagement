using System;
using System.Collections.Generic;

namespace ProductManagement.ReadModel.Context.Models;

public partial class ProductCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual Product? Product { get; set; }
}
