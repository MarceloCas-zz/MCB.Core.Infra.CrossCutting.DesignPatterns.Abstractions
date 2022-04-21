namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Observer
{
    public interface ISubscriber<in TSubject>
    {
        // Properties
        Type SubjectType { get; }

        // Methods
        Task HandlerAsync(TSubject subject, CancellationToken cancellationToken);
    }
}
