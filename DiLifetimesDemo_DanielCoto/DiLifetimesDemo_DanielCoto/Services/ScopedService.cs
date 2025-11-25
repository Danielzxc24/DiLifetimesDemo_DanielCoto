namespace DiLifetimesDemo_DanielCoto.Services
{
    public class ScopedService : IScopedService
    {
        private readonly Guid _codigo;

        public ScopedService()
        {
            _codigo = Guid.NewGuid();
        }

        public Guid Codigo => _codigo;
    }
}
