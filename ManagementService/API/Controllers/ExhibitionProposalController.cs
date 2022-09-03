using Microsoft.AspNetCore.Mvc;
using ManagementService.Application.ExhibitionProposals.RequestExhibitionProposalVerification;
using ManagementService.Application.ExhibitionProposals.GetExhibitionProposal;
using ManagementService.Application.ExhibitionProposals.GetExhibitionProposals;
using ManagementService.Application.ExhibitionProposals.AcceptExhibitionProposal;

namespace ManagementService.API.Controllers;

public class ExhibitionProposalController : BaseApiController
{
    [HttpPost("")]
    //public from event service
    public async Task<ActionResult> RequestExhibitionProposalsVerification([FromBody] RequestExhibitionProposalsVerificationCommand command, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }

    [HttpGet("")]
    [ProducesResponseType(typeof(List<ExhibitionProposalsDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetExhibitionProposal()
    {
        return Ok(await Mediator.Send(new GetExhibitionProposalssQuery()));
    }

    [HttpPatch("{meetingGroupProposalId}/accept")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AcceptExhibitionProposal(Guid meetingGroupProposalId)
    {
        return Ok(await Mediator.Send(new AcceptExhibitionProposalsCommand(meetingGroupProposalId)));
    }
}
