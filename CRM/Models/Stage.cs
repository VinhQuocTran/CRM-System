using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class Stage
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<LeadStage> LeadStages { get; set; } = new List<LeadStage>();

    public virtual ICollection<PipelineStage> PipelineStages { get; set; } = new List<PipelineStage>();
}
