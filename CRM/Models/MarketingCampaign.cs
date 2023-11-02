using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class MarketingCampaign
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual ICollection<CustomerMarketingCampaign> CustomerMarketingCampaigns { get; set; } = new List<CustomerMarketingCampaign>();

    public virtual ICollection<LeadOppurtunity> LeadOppurtunities { get; set; } = new List<LeadOppurtunity>();
}
