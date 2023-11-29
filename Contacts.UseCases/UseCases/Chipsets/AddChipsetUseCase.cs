using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Chipsets;

namespace Contacts.UseCases.UseCases.Chipsets
{
    public class AddChipsetUseCase : IAddChipsetUseCase
    {
        private readonly IChipsetRepository chipsetRepository;

        public AddChipsetUseCase(IChipsetRepository chipsetRepository)
        {
            this.chipsetRepository = chipsetRepository;
        }

        public async Task ExecuteAsync(Chipset chipset)
        {
            await chipsetRepository.AddChipsetAsync(chipset);
        }
    }
}
