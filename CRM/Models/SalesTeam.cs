using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class SalesTeam
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public int? RevenueTarget { get; set; }

    public string TeamLeaderId { get; set; } = null!;

    public string PipelineId { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Pipeline Pipeline { get; set; } = null!;

    public virtual Employee TeamLeader { get; set; } = null!;
}
