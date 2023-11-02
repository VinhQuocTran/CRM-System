using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class Customer
{
    public string Id { get; set; } = null!;

    public string? FullName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public bool? Gender { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public bool? IsCompany { get; set; }

    public int? BuyRank { get; set; }

    public DateTime? CreateDate { get; set; }

    public virtual ICollection<CustomerMarketingCampaign> CustomerMarketingCampaigns { get; set; } = new List<CustomerMarketingCampaign>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
