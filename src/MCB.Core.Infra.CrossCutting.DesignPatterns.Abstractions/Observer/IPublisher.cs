using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Observer;

namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Mediator
{
    public interface IPublisher
    {
        void Subscribe<TSubscriber, TSubject>() where TSubscriber : ISubscriber<TSubject>;
        void Publish<TSubject>(TSubject subject);
    }
}
