namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Factory;

public interface IFactoryWithParameter<out T, TParameter>
{
    T Create(TParameter parameter);
}
