using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class LeadStage
{
    public string Id { get; set; } = null!;

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string StageId { get; set; } = null!;

    public string CreateEmployeeId { get; set; } = null!;

    public string LeadOppurtunityId { get; set; } = null!;
}
