using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class PipelineStage
{
    public string PipelineId { get; set; } = null!;

    public string StageId { get; set; } = null!;

    public int? StageOrder { get; set; }

    public virtual Pipeline Pipeline { get; set; } = null!;

    public virtual Stage Stage { get; set; } = null!;
}
