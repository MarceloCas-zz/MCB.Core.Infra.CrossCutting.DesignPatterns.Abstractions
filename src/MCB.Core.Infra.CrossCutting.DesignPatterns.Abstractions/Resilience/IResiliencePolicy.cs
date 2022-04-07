using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Resilience.Enums;

namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Resilience
{
    public interface IResiliencePolicy
    {
        // Properties - Identification
        string Name { get; }

        // Properties - Retry
        int RetryMaxAttemptCount { get; }
        Func<int, TimeSpan> RetryAttemptWaitingTimeFunction { get; }
        Action<(Exception exception, TimeSpan retryAttemptWaitingTime)> OnRetryAditionalHandler { get; }

        // Properties - Circuit Breaker
        CircuitState CircuitState { get; }
        int CircuitBreakerOpenCount { get; }
        Func<int, TimeSpan> CircuitBreakerWaitingTimeFunction { get; }
        Action<(Exception exception, TimeSpan circuitBreakerWaitingTime)> OnCircuitBreakerCloseAditionalHandler { get; }
        Action<(Exception exception, TimeSpan circuitBreakerWaitingTime)> OnCircuitBreakerHalfOpenAditionalHandler { get; }
        Action<(Exception exception, TimeSpan circuitBreakerWaitingTime)> OnCircuitBreakerOpenAditionalHandler { get; }
        Action<(Exception exception, TimeSpan circuitBreakerWaitingTime)> OnCircuitBreakerResetOpenAditionalHandler { get; }

        // Methods
        void Config(Func<Exception, bool>[] exceptionHandlerConfigArray);
        
        void CloseCircuitBreakerManually();
        void OpenCircuitBreakerManually();
        Task ExecuteAsync(Func<Task> handler);
    }
}
