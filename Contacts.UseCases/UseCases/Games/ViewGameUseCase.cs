using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Games;

namespace Contacts.UseCases.UseCases.Games
{
    public class ViewGameUseCase : IViewGameUseCase
    {
        private readonly IGameRepository gameRepository;

        public ViewGameUseCase(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public async Task<Game> ExecuteAsync(int gameId)
        {
            return await gameRepository.GetGameByIdAsync(gameId);
        }
    }
}
