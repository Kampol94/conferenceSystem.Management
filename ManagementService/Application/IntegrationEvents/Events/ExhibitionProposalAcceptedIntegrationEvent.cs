using ManagementService.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementService.Application.IntegrationEvents.Events;
public class ExhibitionProposalAcceptedIntegrationEvent : IntegrationEvent
{
    public ExhibitionProposalAcceptedIntegrationEvent(
            Guid id,
            DateTime occurredOn,
            Guid meetingGroupProposalId)
            : base(id, occurredOn)
    {
        MeetingGroupProposalId = meetingGroupProposalId;
    }

    public Guid MeetingGroupProposalId { get; }
}
