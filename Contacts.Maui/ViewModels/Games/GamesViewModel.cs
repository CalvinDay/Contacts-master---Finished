using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.Maui.Views_MVVM.Games;
using System.Collections.ObjectModel;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Games;
using Contacts.UseCases.Interfaces.Chipsets;
using Contacts.UseCases.Interfaces.Blinds;
using Contacts.UseCases.Interfaces.Payouts;
using static Android.Graphics.ColorSpace;

namespace Contacts.Maui.ViewModels.Games
{
  public partial class GamesViewModel : ObservableObject
  {
    private readonly IViewGamesUseCase viewGamesUseCase;
    private readonly IDeleteGameUseCase deleteGameUseCase;
    private readonly IViewChipsetsUseCase viewChipsetsUseCase;
    private readonly IAddGameUseCase addGameUseCase;
    private readonly IViewBlindsUseCase viewBlindsUseCase;
    private readonly IAddBlindUseCase addBlindUseCase;
    private readonly IViewPayoutsUseCase viewPayoutsUseCase;
    private readonly IAddPayoutUseCase addPayoutUseCase;

    public ObservableCollection<Game> Games { get; set; }

    public GamesViewModel(
        IViewGamesUseCase viewGamesUseCase,
        IDeleteGameUseCase deleteGameUseCase,
        IViewChipsetsUseCase viewChipsetsUseCase,
        IAddGameUseCase addGameUseCase,
        IViewBlindsUseCase viewBlindsUseCase,
        IAddBlindUseCase addBlindUseCase,
        IViewPayoutsUseCase viewPayoutsUseCase,
        IAddPayoutUseCase addPayoutUseCase
        )
    {
      this.viewGamesUseCase = viewGamesUseCase;
      this.deleteGameUseCase = deleteGameUseCase;
      this.viewChipsetsUseCase = viewChipsetsUseCase;
      this.addGameUseCase = addGameUseCase;
      this.viewBlindsUseCase = viewBlindsUseCase;
      this.addBlindUseCase = addBlindUseCase;
      this.viewPayoutsUseCase = viewPayoutsUseCase;
      this.addPayoutUseCase = addPayoutUseCase;

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

    public async Task CopyBlinds(int newGameId)
    {
      var gameId = Helper.GameId.ToString();

      // load blinds with current GameId
      var blinds = await viewBlindsUseCase.ExecuteAsync(gameId);

      if (blinds != null && blinds?.Count > 0)  
        foreach (var blind in blinds)
        {
          Blind blind_ = new();

          Helper.MapProperties(blind, blind_);

          blind_.GameId = newGameId;

          await addBlindUseCase.ExecuteAsync(blind_);
        }
    }

    public async Task CopyPayouts(int newGameId)
    {
      var gameId = Helper.GameId.ToString();

      // load blinds with current GameId
      var payouts = await viewPayoutsUseCase.ExecuteAsync(gameId);

      if (payouts != null && payouts?.Count > 0)
        foreach (var payout in payouts)
        {
          Payout payout_ = new();

          Helper.MapProperties(payout, payout_);

          payout_.GameId = newGameId;

          await addPayoutUseCase.ExecuteAsync(payout_);
        }
    }

    [RelayCommand]
    public async Task GotoCopyGame()
    {
      int currentGameIndex = Games
          .Select((g, index) => new { Game = g, Index = index })
          .FirstOrDefault(item => item.Game.GameId == Helper.GameId)?.Index ?? -1;

      if (currentGameIndex != -1 && currentGameIndex < Games.Count)
      {
        Game game = new();

        // Ensure Helper.MapProperties correctly maps properties from source to target
        Helper.MapProperties(Games[currentGameIndex], game);

        // Add new game
        await addGameUseCase.ExecuteAsync(game);

        // newly added game should be first in list
        await LoadGames();

        await CopyBlinds(Games[0].GameId);

        await CopyPayouts(Games[0].GameId);
      }

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