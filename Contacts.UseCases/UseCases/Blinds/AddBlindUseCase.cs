using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Blinds;

namespace Contacts.UseCases.UseCases.Blinds
{
    public class AddBlindUseCase : IAddBlindUseCase
    {
        private readonly IBlindRepository blindRepository;

        public AddBlindUseCase(IBlindRepository blindRepository)
        {
            this.blindRepository = blindRepository;
        }

        public async Task ExecuteAsync(Blind blind)
        {
            await blindRepository.AddBlindAsync(blind);
        }
    }
}
