using ManagementService.Application.Contracts.Commands;
using ManagementService.Domain.ExhibitionProposals;
using ManagementService.Domain.Users;

namespace ManagementService.Application.ExhibitionProposals.RequestExhibitionProposalVerification;

public class RequestExhibitionProposalsVerificationCommandHandler :
    ICommandHandler<RequestExhibitionProposalsVerificationCommand, Guid>
{
    private readonly IExhibitionProposalsRepository _exhibitionProposalsRepository;

    public RequestExhibitionProposalsVerificationCommandHandler(IExhibitionProposalsRepository exhibitionProposalsRepository)
    {
        _exhibitionProposalsRepository = exhibitionProposalsRepository;
    }

    public async Task<Guid> Handle(RequestExhibitionProposalsVerificationCommand request, CancellationToken cancellationToken)
    {
        var exhibitionProposals = ExhibitionProposal.CreateToVerify(
            request.ExhibitionProposalsId,
            request.Name,
            request.Description,
            new UserId(request.ProposalUserId),
            request.ProposalDate);

        await _exhibitionProposalsRepository.AddAsync(exhibitionProposals);

        return exhibitionProposals.Id.Value;
    }
}