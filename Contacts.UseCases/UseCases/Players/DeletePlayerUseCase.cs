using Contacts.UseCases.Interfaces.Players;
using Contacts.UseCases.PluginInterfaces;

namespace Contacts.UseCases.UseCases.Players
{
    public class DeletePlayerUseCase : IDeletePlayerUseCase
    {
        private readonly IPlayerRepository playerRepository;

        public DeletePlayerUseCase(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public async Task ExecuteAsync(int playerId)
        {
            await playerRepository.DeletePlayerAsync(playerId);
        }
    }
}
