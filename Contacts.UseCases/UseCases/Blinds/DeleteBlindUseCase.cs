using Contacts.UseCases.Interfaces.Blinds;
using Contacts.UseCases.PluginInterfaces;

namespace Contacts.UseCases.UseCases.Blinds
{
    public class DeleteBlindUseCase : IDeleteBlindUseCase
    {
        private readonly IBlindRepository blindRepository;

        public DeleteBlindUseCase(IBlindRepository blindRepository)
        {
            this.blindRepository = blindRepository;
        }

        public async Task ExecuteAsync(int blindId)
        {
            await blindRepository.DeleteBlindAsync(blindId);
        }
    }
}
