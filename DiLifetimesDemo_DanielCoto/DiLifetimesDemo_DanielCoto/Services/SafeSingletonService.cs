namespace DiLifetimesDemo_DanielCoto.Services
{
    public class SafeSingletonService : ISafeSingletonService
    {
        private readonly Guid _singletonId;
        private readonly IServiceScopeFactory _scopeFactory;

        public SafeSingletonService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
            _singletonId = Guid.NewGuid();
        }

        public Guid SingletonId => _singletonId;

        public Guid GetScopedIdFromNewScope()
        {
            using var scope = _scopeFactory.CreateScope();

            var scopedService = scope.ServiceProvider
                                     .GetRequiredService<IScopedService>();

            return scopedService.Codigo;
        }
    }
}
