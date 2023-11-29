using Contacts.UseCases.Interfaces.Contacts;
using Contacts.UseCases.PluginInterfaces;
using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.UseCases.UseCases.Contacts
{
    public class EditContactUseCase : IEditContactUseCase
    {
        private readonly IContactRepository contactRepository;

        public EditContactUseCase(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public async Task ExecuteAsync(int contactId, Contact contact)
        {
            await contactRepository.UpdateContactAsync(contactId, contact);
        }
    }
}
