using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class OrderItem
{
    public string Id { get; set; } = null!;

    public int? Quantity { get; set; }

    public decimal? DiscountPercent { get; set; }

    public string OrderId { get; set; } = null!;

    public string ProductId { get; set; } = null!;
}
