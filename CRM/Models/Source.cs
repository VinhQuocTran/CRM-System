using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class Source
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<LeadOppurtunity> LeadOppurtunities { get; set; } = new List<LeadOppurtunity>();
}
