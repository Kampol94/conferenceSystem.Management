using ManagementService.Domain.Contracts;
using ManagementService.Domain.Users;

namespace ManagementService.Domain.ExhibitionProposals;

public class ExhibitionProposalsDecision : ValueObject
{
    private ExhibitionProposalsDecision(DateTime? date, UserId? userId, string? code, string? rejectReason)
    {
        Date = date;
        UserId = userId;
        Code = code;
        RejectReason = rejectReason;
    }

    public DateTime? Date { get; }

    public UserId? UserId { get; }

    public string? Code { get; }

    public string? RejectReason { get; }

    public static ExhibitionProposalsDecision NoDecision =>
        new(null, null, null, null);

    private bool IsAccepted => Code == "Accept";

    private bool IsRejected => Code == "Reject";

    public static ExhibitionProposalsDecision AcceptDecision(DateTime date, UserId userId)
    {
        return new ExhibitionProposalsDecision(date, userId, "Accept", null);
    }

    public static ExhibitionProposalsDecision RejectDecision(DateTime date, UserId userId, string rejectReason)
    {
        return new ExhibitionProposalsDecision(date, userId, "Reject", rejectReason);
    }

    public ExhibitionProposalsStatus GetStatusForDecision()
    {
        if (IsAccepted)
        {
            return ExhibitionProposalsStatus.Verified;
        }

        if (IsRejected)
        {
            return ExhibitionProposalsStatus.Create("Rejected");
        }

        return ExhibitionProposalsStatus.ToVerify;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Date;
        yield return UserId;
        yield return Code;
        yield return RejectReason;
    }
}