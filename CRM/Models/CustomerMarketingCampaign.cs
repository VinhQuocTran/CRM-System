using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class CustomerMarketingCampaign
{
    public string CustomerId { get; set; } = null!;

    public string MarketingCampaignId { get; set; } = null!;

    public DateTime? SentDate { get; set; }

    public string? Channel { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual MarketingCampaign MarketingCampaign { get; set; } = null!;
}
