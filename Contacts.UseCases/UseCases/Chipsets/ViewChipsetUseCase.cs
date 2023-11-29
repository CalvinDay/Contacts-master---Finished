using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Chipsets;

namespace Contacts.UseCases.UseCases.Chipsets
{
    public class ViewChipsetUseCase : IViewChipsetUseCase
    {
        private readonly IChipsetRepository chipsetRepository;

        public ViewChipsetUseCase(IChipsetRepository chipsetRepository)
        {
            this.chipsetRepository = chipsetRepository;
        }

        public async Task<Chipset> ExecuteAsync(int chipsetId)
        {
            return await chipsetRepository.GetChipsetByIdAsync(chipsetId);
        }
    }
}
