using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Players;

namespace Contacts.UseCases.UseCases.Players
{
    // All the code in this file is included in all platforms.
    public class ViewPlayersUseCase : IViewPlayersUseCase
    {
        private readonly IPlayerRepository playerRepository;

        public ViewPlayersUseCase(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public async Task<List<Player>> ExecuteAsync(string filterText)
        {
            return await playerRepository.GetPlayersAsync(filterText);
        }

    }
}