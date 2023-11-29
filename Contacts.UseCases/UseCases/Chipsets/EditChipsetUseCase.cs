
using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Chipsets;

namespace Contacts.UseCases.UseCases.Chipsets
{
    public class EditChipsetUseCase : IEditChipsetUseCase
    {
        private readonly IChipsetRepository chipsetRepository;

        public EditChipsetUseCase(IChipsetRepository chipsetRepository)
        {
            this.chipsetRepository = chipsetRepository;
        }

        public async Task ExecuteAsync(int chipsetId, Chipset chipset)
        {
            await chipsetRepository.UpdateChipsetAsync(chipsetId, chipset);
        }
    }
}
