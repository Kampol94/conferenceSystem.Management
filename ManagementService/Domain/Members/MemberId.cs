using ManagementService.Domain.Contracts;

namespace ManagementService.Domain.Members;

public class MemberId : IdValueBase
{
    public MemberId(Guid value)
        : base(value)
    {
    }
}