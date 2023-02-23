using System;
using System.Collections.Generic;

namespace ProductManagement.ReadModel.Context.Models;

public partial class Product
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActice { get; set; }

    public int CategoryId { get; set; }

    public virtual ProductCategory Category { get; set; } = null!;

    public virtual ICollection<ProductPrice> ProductPrices { get; } = new List<ProductPrice>();

    public virtual ICollection<ProductProperty> ProductProperties { get; } = new List<ProductProperty>();
}
