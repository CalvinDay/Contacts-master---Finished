using Contacts.Maui.ViewModels.Chips;

namespace Contacts.Maui.Views_MVVM.Chips;

public partial class AddChipPage_MVVM : ContentPage
{
  private readonly ChipViewModel chipViewModel;

  public AddChipPage_MVVM(ChipViewModel chipViewModel)
  {
    InitializeComponent();

    BindingContext = this.chipViewModel = chipViewModel;
  }

  protected override void OnAppearing()
  {
    base.OnAppearing();

    chipViewModel.Chip = new CoreBusiness.Chip()
    {
      ChipsetId = Helper.ChipsetId
    };
  }
}