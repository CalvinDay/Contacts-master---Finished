using Contacts.Maui.Views_MVVM;
using Contacts.Maui.Views_MVVM.Blinds;
using Contacts.Maui.Views_MVVM.Chips;
using Contacts.Maui.Views_MVVM.Chipsets;
using Contacts.Maui.Views_MVVM.Contacts;
using Contacts.Maui.Views_MVVM.Games;
using Contacts.Maui.Views_MVVM.Payouts;
using Contacts.Maui.Views_MVVM.Players;
using Contacts.Maui.Views_MVVM.Tables;

namespace Contacts.Maui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        // Main
//        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));

        // Games
        Routing.RegisterRoute(nameof(Games_Page_MVVM), typeof(Games_Page_MVVM));
        Routing.RegisterRoute(nameof(EditGamePage_MVVM), typeof(EditGamePage_MVVM));
        Routing.RegisterRoute(nameof(AddGamePage_MVVM), typeof(AddGamePage_MVVM));

        // Contacts
        Routing.RegisterRoute(nameof(Contacts_Page_MVVM), typeof(Contacts_Page_MVVM));
        Routing.RegisterRoute(nameof(EditContactPage_MVVM), typeof(EditContactPage_MVVM));
        Routing.RegisterRoute(nameof(AddContactPage_MVVM), typeof(AddContactPage_MVVM));

        // Chips
        Routing.RegisterRoute(nameof(Chips_Page_MVVM), typeof(Chips_Page_MVVM));
        Routing.RegisterRoute(nameof(EditChipPage_MVVM), typeof(EditChipPage_MVVM));
        Routing.RegisterRoute(nameof(AddChipPage_MVVM), typeof(AddChipPage_MVVM));

        // Chipsets
        Routing.RegisterRoute(nameof(Chipsets_Page_MVVM), typeof(Chipsets_Page_MVVM));
        Routing.RegisterRoute(nameof(EditChipsetPage_MVVM), typeof(EditChipsetPage_MVVM));
        Routing.RegisterRoute(nameof(AddChipsetPage_MVVM), typeof(AddChipsetPage_MVVM));

        // Players
        Routing.RegisterRoute(nameof(Players_Page_MVVM), typeof(Players_Page_MVVM));
        Routing.RegisterRoute(nameof(EditPlayerPage_MVVM), typeof(EditPlayerPage_MVVM));
        Routing.RegisterRoute(nameof(AddPlayerPage_MVVM), typeof(AddPlayerPage_MVVM));

        // Blinds
        Routing.RegisterRoute(nameof(Blinds_Page_MVVM), typeof(Blinds_Page_MVVM));
        Routing.RegisterRoute(nameof(EditBlindPage_MVVM), typeof(EditBlindPage_MVVM));
        Routing.RegisterRoute(nameof(AddBlindPage_MVVM), typeof(AddBlindPage_MVVM));

        // Tables
        Routing.RegisterRoute(nameof(Tables_Page_MVVM), typeof(Tables_Page_MVVM));
        Routing.RegisterRoute(nameof(EditTablePage_MVVM), typeof(EditTablePage_MVVM));
        Routing.RegisterRoute(nameof(AddTablePage_MVVM), typeof(AddTablePage_MVVM));

        // Payouts
        Routing.RegisterRoute(nameof(Payouts_Page_MVVM), typeof(Payouts_Page_MVVM));
        Routing.RegisterRoute(nameof(EditPayoutPage_MVVM), typeof(EditPayoutPage_MVVM));
        Routing.RegisterRoute(nameof(AddPayoutPage_MVVM), typeof(AddPayoutPage_MVVM));
    }
}
