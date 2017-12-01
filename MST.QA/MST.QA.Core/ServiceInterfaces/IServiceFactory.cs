namespace MST.QA.Core.ServiceInterfaces
{
    public interface IServiceFactory
    {
        T CreateClient<T>() where T : IServiceContract;
    }
}
