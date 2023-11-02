using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class Pipeline
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<PipelineStage> PipelineStages { get; set; } = new List<PipelineStage>();

    public virtual ICollection<SalesTeam> SalesTeams { get; set; } = new List<SalesTeam>();
}
