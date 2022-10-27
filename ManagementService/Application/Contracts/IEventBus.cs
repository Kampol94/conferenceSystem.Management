using ManagementService.Application.Contracts;

namespace ManagementService.Infrastructure.Services;
public interface IEventBus
{
    void Publish<T>(T @event) where T : IntegrationEvent;
    void Subscribe<T>(IIntegrationEventHandler<T> handler) where T : IntegrationEvent;
    void Consume();
}