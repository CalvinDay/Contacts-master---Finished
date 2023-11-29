using CommunityToolkit.Maui;
using Contacts.Plugins.DataStore.WebApi;
using Contacts.UseCases.PluginInterfaces;

using Contacts.Maui.ViewModels.Contacts;
using Contacts.Maui.ViewModels.Games;
using Contacts.Maui.ViewModels.Players;
using Contacts.Maui.ViewModels.Blinds;
using Contacts.Maui.ViewModels.Payouts;
using Contacts.Maui.ViewModels.Tables;
using Contacts.Maui.ViewModels.Chipsets;
using Contacts.Maui.ViewModels.Chips;

using Contacts.Maui.Views_MVVM.Contacts;
using Contacts.Maui.Views_MVVM.Games;
using Contacts.Maui.Views_MVVM.Players;
using Contacts.Maui.Views_MVVM.Blinds;
using Contacts.Maui.Views_MVVM.Payouts;
using Contacts.Maui.Views_MVVM.Tables;
using Contacts.Maui.Views_MVVM.Chipsets;
using Contacts.Maui.Views_MVVM.Chips;

using Contacts.UseCases.UseCases.Contacts;
using Contacts.UseCases.UseCases.Games;
using Contacts.UseCases.UseCases.Players;
using Contacts.UseCases.UseCases.Blinds;
using Contacts.UseCases.UseCases.Payouts;
using Contacts.UseCases.UseCases.Tables;
using Contacts.UseCases.UseCases.Chipsets;
using Contacts.UseCases.UseCases.Chips;

using Contacts.UseCases.Interfaces.Contacts;
using Contacts.UseCases.Interfaces.Games;
using Contacts.UseCases.Interfaces.Players;
using Contacts.UseCases.Interfaces.Blinds;
using Contacts.UseCases.Interfaces.Payouts;
using Contacts.UseCases.Interfaces.Tables;
using Contacts.UseCases.Interfaces.Chipsets;
using Contacts.UseCases.Interfaces.Chips;

using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace Contacts.Maui;

public static class MauiProgram
{
  public static MauiApp CreateMauiApp()
  {
    var builder = MauiApp.CreateBuilder();
    builder
      .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseSkiaSharp()
            .ConfigureFonts(fonts =>
            {
              fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
              fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

    builder.UseMauiApp<App>().UseMauiCommunityToolkit();

#if DEBUG
    builder.Logging.AddDebug();
#endif
    // Contacts
    builder.Services.AddSingleton<IContactRepository, ContactWebApiRepository>();
    builder.Services.AddSingleton<IViewContactsUseCase, ViewContactsUseCase>();
    builder.Services.AddSingleton<IViewContactUseCase, ViewContactUseCase>();
    builder.Services.AddTransient<IEditContactUseCase, EditContactUseCase>();
    builder.Services.AddTransient<IAddContactUseCase, AddContactUseCase>();
    builder.Services.AddTransient<IDeleteContactUseCase, DeleteContactUseCase>();
    builder.Services.AddSingleton<ContactsViewModel>();
    builder.Services.AddSingleton<ContactViewModel>();
    builder.Services.AddSingleton<Contacts_Page_MVVM>();
    builder.Services.AddSingleton<EditContactPage_MVVM>();
    builder.Services.AddSingleton<AddContactPage_MVVM>();

    // Games
    builder.Services.AddSingleton<IGameRepository, GameWebApiRepository>();
    builder.Services.AddSingleton<IViewGamesUseCase, ViewGamesUseCase>();
    builder.Services.AddSingleton<IViewGameUseCase, ViewGameUseCase>();
    builder.Services.AddTransient<IEditGameUseCase, EditGameUseCase>();
    builder.Services.AddTransient<IAddGameUseCase, AddGameUseCase>();
    builder.Services.AddTransient<IDeleteGameUseCase, DeleteGameUseCase>();
    builder.Services.AddSingleton<GamesViewModel>();
    builder.Services.AddSingleton<GameViewModel>();
    builder.Services.AddSingleton<Games_Page_MVVM>();
    builder.Services.AddSingleton<EditGamePage_MVVM>();
    builder.Services.AddSingleton<AddGamePage_MVVM>();

    // Players
    builder.Services.AddSingleton<IPlayerRepository, PlayerWebApiRepository>();
    builder.Services.AddSingleton<IViewPlayersUseCase, ViewPlayersUseCase>();
    builder.Services.AddSingleton<IViewPlayerUseCase, ViewPlayerUseCase>();
    builder.Services.AddTransient<IEditPlayerUseCase, EditPlayerUseCase>();
    builder.Services.AddTransient<IAddPlayerUseCase, AddPlayerUseCase>();
    builder.Services.AddTransient<IDeletePlayerUseCase, DeletePlayerUseCase>();
    builder.Services.AddTransient<IRebuyPlayerUseCase, RebuyPlayerUseCase>();
    builder.Services.AddSingleton<PlayersViewModel>();
    builder.Services.AddSingleton<PlayerViewModel>();
    builder.Services.AddSingleton<Players_Page_MVVM>();
    builder.Services.AddSingleton<EditPlayerPage_MVVM>();
    builder.Services.AddSingleton<AddPlayerPage_MVVM>();

    // Tables
    builder.Services.AddSingleton<ITableRepository, TableWebApiRepository>();
    builder.Services.AddSingleton<IViewTablesUseCase, ViewTablesUseCase>();
    builder.Services.AddSingleton<IViewTableUseCase, ViewTableUseCase>();
    builder.Services.AddTransient<IEditTableUseCase, EditTableUseCase>();
    builder.Services.AddTransient<IAddTableUseCase, AddTableUseCase>();
    builder.Services.AddTransient<IDeleteTableUseCase, DeleteTableUseCase>();
    builder.Services.AddTransient<IRebuyTableUseCase, RebuyTableUseCase>();
    builder.Services.AddSingleton<TablesViewModel>();
    builder.Services.AddSingleton<TableViewModel>();
    builder.Services.AddSingleton<Tables_Page_MVVM>();
    builder.Services.AddSingleton<EditTablePage_MVVM>();
    builder.Services.AddSingleton<AddTablePage_MVVM>();

    // Blinds
    builder.Services.AddSingleton<IBlindRepository, BlindWebApiRepository>();
    builder.Services.AddSingleton<IViewBlindsUseCase, ViewBlindsUseCase>();
    builder.Services.AddSingleton<IViewBlindUseCase, ViewBlindUseCase>();
    builder.Services.AddTransient<IEditBlindUseCase, EditBlindUseCase>();
    builder.Services.AddTransient<IAddBlindUseCase, AddBlindUseCase>();
    builder.Services.AddTransient<IDeleteBlindUseCase, DeleteBlindUseCase>();
    builder.Services.AddTransient<IRebuyBlindUseCase, RebuyBlindUseCase>();
    builder.Services.AddSingleton<BlindsViewModel>();
    builder.Services.AddSingleton<BlindViewModel>();
    builder.Services.AddSingleton<Blinds_Page_MVVM>();
    builder.Services.AddSingleton<EditBlindPage_MVVM>();
    builder.Services.AddSingleton<AddBlindPage_MVVM>();

    // Payouts
    builder.Services.AddSingleton<IPayoutRepository, PayoutWebApiRepository>();
    builder.Services.AddSingleton<IViewPayoutsUseCase, ViewPayoutsUseCase>();
    builder.Services.AddSingleton<IViewPayoutUseCase, ViewPayoutUseCase>();
    builder.Services.AddTransient<IEditPayoutUseCase, EditPayoutUseCase>();
    builder.Services.AddTransient<IAddPayoutUseCase, AddPayoutUseCase>();
    builder.Services.AddTransient<IDeletePayoutUseCase, DeletePayoutUseCase>();
    builder.Services.AddTransient<IRebuyPayoutUseCase, RebuyPayoutUseCase>();
    builder.Services.AddSingleton<PayoutsViewModel>();
    builder.Services.AddSingleton<PayoutViewModel>();
    builder.Services.AddSingleton<Payouts_Page_MVVM>();
    builder.Services.AddSingleton<EditPayoutPage_MVVM>();
    builder.Services.AddSingleton<AddPayoutPage_MVVM>();

    // Chipsets
    builder.Services.AddSingleton<IChipsetRepository, ChipsetWebApiRepository>();
    builder.Services.AddSingleton<IViewChipsetsUseCase, ViewChipsetsUseCase>();
    builder.Services.AddSingleton<IViewChipsetUseCase, ViewChipsetUseCase>();
    builder.Services.AddTransient<IEditChipsetUseCase, EditChipsetUseCase>();
    builder.Services.AddTransient<IAddChipsetUseCase, AddChipsetUseCase>();
    builder.Services.AddTransient<IDeleteChipsetUseCase, DeleteChipsetUseCase>();
    builder.Services.AddTransient<IRebuyChipsetUseCase, RebuyChipsetUseCase>();
    builder.Services.AddSingleton<ChipsetsViewModel>();
    builder.Services.AddSingleton<ChipsetViewModel>();
    builder.Services.AddSingleton<Chipsets_Page_MVVM>();
    builder.Services.AddSingleton<EditChipsetPage_MVVM>();
    builder.Services.AddSingleton<AddChipsetPage_MVVM>();

    // Chips
    builder.Services.AddSingleton<IChipRepository, ChipWebApiRepository>();
    builder.Services.AddSingleton<IViewChipsUseCase, ViewChipsUseCase>();
    builder.Services.AddSingleton<IViewChipUseCase, ViewChipUseCase>();
    builder.Services.AddTransient<IEditChipUseCase, EditChipUseCase>();
    builder.Services.AddTransient<IAddChipUseCase, AddChipUseCase>();
    builder.Services.AddTransient<IDeleteChipUseCase, DeleteChipUseCase>();
    builder.Services.AddTransient<IRebuyChipUseCase, RebuyChipUseCase>();
    builder.Services.AddSingleton<ChipsViewModel>();
    builder.Services.AddSingleton<ChipViewModel>();
    //builder.Services.AddSingleton<Chips_Page_MVVM>(); // if AddSingleton is used the page stays in memory and page is reused
    //builder.Services.AddSingleton<EditChipPage_MVVM>(); // AddTransient creates new page each time.
    //builder.Services.AddSingleton<AddChipPage_MVVM>();
    builder.Services.AddTransient<Chips_Page_MVVM>();
    builder.Services.AddTransient<EditChipPage_MVVM>();
    builder.Services.AddTransient<AddChipPage_MVVM>();

    return builder.Build();
  }
}
