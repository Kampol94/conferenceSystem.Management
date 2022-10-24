using Microsoft.AspNetCore.Mvc;
using ManagementService.Application.ExhibitionProposals.GetExhibitionProposal;
using ManagementService.Application.ExhibitionProposals.GetExhibitionProposals;
using ManagementService.Application.ExhibitionProposals.AcceptExhibitionProposal;

namespace ManagementService.API.Controllers;

public class ExhibitionProposalController : BaseApiController
{
    [HttpGet("")]
    [ProducesResponseType(typeof(List<ExhibitionProposalDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetExhibitionProposals()
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
