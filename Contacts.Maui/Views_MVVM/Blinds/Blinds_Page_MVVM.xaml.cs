using Contacts.Maui.ViewModels.Blinds;

namespace Contacts.Maui.Views_MVVM.Blinds;

public partial class Blinds_Page_MVVM : ContentPage
{
  private readonly BlindsViewModel blindsViewModel;

  public Blinds_Page_MVVM(BlindsViewModel blindsViewModel)
  {
    InitializeComponent();

    BindingContext = this.blindsViewModel = blindsViewModel;
  }

  protected async override void OnAppearing()
  {
    base.OnAppearing();

	await blindsViewModel.LoadBlinds();
  }
}