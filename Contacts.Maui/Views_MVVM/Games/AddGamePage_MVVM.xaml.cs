using Contacts.Maui.ViewModels.Games;

namespace Contacts.Maui.Views_MVVM.Games;

public partial class AddGamePage_MVVM : ContentPage
{
  private readonly GameViewModel gameViewModel;

  public AddGamePage_MVVM(GameViewModel gameViewModel)
  {
    InitializeComponent();

		BindingContext = this.gameViewModel = gameViewModel;
  }

  protected override void OnAppearing()
  {
    base.OnAppearing();

    gameViewModel.Game = new CoreBusiness.Game();
  }
}