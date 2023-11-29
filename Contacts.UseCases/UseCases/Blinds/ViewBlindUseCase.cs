using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Blinds;

namespace Contacts.UseCases.UseCases.Blinds
{
    public class ViewBlindUseCase : IViewBlindUseCase
    {
        private readonly IBlindRepository blindRepository;

        public ViewBlindUseCase(IBlindRepository blindRepository)
        {
            this.blindRepository = blindRepository;
        }

        public async Task<Blind> ExecuteAsync(int blindId)
        {
            return await blindRepository.GetBlindByIdAsync(blindId);
        }
    }
}
