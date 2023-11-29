using Contacts.UseCases.Interfaces.Chips;
using Contacts.UseCases.PluginInterfaces;

namespace Contacts.UseCases.UseCases.Chips
{
    public class RebuyChipUseCase : IRebuyChipUseCase
    {
        private readonly IChipRepository chipRepository;

        public RebuyChipUseCase(IChipRepository chipRepository)
        {
            this.chipRepository = chipRepository;
        }

        public async Task ExecuteAsync(int chipId)
        {
            await chipRepository.RebuyChipAsync(chipId);
        }
    }
}
