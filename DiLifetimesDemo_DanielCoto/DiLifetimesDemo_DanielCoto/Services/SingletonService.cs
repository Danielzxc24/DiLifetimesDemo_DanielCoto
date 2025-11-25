namespace DiLifetimesDemo_DanielCoto.Services
{
    public class SingletonService : ISingletonService
    {
        private readonly Guid _codigo;

        public SingletonService()
        {
            _codigo = Guid.NewGuid();
        }

        public Guid Codigo => _codigo;
    }
}
