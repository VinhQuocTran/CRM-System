using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class LeadOppurtunity
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public int? Urgency { get; set; }

    public int? ExpectedRevenue { get; set; }

    public DateTime? ExpectedClosingDate { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? SourceId { get; set; }

    public string CreateEmployeeId { get; set; } = null!;

    public string? MarketingCampaignId { get; set; }
}
