namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Factory;

public interface IFactoryWithParameter<out T, TParameter>
    : IFactory<T>
{
    T Create(TParameter parameter);
}
