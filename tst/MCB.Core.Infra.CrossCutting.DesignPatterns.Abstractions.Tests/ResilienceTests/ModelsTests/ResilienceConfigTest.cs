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
            var resilienceConfig = new ResilienceConfig();

            // Assert
            resilienceConfig.Name.Should().NotBeNullOrEmpty();
            resilienceConfig.RetryMaxAttemptCount.Should().Be(ResilienceConfig.DEFAULT_RETRY_MAX_ATTEMPT_COUNT);
            resilienceConfig.RetryAttemptWaitingTimeFunction.Should().NotBeNull();
            resilienceConfig.RetryAttemptWaitingTimeFunction(default).Seconds.Should().Be(ResilienceConfig.DEFAULT_RETRY_ATTEMPT_WAITING_TIME_IN_SECONDS);
            resilienceConfig.OnRetryAditionalHandler.Should().BeNull();
            resilienceConfig.CircuitBreakerWaitingTimeFunction.Should().NotBeNull();
            resilienceConfig.CircuitBreakerWaitingTimeFunction(default).Seconds.Should().Be(ResilienceConfig.DEFAULT_CIRCUIT_BREAKER_WAITING_TIME_IN_SECONDS);
            resilienceConfig.OnCircuitBreakerCloseAditionalHandler.Should().BeNull();
            resilienceConfig.OnCircuitBreakerHalfOpenAditionalHandler.Should().BeNull();
            resilienceConfig.OnCircuitBreakerOpenAditionalHandler.Should().BeNull();
            resilienceConfig.OnCircuitBreakerResetOpenAditionalHandler.Should().BeNull();
            resilienceConfig.ExceptionHandleConfigArray.Should().HaveCount(1);
            resilienceConfig.ExceptionHandleConfigArray[0](new Exception()).Should().BeTrue();
        }

        [Fact]
        public void ResilienceConfig_Should_Be_Correct_Values()
        {
            // Arrange
            var resilienceConfig = new ResilienceConfig();

            var name = "Resilience Policy Demo";
            var retryMaxAttemptCount = 10;
            var retryAttemptWaitingTimeFunction = new Func<int, TimeSpan>(attempt => TimeSpan.FromSeconds(7));
            var onRetryAditionalHandler = new Action<(Exception exception, TimeSpan retryAttemptWaitingTime)>(((Exception exception, TimeSpan retryAttemptWaitingTime) input) => { });
            var circuitBreakerWaitingTimeFunction = new Func<int, TimeSpan>(circuitBreakerOpenCount => TimeSpan.FromSeconds(5));
            var onCircuitBreakerCloseAditionalHandler = new Action<(Exception exception, TimeSpan circuitBreakerWaitingTime)>(((Exception exception, TimeSpan circuitBreakerWaitingTime) input) => { });
            var onCircuitBreakerHalfOpenAditionalHandler = new Action<(Exception exception, TimeSpan circuitBreakerWaitingTime)>(((Exception exception, TimeSpan circuitBreakerWaitingTime) input) => { });
            var onCircuitBreakerOpenAditionalHandler = new Action<(Exception exception, TimeSpan circuitBreakerWaitingTime)>(((Exception exception, TimeSpan circuitBreakerWaitingTime) input) => { });
            var onCircuitBreakerResetOpenAditionalHandler = new Action<(Exception exception, TimeSpan circuitBreakerWaitingTime)>(((Exception exception, TimeSpan circuitBreakerWaitingTime) input) => { });
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
            resilienceConfig.OnCircuitBreakerCloseAditionalHandler = onCircuitBreakerCloseAditionalHandler;
            resilienceConfig.OnCircuitBreakerHalfOpenAditionalHandler = onCircuitBreakerHalfOpenAditionalHandler;
            resilienceConfig.OnCircuitBreakerOpenAditionalHandler = onCircuitBreakerOpenAditionalHandler;
            resilienceConfig.OnCircuitBreakerResetOpenAditionalHandler = onCircuitBreakerResetOpenAditionalHandler;
            resilienceConfig.ExceptionHandleConfigArray = exceptionHandleConfigArray;

            // Assert
            resilienceConfig.Name.Should().Be(name);
            resilienceConfig.RetryMaxAttemptCount.Should().Be(retryMaxAttemptCount);
            resilienceConfig.RetryAttemptWaitingTimeFunction.Should().Be(retryAttemptWaitingTimeFunction);
            resilienceConfig.OnRetryAditionalHandler.Should().Be(onRetryAditionalHandler);
            resilienceConfig.CircuitBreakerWaitingTimeFunction.Should().Be(circuitBreakerWaitingTimeFunction);
            resilienceConfig.OnCircuitBreakerCloseAditionalHandler.Should().Be(onCircuitBreakerCloseAditionalHandler);
            resilienceConfig.OnCircuitBreakerHalfOpenAditionalHandler.Should().Be(onCircuitBreakerHalfOpenAditionalHandler);
            resilienceConfig.OnCircuitBreakerOpenAditionalHandler.Should().Be(onCircuitBreakerOpenAditionalHandler);
            resilienceConfig.OnCircuitBreakerResetOpenAditionalHandler.Should().Be(onCircuitBreakerResetOpenAditionalHandler);
            resilienceConfig.ExceptionHandleConfigArray.Should().BeEquivalentTo(exceptionHandleConfigArray);
        }
    }
}
