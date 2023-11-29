using Contacts.UseCases.Interfaces.Contacts;
using Contacts.UseCases.PluginInterfaces;

namespace Contacts.UseCases.UseCases.Contacts
{
    public class DeleteContactUseCase : IDeleteContactUseCase
    {
        private readonly IContactRepository contactRepository;

        public DeleteContactUseCase(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public async Task ExecuteAsync(int contactId)
        {
            await contactRepository.DeleteContactAsync(contactId);
        }
    }
}
