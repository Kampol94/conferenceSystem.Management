using Microsoft.AspNetCore.Mvc;
using ManagementService.Application.ExhibitionProposals.GetExhibitionProposal;
using ManagementService.Application.ExhibitionProposals.GetExhibitionProposals;
using ManagementService.Application.ExhibitionProposals.AcceptExhibitionProposal;
using Microsoft.AspNetCore.Authorization;

namespace ManagementService.API.Controllers;

public class ExhibitionProposalController : BaseApiController
{
    [HttpGet("")]
    [Authorize]
    [ProducesResponseType(typeof(List<ExhibitionProposalDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetExhibitionProposals()
    {
        return Ok(await Mediator.Send(new GetExhibitionProposalssQuery()));
    }

    [HttpPatch("{meetingGroupProposalId}/accept")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Authorize]
    public async Task<IActionResult> AcceptExhibitionProposal(Guid meetingGroupProposalId)
    {
        return Ok(await Mediator.Send(new AcceptExhibitionProposalsCommand(meetingGroupProposalId)));
    }
}
