namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Observer;

public interface IPublisher
{
    void Subscribe<TSubscriber, TSubject>() where TSubscriber : ISubscriber<TSubject>;
    Task PublishAsync<TSubject>(TSubject subject, CancellationToken cancellationToken);
}
