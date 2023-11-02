using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class LeadStatus
{
    public string Id { get; set; } = null!;

    public bool? Status { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? LostReasonId { get; set; }

    public virtual LeadOppurtunity IdNavigation { get; set; } = null!;

    public virtual LostReason? LostReason { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
