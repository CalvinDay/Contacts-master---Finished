using Contacts.UseCases.Interfaces.Players;
using Contacts.UseCases.PluginInterfaces;

namespace Contacts.UseCases.UseCases.Players
{
    public class RebuyPlayerUseCase : IRebuyPlayerUseCase
    {
        private readonly IPlayerRepository playerRepository;

        public RebuyPlayerUseCase(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public async Task ExecuteAsync(int playerId)
        {
            await playerRepository.RebuyPlayerAsync(playerId);
        }
    }
}
