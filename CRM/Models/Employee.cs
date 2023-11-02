using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class Employee
{
    public string Id { get; set; } = null!;

    public string? FullName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public bool? Gender { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? AccountName { get; set; }

    public string? AcccountPassword { get; set; }

    public string? AccountRole { get; set; }

    public int? Salary { get; set; }

    public DateTime? HireDate { get; set; }

    public string? SalesTeamId { get; set; }

    public virtual ICollection<LeadOppurtunity> LeadOppurtunities { get; set; } = new List<LeadOppurtunity>();

    public virtual ICollection<LeadStage> LeadStages { get; set; } = new List<LeadStage>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual SalesTeam? SalesTeam { get; set; }

    public virtual ICollection<SalesTeam> SalesTeams { get; set; } = new List<SalesTeam>();
}
