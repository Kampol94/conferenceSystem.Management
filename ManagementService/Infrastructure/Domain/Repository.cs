using ManagementService.Domain.Contracts;
using ManagementService.Infrastructure;
using UserService.Application.Contracts;

namespace UserService.Infrastructure.Domain;
public class Repository : IRepository
{
    private readonly ManagementContext _context;

    public Repository(ManagementContext context)
    {
        _context = context;
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public List<BaseEntity> GetEntitiesWithEvents()
    {
        return _context.ChangeTracker
                .Entries<BaseEntity>()
                .Where(x => x.Entity.CountEvents != 0)
                .Select(x => x.Entity)
                .ToList();
    }
}
