
using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Chips;

namespace Contacts.UseCases.UseCases.Chips
{
    public class EditChipUseCase : IEditChipUseCase
    {
        private readonly IChipRepository chipRepository;

        public EditChipUseCase(IChipRepository chipRepository)
        {
            this.chipRepository = chipRepository;
        }

        public async Task ExecuteAsync(int chipId, Chip chip)
        {
            await chipRepository.UpdateChipAsync(chipId, chip);
        }
    }
}
