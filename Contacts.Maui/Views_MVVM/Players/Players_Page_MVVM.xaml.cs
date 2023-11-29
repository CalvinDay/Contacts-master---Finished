using Contacts.Maui.ViewModels.Players;

namespace Contacts.Maui.Views_MVVM.Players;

public partial class Players_Page_MVVM : ContentPage
{
  private readonly PlayersViewModel playersViewModel;

  public Players_Page_MVVM(PlayersViewModel playersViewModel)
  {
    InitializeComponent();

    BindingContext = this.playersViewModel = playersViewModel;
  }

  protected async override void OnAppearing()
  {
    base.OnAppearing();

	  await playersViewModel.LoadPlayers();
  }
}