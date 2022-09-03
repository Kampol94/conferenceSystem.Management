using ManagementService.Domain.Contracts;

namespace ManagementService.Domain.ExhibitionProposals.Rules;

public class ExhibitionProposalsRejectionMustHaveAReasonRule : IBaseBusinessRule
{
    private readonly string _reason;

    public ExhibitionProposalsRejectionMustHaveAReasonRule(string reason)
    {
        _reason = reason;
    }

    public string Message => " Exhibition proposal rejection must have a reason";

    public bool IsBroken() => string.IsNullOrEmpty(_reason);
}