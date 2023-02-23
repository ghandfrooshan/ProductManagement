using System;
using System.Collections.Generic;

namespace ProductManagement.ReadModel.Context.Models;

public partial class ProductPrice
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public double Price { get; set; }

    public int CurrencyId { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public virtual Currency Currency { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
