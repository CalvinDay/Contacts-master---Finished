using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Games;

namespace Contacts.UseCases.UseCases.Games
{
    public class EditGameUseCase : IEditGameUseCase
    {
        private readonly IGameRepository gameRepository;

        public EditGameUseCase(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public async Task ExecuteAsync(int gameId, Game game)
        {
            await gameRepository.UpdateGameAsync(gameId, game);
        }
    }
}
