using Contacts.UseCases.Interfaces.Contacts;
using Contacts.UseCases.PluginInterfaces;
using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.UseCases.UseCases.Contacts
{
    public class ViewContactUseCase : IViewContactUseCase
    {
        private readonly IContactRepository contactRepository;

        public ViewContactUseCase(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public async Task<Contact> ExecuteAsync(int contactId)
        {
            return await contactRepository.GetContactByIdAsync(contactId);
        }
    }
}
