namespace Common
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}