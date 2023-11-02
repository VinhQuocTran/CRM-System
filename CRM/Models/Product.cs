using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class Product
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? Unit { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? UnitInStock { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
