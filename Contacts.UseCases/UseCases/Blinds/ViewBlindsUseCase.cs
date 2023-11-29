using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Blinds;

namespace Contacts.UseCases.UseCases.Blinds
{
    // All the code in this file is included in all platforms.
    public class ViewBlindsUseCase : IViewBlindsUseCase
    {
        private readonly IBlindRepository blindRepository;

        public ViewBlindsUseCase(IBlindRepository blindRepository)
        {
            this.blindRepository = blindRepository;
        }

        public async Task<List<Blind>> ExecuteAsync(string filterText)
        {
            return await blindRepository.GetBlindsAsync(filterText);
        }

    }
}