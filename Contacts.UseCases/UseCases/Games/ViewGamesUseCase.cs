using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Games;

namespace Contacts.UseCases.UseCases.Games
{
    // All the code in this file is included in all platforms.
    public class ViewGamesUseCase : IViewGamesUseCase
    {
        private readonly IGameRepository gameRepository;

        public ViewGamesUseCase(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public async Task<List<Game>> ExecuteAsync(string filterText)
        {
            return await gameRepository.GetGamesAsync(filterText);
        }

    }
}