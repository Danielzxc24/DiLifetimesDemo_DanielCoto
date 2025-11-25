namespace DiLifetimesDemo_DanielCoto.Services
{
    public class TransientService : ITransientService
    {
        private readonly Guid _codigo;

        public TransientService()
        {
            _codigo = Guid.NewGuid();
        }

        public Guid Codigo => _codigo;
    }
}
