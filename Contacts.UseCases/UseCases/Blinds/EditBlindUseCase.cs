using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Blinds;

namespace Contacts.UseCases.UseCases.Blinds
{
    public class EditBlindUseCase : IEditBlindUseCase
    {
        private readonly IBlindRepository blindRepository;

        public EditBlindUseCase(IBlindRepository blindRepository)
        {
            this.blindRepository = blindRepository;
        }

        public async Task ExecuteAsync(int blindId, Blind blind)
        {
            await blindRepository.UpdateBlindAsync(blindId, blind);
        }
    }
}
