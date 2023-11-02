using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class LostReason
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<LeadStatus> LeadStatuses { get; set; } = new List<LeadStatus>();
}
