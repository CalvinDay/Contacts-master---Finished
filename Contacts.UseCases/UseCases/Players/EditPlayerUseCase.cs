using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Players;

namespace Contacts.UseCases.UseCases.Players
{
    public class EditPlayerUseCase : IEditPlayerUseCase
    {
        private readonly IPlayerRepository playerRepository;

        public EditPlayerUseCase(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public async Task ExecuteAsync(int playerId, Player player)
        {
            await playerRepository.UpdatePlayerAsync(playerId, player);
        }
    }
}
