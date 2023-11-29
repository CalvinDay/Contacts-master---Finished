using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Chipsets;

namespace Contacts.UseCases.UseCases.Chipsets
{
    // All the code in this file is included in all platforms.
    public class ViewChipsetsUseCase : IViewChipsetsUseCase
    {
        private readonly IChipsetRepository chipsetRepository;

        public ViewChipsetsUseCase(IChipsetRepository chipsetRepository)
        {
            this.chipsetRepository = chipsetRepository;
        }

        public async Task<List<Chipset>> ExecuteAsync(string filterText)
        {
            return await chipsetRepository.GetChipsetsAsync(filterText);
        }

    }
}