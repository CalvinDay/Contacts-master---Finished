using Contacts.Maui.ViewModels.Payouts;

namespace Contacts.Maui.Views_MVVM.Payouts;

public partial class Payouts_Page_MVVM : ContentPage
{
  private readonly PayoutsViewModel payoutsViewModel;

  public Payouts_Page_MVVM(PayoutsViewModel payoutsViewModel)
  {
    InitializeComponent();

    BindingContext = this.payoutsViewModel = payoutsViewModel;
  }

  protected async override void OnAppearing()
  {
    base.OnAppearing();

	await payoutsViewModel.LoadPayouts();
  }
}