using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class Order
{
    public string Id { get; set; } = null!;

    public DateTime? OrderDate { get; set; }

    public string? ShipAddress { get; set; }

    public DateTime? ShipDate { get; set; }

    public string CustomerId { get; set; } = null!;

    public string? EmployeeId { get; set; }

    public string? LeadStatusId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Employee? Employee { get; set; }

    public virtual LeadStatus? LeadStatus { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
