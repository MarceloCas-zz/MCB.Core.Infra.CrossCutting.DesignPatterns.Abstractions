using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Resilience.Enums;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Resilience.Models;

namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Resilience
{
    public interface IResiliencePolicy
    {
        // Properties - Identification
        string Name { get; }
        ResilienceConfig ResilienceConfig { get; }

        // Properties - Circuit Breaker
        CircuitState CircuitState { get; }
        int CircuitBreakerOpenCount { get; }

        // Methods
        void Configure(Action<ResilienceConfig> config);
        
        void CloseCircuitBreakerManually();
        void OpenCircuitBreakerManually();
        Task ExecuteAsync(Func<Task> handler);
    }
}
