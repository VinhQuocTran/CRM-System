using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRM.Models;

public partial class DemoContext : DbContext
{
    public DemoContext()
    {
    }

    public DemoContext(DbContextOptions<DemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerMarketingCampaign> CustomerMarketingCampaigns { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<LeadOppurtunity> LeadOppurtunities { get; set; }

    public virtual DbSet<LeadStage> LeadStages { get; set; }

    public virtual DbSet<LeadStatus> LeadStatuses { get; set; }

    public virtual DbSet<LostReason> LostReasons { get; set; }

    public virtual DbSet<MarketingCampaign> MarketingCampaigns { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Pipeline> Pipelines { get; set; }

    public virtual DbSet<PipelineStage> PipelineStages { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<SalesTeam> SalesTeams { get; set; }

    public virtual DbSet<Source> Sources { get; set; }

    public virtual DbSet<Stage> Stages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MAY-B246;Initial Catalog=demo;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__customer__3213E83FC2660370");

            entity.ToTable("customer");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.BuyRank).HasColumnName("buy_rank");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("full_name");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.IsCompany).HasColumnName("is_company");
            entity.Property(e => e.Phone)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<CustomerMarketingCampaign>(entity =>
        {
            entity.HasKey(e => new { e.CustomerId, e.MarketingCampaignId }).HasName("PK__customer__FDB22FE1807D6B99");

            entity.ToTable("customer_marketing_campaign");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("customer_id");
            entity.Property(e => e.MarketingCampaignId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("marketing_campaign_id");
            entity.Property(e => e.Channel)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("channel");
            entity.Property(e => e.SentDate)
                .HasColumnType("date")
                .HasColumnName("sent_date");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerMarketingCampaigns)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK-customer-customer_marketing_campaign");

            entity.HasOne(d => d.MarketingCampaign).WithMany(p => p.CustomerMarketingCampaigns)
                .HasForeignKey(d => d.MarketingCampaignId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK-marketing_campaign-customer_marketing_campaign");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__employee__3213E83F96860CFD");

            entity.ToTable("employee");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.AcccountPassword)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("acccount_password");
            entity.Property(e => e.AccountName)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("account_name");
            entity.Property(e => e.AccountRole)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("account_role");
            entity.Property(e => e.Address)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("full_name");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.HireDate)
                .HasColumnType("date")
                .HasColumnName("hire_date");
            entity.Property(e => e.Phone)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.SalesTeamId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("sales_team_id");

            entity.HasOne(d => d.SalesTeam).WithMany(p => p.Employees)
                .HasForeignKey(d => d.SalesTeamId)
                .HasConstraintName("FK-sales_team-employee2");
        });

        modelBuilder.Entity<LeadOppurtunity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__lead_opp__3213E83F6C4EDE15");

            entity.ToTable("lead_oppurtunity");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateEmployeeId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("create_employee_id");
            entity.Property(e => e.ExpectedClosingDate)
                .HasColumnType("datetime")
                .HasColumnName("expected_closing_date");
            entity.Property(e => e.ExpectedRevenue).HasColumnName("expected_revenue");
            entity.Property(e => e.MarketingCampaignId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("marketing_campaign_id");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.SourceId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("source_id");
            entity.Property(e => e.Urgency).HasColumnName("urgency");
        });

        modelBuilder.Entity<LeadStage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__lead_sta__3213E83FED657D69");

            entity.ToTable("lead_stage");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreateEmployeeId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("create_employee_id");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.LeadOppurtunityId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("lead_oppurtunity_id");
            entity.Property(e => e.StageId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("stage_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");
        });

        modelBuilder.Entity<LeadStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__lead_sta__3213E83F73FB1577");

            entity.ToTable("lead_status");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.LostReasonId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("lost_reason_id");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.LostReason).WithMany(p => p.LeadStatuses)
                .HasForeignKey(d => d.LostReasonId)
                .HasConstraintName("FK-lost_reason-lead_status2");
        });

        modelBuilder.Entity<LostReason>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__lost_rea__3213E83FA8206727");

            entity.ToTable("lost_reason");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<MarketingCampaign>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__marketin__3213E83F5CAC9530");

            entity.ToTable("marketing_campaign");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__order__3213E83FB16337D8");

            entity.ToTable("order");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("customer_id");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("employee_id");
            entity.Property(e => e.LeadStatusId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("lead_status_id");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("order_date");
            entity.Property(e => e.ShipAddress)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("ship_address");
            entity.Property(e => e.ShipDate)
                .HasColumnType("datetime")
                .HasColumnName("ship_date");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK-customer-order2");

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK-employee-order2");

            entity.HasOne(d => d.LeadStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.LeadStatusId)
                .HasConstraintName("FK-lead_status-order2");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__order_it__3213E83F6362C1A3");

            entity.ToTable("order_item");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.DiscountPercent)
                .HasColumnType("decimal(3, 0)")
                .HasColumnName("discount_percent");
            entity.Property(e => e.OrderId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("order_id");
            entity.Property(e => e.ProductId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
        });

        modelBuilder.Entity<Pipeline>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pipeline__3213E83F5E2814DD");

            entity.ToTable("pipeline");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<PipelineStage>(entity =>
        {
            entity.HasKey(e => new { e.PipelineId, e.StageId }).HasName("PK__pipeline__E3E0C4458DC78AE8");

            entity.ToTable("pipeline_stage");

            entity.Property(e => e.PipelineId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("pipeline_id");
            entity.Property(e => e.StageId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("stage_id");
            entity.Property(e => e.StageOrder).HasColumnName("stage_order");

            entity.HasOne(d => d.Pipeline).WithMany(p => p.PipelineStages)
                .HasForeignKey(d => d.PipelineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK-pipeline-pipeline_stage");

            entity.HasOne(d => d.Stage).WithMany(p => p.PipelineStages)
                .HasForeignKey(d => d.StageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK-stage-pipeline_stage");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product__3213E83F15AF00A9");

            entity.ToTable("product");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Unit)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("unit");
            entity.Property(e => e.UnitInStock).HasColumnName("unit_in_stock");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("unit_price");
        });

        modelBuilder.Entity<SalesTeam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sales_te__3213E83F5CDBCE23");

            entity.ToTable("sales_team");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PipelineId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("pipeline_id");
            entity.Property(e => e.RevenueTarget).HasColumnName("revenue_target");
            entity.Property(e => e.TeamLeaderId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("team_leader_id");

            entity.HasOne(d => d.Pipeline).WithMany(p => p.SalesTeams)
                .HasForeignKey(d => d.PipelineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK-pipeline-sales_team2");

            entity.HasOne(d => d.TeamLeader).WithMany(p => p.SalesTeams)
                .HasForeignKey(d => d.TeamLeaderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK-employee-sales_team2");
        });

        modelBuilder.Entity<Source>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__source__3213E83FE97C6DDC");

            entity.ToTable("source");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Stage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__stage__3213E83FA091AB28");

            entity.ToTable("stage");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
