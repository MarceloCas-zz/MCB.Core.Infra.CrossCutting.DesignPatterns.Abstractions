using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Validator.Models;

namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Validator
{
    public interface IValidator<T>
    {
        ValidationResult Validate(T instance);
        Task<ValidationResult> ValidateAsync(T instance, CancellationToken cancellationToken);
    }
}
