using Codeflix.Catalog.Application.Interfaces;
using Codeflix.Catalog.Domain.Events;
using Codeflix.Catalog.Domain.SeedWork;

namespace Codeflix.Catalog.Application.EventHandlers;
public class SendToEncoderEventHandler : IDomainEventHandler<VideoUploadedEvent>
{
    private readonly IMessageProducer _messageProducer;

    public SendToEncoderEventHandler(IMessageProducer messageProducer)
        => _messageProducer = messageProducer;

    public Task HandleAsync(VideoUploadedEvent domainEvent, CancellationToken cancellationToken)
        => _messageProducer.SendMessageAsync(domainEvent, cancellationToken);
}
