using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Chips;

namespace Contacts.UseCases.UseCases.Chips
{
    public class ViewChipUseCase : IViewChipUseCase
    {
        private readonly IChipRepository chipRepository;

        public ViewChipUseCase(IChipRepository chipRepository)
        {
            this.chipRepository = chipRepository;
        }

        public async Task<Chip> ExecuteAsync(int chipId)
        {
            return await chipRepository.GetChipByIdAsync(chipId);
        }
    }
}
