using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Players;

namespace Contacts.UseCases.UseCases.Players
{
    public class AddPlayerUseCase : IAddPlayerUseCase
    {
        private readonly IPlayerRepository playerRepository;

        public AddPlayerUseCase(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public async Task ExecuteAsync(Player player)
        {
            await playerRepository.AddPlayerAsync(player);
        }
    }
}
