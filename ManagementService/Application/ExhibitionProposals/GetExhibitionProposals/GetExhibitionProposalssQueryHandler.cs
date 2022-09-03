using Dapper;
using ManagementService.Application.Contracts;
using ManagementService.Application.Contracts.Queries;
using ManagementService.Application.ExhibitionProposals.GetExhibitionProposal;

namespace ManagementService.Application.ExhibitionProposals.GetExhibitionProposals;

public class GetExhibitionProposalssQueryHandler : IQueryHandler<GetExhibitionProposalssQuery, List<ExhibitionProposalsDto>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetExhibitionProposalssQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<List<ExhibitionProposalsDto>> Handle(GetExhibitionProposalssQuery query, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        string sql = "SELECT " +
                     $"[ExhibitionProposals].[Id] AS [{nameof(ExhibitionProposalsDto.Id)}], " +
                     $"[ExhibitionProposals].[Name] AS [{nameof(ExhibitionProposalsDto.Name)}], " +
                     $"[ExhibitionProposals].[ProposalUserId] AS [{nameof(ExhibitionProposalsDto.ProposalUserId)}], " +
                     $"[ExhibitionProposals].[Description] AS [{nameof(ExhibitionProposalsDto.Description)}], " +
                     $"[ExhibitionProposals].[ProposalDate] AS [{nameof(ExhibitionProposalsDto.ProposalDate)}], " +
                     $"[ExhibitionProposals].[StatusCode] AS [{nameof(ExhibitionProposalsDto.StatusCode)}], " +
                     $"[ExhibitionProposals].[DecisionDate] AS [{nameof(ExhibitionProposalsDto.DecisionDate)}], " +
                     $"[ExhibitionProposals].[DecisionUserId] AS [{nameof(ExhibitionProposalsDto.DecisionUserId)}], " +
                     $"[ExhibitionProposals].[DecisionCode] AS [{nameof(ExhibitionProposalsDto.DecisionCode)}], " +
                     $"[ExhibitionProposals].[DecisionRejectReason] AS [{nameof(ExhibitionProposalsDto.DecisionRejectReason)}] " +
                     "FROM [management].[v_ExhibitionProposalss] AS [ExhibitionProposals] ";

        return (await connection.QueryAsync<ExhibitionProposalsDto>(sql)).AsList();
    }
}