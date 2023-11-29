using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.Maui.Views_MVVM.Payouts;
using Contacts.UseCases.Interfaces.Payouts;
using Contacts.CoreBusiness;

namespace Contacts.Maui.ViewModels.Payouts
{
	public partial class PayoutViewModel : ObservableObject
	{
		private Payout payout;
		private readonly IViewPayoutUseCase viewPayoutUseCase;
		private readonly IEditPayoutUseCase editPayoutUseCase;
		private readonly IAddPayoutUseCase addPayoutUseCase;

		public Payout Payout
		{
			get => payout;
			set => SetProperty(ref payout, value);
		}

		public bool IsNameProvided { get; set; }

		public PayoutViewModel(
				IViewPayoutUseCase viewPayoutUseCase,
				IEditPayoutUseCase editPayoutUseCase,
				IAddPayoutUseCase addPayoutUseCase)
		{
			Payout = new Payout();

			this.viewPayoutUseCase = viewPayoutUseCase;
			this.editPayoutUseCase = editPayoutUseCase;
			this.addPayoutUseCase = addPayoutUseCase;
		}

		public async Task LoadPayout(int payoutId)
		{
			Payout = await viewPayoutUseCase.ExecuteAsync(payoutId);
		}

		[RelayCommand]
		public async Task EditPayout()
		{
			await editPayoutUseCase.ExecuteAsync(payout.PayoutId, payout);
			await Shell.Current.GoToAsync("..");
		}

		[RelayCommand]
		public async Task AddPayout()
		{
			await addPayoutUseCase.ExecuteAsync(payout);
			await Shell.Current.GoToAsync("..");
		}

		[RelayCommand]
		public async Task BackToPayouts()
		{
			await Shell.Current.GoToAsync("..");
		}
	}
}
