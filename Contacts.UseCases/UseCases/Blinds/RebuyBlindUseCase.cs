using Contacts.UseCases.Interfaces.Blinds;
using Contacts.UseCases.PluginInterfaces;

namespace Contacts.UseCases.UseCases.Blinds
{
    public class RebuyBlindUseCase : IRebuyBlindUseCase
    {
        private readonly IBlindRepository blindRepository;

        public RebuyBlindUseCase(IBlindRepository blindRepository)
        {
            this.blindRepository = blindRepository;
        }

        public async Task ExecuteAsync(int blindId)
        {
            await blindRepository.RebuyBlindAsync(blindId);
        }
    }
}
