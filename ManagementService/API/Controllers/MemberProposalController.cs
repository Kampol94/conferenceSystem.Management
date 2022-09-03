using Microsoft.AspNetCore.Mvc;
using ManagementService.Application.Members.CreateMember;

namespace ManagementService.API.Controllers;

public class MemberController : BaseApiController
{
    [HttpPost("")]
    //public from user service
    public async Task<ActionResult> CreateMember([FromBody] CreateMemberCommand command, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }
}
