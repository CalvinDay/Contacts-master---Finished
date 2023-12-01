using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.Maui.Views_MVVM.Games;
using System.Collections.ObjectModel;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Games;
using Contacts.UseCases.Interfaces.Chipsets;

namespace Contacts.Maui.ViewModels.Games
{
  public partial class GamesViewModel : ObservableObject
  {
    private readonly IViewGamesUseCase viewGamesUseCase;
    private readonly IDeleteGameUseCase deleteGameUseCase;
    private readonly IViewChipsetsUseCase viewChipsetsUseCase;
    private readonly IAddGameUseCase addGameUseCase;

    public ObservableCollection<Game> Games { get; set; }

    public GamesViewModel(
        IViewGamesUseCase viewGamesUseCase,
        IDeleteGameUseCase deleteGameUseCase,
        IViewChipsetsUseCase viewChipsetsUseCase,
        IAddGameUseCase addGameUseCase
        )
    {
      this.viewGamesUseCase = viewGamesUseCase;
      this.deleteGameUseCase = deleteGameUseCase;
      this.viewChipsetsUseCase = viewChipsetsUseCase;
      this.addGameUseCase = addGameUseCase;

      Games = new ObservableCollection<Game>();
    }

    //private int gameId;

    //public int GameId
    //{
    //  get { return gameId; }
    //  set
    //  {
    //    if (gameId != value)
    //    {
    //      gameId = value;
    //      OnPropertyChanged(nameof(GameId));
    //    }
    //  }
    //}

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
          Helper.Names.Add(chipset.Description + " " + chipset.Denominations);
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
    public async Task GotoCopyGame()
    {
      Game game = new();

      int currentGameIndex = Games.Select((game, index) => new { Game = game, Index = index })
                                 .FirstOrDefault(item => item.Game.GameId == Helper.GameId)?.Index ?? -1;

      // copy fields
      Helper.MapProperties(Games[currentGameIndex], game);

      // clear GameId else will not store
      game.GameId = 0;

      // add new game
      await addGameUseCase.ExecuteAsync(game);

      await LoadGames();
    }

    [RelayCommand]
    public async Task GotoAddGame()
    {
      await Shell.Current.GoToAsync(nameof(AddGamePage_MVVM));
    }

    [RelayCommand]
    public static async Task GotoHome()
    {
      await Shell.Current.GoToAsync("..");
    }
  }
}