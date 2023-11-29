using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.Maui.Views_MVVM.Games;
using System.Collections.ObjectModel;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Games;
using Contacts.Maui.Views_MVVM;
using Contacts.UseCases.Interfaces.Chipsets;

namespace Contacts.Maui.ViewModels.Games
{
	public partial class GamesViewModel : ObservableObject
	{
		private readonly IViewGamesUseCase viewGamesUseCase;
		private readonly IDeleteGameUseCase deleteGameUseCase;
		private readonly IViewChipsetsUseCase viewChipsetsUseCase;

		public ObservableCollection<Game> Games { get; set; }

		public GamesViewModel(
				IViewGamesUseCase viewGamesUseCase,
				IDeleteGameUseCase deleteGameUseCase,
				IViewChipsetsUseCase viewChipsetsUseCase
				)
		{
			this.viewGamesUseCase = viewGamesUseCase;
			this.deleteGameUseCase = deleteGameUseCase;
			this.viewChipsetsUseCase = viewChipsetsUseCase;

			Games = new ObservableCollection<Game>();
		}

		public async Task LoadGames()
		{
			Games.Clear();

			var games = await viewGamesUseCase.ExecuteAsync(null);

			games.Sort((x, y) => y.GameId.CompareTo(x.GameId));

			if (games != null && games.Count > 0)
				foreach (var game in games)
					Games.Add(game);

			Helper.Names.Clear();

			var chipsets = await viewChipsetsUseCase.ExecuteAsync(null);

			if (chipsets != null && chipsets.Count > 0)
				foreach (var chipset in chipsets)
					Helper.Names.Add(chipset.Description + chipset.Denominations);
		}

		[RelayCommand]
		public async Task DeleteGame(int gameId)
		{
			await deleteGameUseCase.ExecuteAsync(gameId);

			await LoadGames();
		}

		[RelayCommand]
		public async Task GotoEditGame(int gameId)
		{
			await Shell.Current.GoToAsync($"{nameof(EditGamePage_MVVM)}?GameId={gameId}");
		}

		[RelayCommand]
		public async Task GotoAddGame()
		{
			await Shell.Current.GoToAsync(nameof(AddGamePage_MVVM));
		}

		[RelayCommand]
		public async Task GotoHome()
		{
			await Shell.Current.GoToAsync("..");
		}
	}
}
