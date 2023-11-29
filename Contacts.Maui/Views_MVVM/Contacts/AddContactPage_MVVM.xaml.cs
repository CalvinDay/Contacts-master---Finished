using Contacts.Maui.ViewModels.Contacts;

namespace Contacts.Maui.Views_MVVM.Contacts;

public partial class AddContactPage_MVVM : ContentPage
{
  private readonly ContactViewModel contactViewModel;

  public AddContactPage_MVVM(ContactViewModel contactViewModel)
  {
    InitializeComponent();

    BindingContext = this.contactViewModel = contactViewModel;
  }

  protected override void OnAppearing()
  {
    base.OnAppearing();

    contactViewModel.Contact = new CoreBusiness.Contact();
  }
}