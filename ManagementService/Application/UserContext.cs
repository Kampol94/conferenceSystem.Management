using ManagementService.Application.Contracts;
using ManagementService.Domain.Users;

namespace ManagementService.Application;
public class UserContext : IUserContext
{
    private readonly IExecutionContextAccessor _executionContextAccessor;

    public UserContext(IExecutionContextAccessor executionContextAccessor)
    {
        this._executionContextAccessor = executionContextAccessor;
    }

    public UserId UserId => new UserId(_executionContextAccessor.UserId);
}
