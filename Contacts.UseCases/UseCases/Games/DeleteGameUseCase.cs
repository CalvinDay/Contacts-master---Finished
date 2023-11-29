using Contacts.UseCases.Interfaces.Games;
using Contacts.UseCases.PluginInterfaces;

namespace Contacts.UseCases.UseCases.Games
{
    public class DeleteGameUseCase : IDeleteGameUseCase
    {
        private readonly IGameRepository gameRepository;

        public DeleteGameUseCase(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public async Task ExecuteAsync(int gameId)
        {
            await gameRepository.DeleteGameAsync(gameId);
        }
    }
}
