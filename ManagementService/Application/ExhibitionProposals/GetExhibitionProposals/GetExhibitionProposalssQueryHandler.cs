using Dapper;
using ManagementService.Application.Contracts;
using ManagementService.Application.Contracts.Queries;
using ManagementService.Application.ExhibitionProposals.GetExhibitionProposal;

namespace ManagementService.Application.ExhibitionProposals.GetExhibitionProposals;

public class GetExhibitionProposalssQueryHandler : IQueryHandler<GetExhibitionProposalssQuery, List<ExhibitionProposalDto>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetExhibitionProposalssQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<List<ExhibitionProposalDto>> Handle(GetExhibitionProposalssQuery query, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        string sql = "SELECT " +
                     $"[ExhibitionProposal].[Id] AS [{nameof(ExhibitionProposalDto.Id)}], " +
                     $"[ExhibitionProposal].[Name] AS [{nameof(ExhibitionProposalDto.Name)}], " +
                     $"[ExhibitionProposal].[ProposalUserId] AS [{nameof(ExhibitionProposalDto.ProposalUserId)}], " +
                     $"[ExhibitionProposal].[Description] AS [{nameof(ExhibitionProposalDto.Description)}], " +
                     $"[ExhibitionProposal].[ProposalDate] AS [{nameof(ExhibitionProposalDto.ProposalDate)}], " +
                     $"[ExhibitionProposal].[StatusCode] AS [{nameof(ExhibitionProposalDto.StatusCode)}], " +
                     $"[ExhibitionProposal].[DecisionDate] AS [{nameof(ExhibitionProposalDto.DecisionDate)}], " +
                     $"[ExhibitionProposal].[DecisionUserId] AS [{nameof(ExhibitionProposalDto.DecisionUserId)}], " +
                     $"[ExhibitionProposal].[DecisionCode] AS [{nameof(ExhibitionProposalDto.DecisionCode)}], " +
                     $"[ExhibitionProposal].[DecisionRejectReason] AS [{nameof(ExhibitionProposalDto.DecisionRejectReason)}] " +
                     "FROM [management].[ExhibitionProposals] AS [ExhibitionProposal] ";

        return (await connection.QueryAsync<ExhibitionProposalDto>(sql)).AsList();
    }
}