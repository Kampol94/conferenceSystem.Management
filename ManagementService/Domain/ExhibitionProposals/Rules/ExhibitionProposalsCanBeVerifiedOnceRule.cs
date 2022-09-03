using ManagementService.Domain.Contracts;

namespace ManagementService.Domain.ExhibitionProposals.Rules;

public class ExhibitionProposalsCanBeVerifiedOnceRule : IBaseBusinessRule
{
    private readonly ExhibitionProposalsDecision _actualDecision;

    public ExhibitionProposalsCanBeVerifiedOnceRule(ExhibitionProposalsDecision actualDecision)
    {
        _actualDecision = actualDecision;
    }

    public string Message => " Exhibition proposal can be verified only once";

    public bool IsBroken() => _actualDecision != ExhibitionProposalsDecision.NoDecision;
}