using Contacts.UseCases.Interfaces.Chips;
using Contacts.UseCases.PluginInterfaces;

namespace Contacts.UseCases.UseCases.Chips
{
    public class DeleteChipUseCase : IDeleteChipUseCase
    {
        private readonly IChipRepository chipRepository;

        public DeleteChipUseCase(IChipRepository chipRepository)
        {
            this.chipRepository = chipRepository;
        }

        public async Task ExecuteAsync(int chipId)
        {
            await chipRepository.DeleteChipAsync(chipId);
        }
    }
}
