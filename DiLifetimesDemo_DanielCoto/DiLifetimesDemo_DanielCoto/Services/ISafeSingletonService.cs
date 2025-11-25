namespace DiLifetimesDemo_DanielCoto.Services
{
    public interface ISafeSingletonService
    {
        Guid SingletonId { get; }
        Guid GetScopedIdFromNewScope();
    }
}
