using ManagementService.Application.Contracts.Commands;
using ManagementService.Domain.ExhibitionProposals;
using ManagementService.Domain.Users;
using MediatR;

namespace ManagementService.Application.ExhibitionProposals.AcceptExhibitionProposal;

public class AcceptExhibitionProposalsCommandHandler : ICommandHandler<AcceptExhibitionProposalsCommand>
{
    private readonly IExhibitionProposalsRepository _exhibitionProposalsRepository;
    private readonly IUserContext _userContext;

    public AcceptExhibitionProposalsCommandHandler(IExhibitionProposalsRepository exhibitionProposalsRepository, IUserContext userContext)
    {
        _exhibitionProposalsRepository = exhibitionProposalsRepository;
        _userContext = userContext;
    }

    public async Task<Unit> Handle(AcceptExhibitionProposalsCommand request, CancellationToken cancellationToken)
    {
        var exhibitionProposals = await _exhibitionProposalsRepository.GetByIdAsync(new ExhibitionProposalsId(request.ExhibitionProposalsId));

        exhibitionProposals.Accept(_userContext.UserId);

        return Unit.Value;
    }
}