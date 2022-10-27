using ManagementService.Application.Contracts;

namespace ManagementService.Infrastructure.Services;
public interface IEventBus
{
    void Publish<T>(T @event) where T : IntegrationEvent;
    void Subscribe<U>(IServiceProvider services) where U : IntegrationEvent;
    void Consume();
}