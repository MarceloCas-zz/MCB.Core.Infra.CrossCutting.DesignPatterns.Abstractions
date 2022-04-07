namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Factories
{
    public interface IFactory<out T>
    {
        T Create();
    }
}
