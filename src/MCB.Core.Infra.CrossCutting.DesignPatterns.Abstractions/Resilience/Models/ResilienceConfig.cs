namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Resilience.Models
{
    public class ResilienceConfig
    {
        // Constants
        public const string DEFAULT_NAME_PATTERN = "Resilience Policy [{0}]";
        public const int DEFAULT_RETRY_MAX_ATTEMPT_COUNT = 3;
        public const int DEFAULT_RETRY_ATTEMPT_WAITING_TIME_IN_SECONDS = 1;
        public const int DEFAULT_CIRCUIT_BREAKER_WAITING_TIME_IN_SECONDS = 30;

        // Properties - Identification
        /// <summary>
        /// Name of resilience policy. Default value is 'Resilience Policy [GUID]'
        /// </summary>
        public string Name { get; set; }

        // Properties - Retry
        /// <summary>
        /// Max of retry attempt. Default value is 3
        /// </summary>
        public int RetryMaxAttemptCount { get; set; }
        // Properties - Retry
        /// <summary>
        /// Waiting time after attempt failed. Default is 1 second per attempt
        /// </summary>
        public Func<int, TimeSpan> RetryAttemptWaitingTimeFunction { get; set; }
        public Action<(Exception exception, TimeSpan retryAttemptWaitingTime)>? OnRetryAditionalHandler { get; set; }

        // Properties - Circuit Breaker
        // Properties - Retry
        /// <summary>
        /// Waiting time after circuit open. Default is 30 seconds
        /// </summary>
        public Func<int, TimeSpan> CircuitBreakerWaitingTimeFunction { get; set; }
        public Action<(Exception exception, TimeSpan circuitBreakerWaitingTime)>? OnCircuitBreakerCloseAditionalHandler { get; set; }
        public Action<(Exception exception, TimeSpan circuitBreakerWaitingTime)>? OnCircuitBreakerHalfOpenAditionalHandler { get; set; }
        public Action<(Exception exception, TimeSpan circuitBreakerWaitingTime)>? OnCircuitBreakerOpenAditionalHandler { get; set; }
        public Action<(Exception exception, TimeSpan circuitBreakerWaitingTime)>? OnCircuitBreakerResetOpenAditionalHandler { get; set; }

        // Constructors
        public ResilienceConfig()
        {
            Name = string.Format(DEFAULT_NAME_PATTERN, Guid.NewGuid());
            RetryMaxAttemptCount = DEFAULT_RETRY_MAX_ATTEMPT_COUNT;
            RetryAttemptWaitingTimeFunction = attempt => TimeSpan.FromSeconds(DEFAULT_RETRY_ATTEMPT_WAITING_TIME_IN_SECONDS);
            CircuitBreakerWaitingTimeFunction = openCount => TimeSpan.FromSeconds(DEFAULT_CIRCUIT_BREAKER_WAITING_TIME_IN_SECONDS);
        }
    }
}
