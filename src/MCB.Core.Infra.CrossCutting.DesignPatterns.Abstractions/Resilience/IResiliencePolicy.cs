using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Resilience.Enums;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Resilience.Models;

namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Resilience;

public interface IResiliencePolicy
{
    // Properties - Identification
    string Name { get; }
    ResiliencePolicyConfig ResilienceConfig { get; }

    // Properties - Circuit Breaker
    CircuitState CircuitState { get; }
    int CurrentRetryCount { get; }
    int CurrentCircuitBreakerOpenCount { get; }

    // Methods
    void Configure(Func<ResiliencePolicyConfig> configureAction);
    
    void CloseCircuitBreakerManually();
    void OpenCircuitBreakerManually();

    Task<bool> ExecuteAsync(Func<CancellationToken, Task> handler, CancellationToken cancellationToken);
    Task<bool> ExecuteAsync<TInput>(Func<TInput, CancellationToken, Task> handler, TInput input, CancellationToken cancellationToken);
    Task<(bool success, TOutput output)> ExecuteAsync<TInput, TOutput>(Func<TInput, CancellationToken, Task<TOutput>> handler, TInput input, CancellationToken cancellationToken);
}
