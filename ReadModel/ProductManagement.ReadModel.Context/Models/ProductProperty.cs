using System;
using System.Collections.Generic;

namespace ProductManagement.ReadModel.Context.Models;

public partial class ProductProperty
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public int PropertyId { get; set; }

    public string Value { get; set; } = null!;

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public bool IsActive { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Property Property { get; set; } = null!;
}
