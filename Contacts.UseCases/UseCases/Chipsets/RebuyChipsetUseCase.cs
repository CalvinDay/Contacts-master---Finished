using Contacts.UseCases.Interfaces.Chipsets;
using Contacts.UseCases.PluginInterfaces;

namespace Contacts.UseCases.UseCases.Chipsets
{
    public class RebuyChipsetUseCase : IRebuyChipsetUseCase
    {
        private readonly IChipsetRepository chipsetRepository;

        public RebuyChipsetUseCase(IChipsetRepository chipsetRepository)
        {
            this.chipsetRepository = chipsetRepository;
        }

        public async Task ExecuteAsync(int chipsetId)
        {
            await chipsetRepository.RebuyChipsetAsync(chipsetId);
        }
    }
}
