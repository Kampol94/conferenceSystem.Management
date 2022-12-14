using ManagementService.Domain.ExhibitionProposals;
using ManagementService.Domain.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ManagementService.Infrastructure;

public class ManagementContext : DbContext
{
    private readonly ILoggerFactory _loggerFactory;

    public DbSet<ExhibitionProposal> ExhibitionProposals { get; set; }

    public DbSet<Member> Members { get; set; }

    public ManagementContext(DbContextOptions options, ILoggerFactory loggerFactory)
        : base(options)
    {
        _loggerFactory = loggerFactory;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(_loggerFactory).EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }
}