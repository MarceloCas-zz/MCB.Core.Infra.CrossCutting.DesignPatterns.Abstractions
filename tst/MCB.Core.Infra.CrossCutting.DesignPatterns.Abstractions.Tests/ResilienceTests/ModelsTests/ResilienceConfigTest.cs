using FluentAssertions;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Resilience.Models;
using System;
using Xunit;

namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Tests.ResilienceTests.ModelsTests
{
    public class ResilienceConfigTest
    {
        [Fact]
        public void ResilienceConfig_Should_Be_Initialized_With_Default_Values()
        {
            // Arrange and Act
            var resilienceConfig = new ResiliencePolicyConfig();

            // Assert
            resilienceConfig.Name.Should().NotBeNullOrEmpty();
            resilienceConfig.RetryMaxAttemptCount.Should().Be(ResiliencePolicyConfig.DEFAULT_RETRY_MAX_ATTEMPT_COUNT);
            resilienceConfig.RetryAttemptWaitingTimeFunction.Should().NotBeNull();
            resilienceConfig.RetryAttemptWaitingTimeFunction(default).Seconds.Should().Be(ResiliencePolicyConfig.DEFAULT_RETRY_ATTEMPT_WAITING_TIME_IN_SECONDS);
            resilienceConfig.OnRetryAditionalHandler.Should().BeNull();
            resilienceConfig.CircuitBreakerWaitingTimeFunction.Should().NotBeNull();
            resilienceConfig.CircuitBreakerWaitingTimeFunction().Seconds.Should().Be(ResiliencePolicyConfig.DEFAULT_CIRCUIT_BREAKER_WAITING_TIME_IN_SECONDS);
            resilienceConfig.OnCircuitBreakerHalfOpenAditionalHandler.Should().BeNull();
            resilienceConfig.OnCircuitBreakerOpenAditionalHandler.Should().BeNull();
            resilienceConfig.OnCircuitBreakerCloseAditionalHandler.Should().BeNull();
            resilienceConfig.ExceptionHandleConfigArray.Should().HaveCount(1);
            resilienceConfig.ExceptionHandleConfigArray[0](new Exception()).Should().BeTrue();
        }

        [Fact]
        public void ResilienceConfig_Should_Be_Correct_Values()
        {
            // Arrange
            var resilienceConfig = new ResiliencePolicyConfig();

            var name = "Resilience Policy Demo";
            var retryMaxAttemptCount = 10;
            var retryAttemptWaitingTimeFunction = new Func<int, TimeSpan>(attempt => TimeSpan.FromSeconds(7));
            var onRetryAditionalHandler = new Action<(int currentRetryCount, TimeSpan retryAttemptWaitingTime, Exception exception)>(((int currentRetryCount, TimeSpan retryAttemptWaitingTime, Exception exception) input) => { });
            var circuitBreakerWaitingTimeFunction = new Func<TimeSpan>(() => TimeSpan.FromSeconds(5));
            var onCircuitBreakerHalfOpenAditionalHandler = new Action(() => { });
            var onCircuitBreakerOpenAditionalHandler = new Action<(int currentCircuitBreakerOpenCount, TimeSpan circuitBreakerWaitingTime, Exception exception)>(((int currentCircuitBreakerOpenCount, TimeSpan circuitBreakerWaitingTime, Exception exception) input) => { });
            var onCircuitBreakerCloseAditionalHandler = new Action(() => { });
            var exceptionHandleConfigArray = new[] {
                new Func<Exception, bool>(ex => ex.GetType() == typeof(ArgumentException)),
                new Func<Exception, bool>(ex => ex.GetType() == typeof(ArgumentNullException)),
                new Func<Exception, bool>(ex => ex.GetType() == typeof(ArgumentOutOfRangeException))
            };

            // Act
            resilienceConfig.Name = name;
            resilienceConfig.RetryMaxAttemptCount = retryMaxAttemptCount;
            resilienceConfig.RetryAttemptWaitingTimeFunction = retryAttemptWaitingTimeFunction;
            resilienceConfig.OnRetryAditionalHandler = onRetryAditionalHandler;
            resilienceConfig.CircuitBreakerWaitingTimeFunction = circuitBreakerWaitingTimeFunction;
            resilienceConfig.OnCircuitBreakerHalfOpenAditionalHandler = onCircuitBreakerHalfOpenAditionalHandler;
            resilienceConfig.OnCircuitBreakerOpenAditionalHandler = onCircuitBreakerOpenAditionalHandler;
            resilienceConfig.OnCircuitBreakerCloseAditionalHandler = onCircuitBreakerCloseAditionalHandler;
            resilienceConfig.ExceptionHandleConfigArray = exceptionHandleConfigArray;

            // Assert
            resilienceConfig.Name.Should().Be(name);
            resilienceConfig.RetryMaxAttemptCount.Should().Be(retryMaxAttemptCount);
            resilienceConfig.RetryAttemptWaitingTimeFunction.Should().Be(retryAttemptWaitingTimeFunction);
            resilienceConfig.OnRetryAditionalHandler.Should().Be(onRetryAditionalHandler);
            resilienceConfig.CircuitBreakerWaitingTimeFunction.Should().BeSameAs(circuitBreakerWaitingTimeFunction);
            resilienceConfig.OnCircuitBreakerHalfOpenAditionalHandler.Should().BeSameAs(onCircuitBreakerHalfOpenAditionalHandler);
            resilienceConfig.OnCircuitBreakerOpenAditionalHandler.Should().Be(onCircuitBreakerOpenAditionalHandler);
            resilienceConfig.OnCircuitBreakerCloseAditionalHandler.Should().BeSameAs(onCircuitBreakerCloseAditionalHandler);
            resilienceConfig.ExceptionHandleConfigArray.Should().BeSameAs(exceptionHandleConfigArray);
        }
    }
}