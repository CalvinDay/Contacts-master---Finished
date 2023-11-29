using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Players;

namespace Contacts.UseCases.UseCases.Players
{
    public class ViewPlayerUseCase : IViewPlayerUseCase
    {
        private readonly IPlayerRepository playerRepository;

        public ViewPlayerUseCase(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public async Task<Player> ExecuteAsync(int playerId)
        {
            return await playerRepository.GetPlayerByIdAsync(playerId);
        }
    }
}
