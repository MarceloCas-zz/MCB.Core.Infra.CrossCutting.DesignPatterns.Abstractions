namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Observer
{
    public interface ISubscriber<in TSubject>
    {
        // Methods
        Task HandlerAsync(TSubject subject, CancellationToken cancellationToken);
    }
}
