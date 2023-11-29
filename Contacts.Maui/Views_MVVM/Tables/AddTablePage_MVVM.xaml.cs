using Contacts.Maui.ViewModels.Tables;

namespace Contacts.Maui.Views_MVVM.Tables;

public partial class AddTablePage_MVVM : ContentPage
{
  private readonly TableViewModel tableViewModel;

  public AddTablePage_MVVM(TableViewModel tableViewModel)
  {
    InitializeComponent();

    BindingContext = this.tableViewModel = tableViewModel;
  }

  protected override void OnAppearing()
  {
    base.OnAppearing();

    tableViewModel.Table = new CoreBusiness.Table()
    {
      GameId = Helper.GameId
    };
  }
}