using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Chips;

namespace Contacts.UseCases.UseCases.Chips
{
    public class AddChipUseCase : IAddChipUseCase
    {
        private readonly IChipRepository chipRepository;

        public AddChipUseCase(IChipRepository chipRepository)
        {
            this.chipRepository = chipRepository;
        }

        public async Task ExecuteAsync(Chip chip)
        {
            await chipRepository.AddChipAsync(chip);
        }
    }
}
