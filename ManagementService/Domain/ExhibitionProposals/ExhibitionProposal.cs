using ManagementService.Domain.Contracts;
using ManagementService.Domain.ExhibitionProposals.Events;
using ManagementService.Domain.ExhibitionProposals.Rules;
using ManagementService.Domain.Users;

namespace ManagementService.Domain.ExhibitionProposals;

public class ExhibitionProposal : BaseEntity
{
    private string _name;

    private string _description;

    private DateTime _proposalDate;

    private UserId _proposalUserId;

    private ExhibitionProposalsStatus _status;

    private ExhibitionProposalsDecision _decision;

    private ExhibitionProposal(
        ExhibitionProposalsId id,
        string name,
        string description,
        UserId proposalUserId,
        DateTime proposalDate)
    {
        Id = id;
        _name = name;
        _description = description;
        _proposalUserId = proposalUserId;
        _proposalDate = proposalDate;

        _status = ExhibitionProposalsStatus.ToVerify;
        _decision = ExhibitionProposalsDecision.NoDecision;

        this.AddDomainEvent(new ExhibitionProposalsVerificationRequestedDomainEvent(Id));
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private ExhibitionProposal()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        _decision = ExhibitionProposalsDecision.NoDecision;
    }

    public ExhibitionProposalsId Id { get; private set; }

    public void Accept(UserId userId)
    {
        CheckRule(new ExhibitionProposalsCanBeVerifiedOnceRule(_decision));

        _decision = ExhibitionProposalsDecision.AcceptDecision(DateTime.UtcNow, userId);

        _status = _decision.GetStatusForDecision();

        this.AddDomainEvent(new ExhibitionProposalsAcceptedDomainEvent(Id));
    }

    public void Reject(UserId userId, string rejectReason)
    {
        CheckRule(new ExhibitionProposalsCanBeVerifiedOnceRule(_decision));
        CheckRule(new ExhibitionProposalsRejectionMustHaveAReasonRule(rejectReason));

        _decision = ExhibitionProposalsDecision.RejectDecision(DateTime.UtcNow, userId, rejectReason);

        _status = _decision.GetStatusForDecision();

        this.AddDomainEvent(new ExhibitionProposalsRejectedDomainEvent(Id));
    }

    public static ExhibitionProposal CreateToVerify(
        Guid exhibitionProposalsId,
        string name,
        string description,
        UserId proposalUserId,
        DateTime proposalDate)
    {
        var exhibitionProposals = new ExhibitionProposal(
            new ExhibitionProposalsId(exhibitionProposalsId),
            name,
            description,
            proposalUserId,
            proposalDate);

        return exhibitionProposals;
    }
}
