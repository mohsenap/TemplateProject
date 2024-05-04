using TemplateProject.Shared.Events;

namespace TemplateProject.Application.Common.Events;

public interface IEventPublisher : ITransientService
{
    Task PublishAsync(IEvent @event);
}