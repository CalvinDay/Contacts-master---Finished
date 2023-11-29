using Contacts.Maui.ViewModels.Games;

namespace Contacts.Maui.Views_MVVM.Games;

public partial class Games_Page_MVVM : ContentPage
{
  private readonly GamesViewModel gamesViewModel;

  public Games_Page_MVVM(GamesViewModel gamesViewModel)
  {
    InitializeComponent();

    BindingContext = this.gamesViewModel = gamesViewModel;
  }

  protected override async void OnAppearing()
  {
    base.OnAppearing();

    await gamesViewModel.LoadGames();
  }
}