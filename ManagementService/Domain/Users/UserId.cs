using ManagementService.Domain.Contracts;

namespace ManagementService.Domain.Users;

public class UserId : IdValueBase
{
    public UserId(Guid value)
        : base(value)
    {
    }
}