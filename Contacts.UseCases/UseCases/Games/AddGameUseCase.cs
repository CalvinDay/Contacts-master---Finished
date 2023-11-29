using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Games;

namespace Contacts.UseCases.UseCases.Games
{
    public class AddGameUseCase : IAddGameUseCase
    {
        private readonly IGameRepository gameRepository;

        public AddGameUseCase(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public async Task ExecuteAsync(Game game)
        {
            await gameRepository.AddGameAsync(game);
        }
    }
}
