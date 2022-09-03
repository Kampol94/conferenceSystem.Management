using ManagementService.Domain.Contracts;

namespace ManagementService.Domain.ExhibitionProposals;

public class ExhibitionProposalsStatus : ValueObject
{
    private ExhibitionProposalsStatus(string value)
    {
        Value = value;
    }

    public static ExhibitionProposalsStatus ToVerify => new ExhibitionProposalsStatus("ToVerify");

    public static ExhibitionProposalsStatus Verified => new ExhibitionProposalsStatus("Verified");

    public string Value { get; }

    public static ExhibitionProposalsStatus Create(string value)
    {
        return new ExhibitionProposalsStatus(value);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value; 
    }
}