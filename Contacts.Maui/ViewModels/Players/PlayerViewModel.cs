using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.Maui.Views_MVVM.Players;
using Contacts.UseCases.Interfaces.Players;
using Contacts.CoreBusiness;

namespace Contacts.Maui.ViewModels.Players
{
	public partial class PlayerViewModel : ObservableObject
	{
		private Player player;
		private readonly IViewPlayerUseCase viewPlayerUseCase;
		private readonly IEditPlayerUseCase editPlayerUseCase;
		private readonly IAddPlayerUseCase addPlayerUseCase;

		public Player Player
		{
			get => player;
			set => SetProperty(ref player, value);
		}

		public bool IsNameProvided { get; set; }

		public PlayerViewModel(
				IViewPlayerUseCase viewPlayerUseCase,
				IEditPlayerUseCase editPlayerUseCase,
				IAddPlayerUseCase addPlayerUseCase)
		{
			Player = new Player();

			this.viewPlayerUseCase = viewPlayerUseCase;
			this.editPlayerUseCase = editPlayerUseCase;
			this.addPlayerUseCase = addPlayerUseCase;
		}

		public async Task LoadPlayer(int playerId)
		{
			Player = await viewPlayerUseCase.ExecuteAsync(playerId);
		}

		[RelayCommand]
		public async Task EditPlayer()
		{
			if (await ValidatePlayer())
			{
				await editPlayerUseCase.ExecuteAsync(player.PlayerId, player);
				await Shell.Current.GoToAsync("..");
			}
		}

		[RelayCommand]
		public async Task AddPlayer()
		{
			if (await ValidatePlayer())
			{
				await addPlayerUseCase.ExecuteAsync(player);
				await Shell.Current.GoToAsync("..");
			}
		}

		[RelayCommand]
		public async Task BackToPlayers()
		{
			await Shell.Current.GoToAsync("..");
		}

		private async Task<bool> ValidatePlayer()
		{
			if (!IsNameProvided)
			{
				await Application.Current.MainPage.DisplayAlert("Error", "Name is required.", "OK");
				return false;
			}

			return true;
		}
	}
}
