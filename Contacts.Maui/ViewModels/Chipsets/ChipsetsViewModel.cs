using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.Maui.Views_MVVM.Chipsets;
using Contacts.UseCases.Interfaces.Chipsets;
using System.Collections.ObjectModel;
using Contacts.CoreBusiness;
using Contacts.Maui.Views_MVVM;
using Contacts.Maui.Views_MVVM.Chips;
using Contacts.UseCases.Interfaces.Chips;
using System.Reflection.Metadata;

namespace Contacts.Maui.ViewModels.Chipsets
{
	public partial class ChipsetsViewModel : ObservableObject
	{
		private readonly IViewChipsetsUseCase viewChipsetsUseCase;
		private readonly IDeleteChipsetUseCase deleteChipsetUseCase;
		private readonly IViewChipsUseCase viewChipsUseCase;
		private readonly IEditChipsetUseCase editChipsetUseCase;

		public ObservableCollection<Chipset> Chipsets { get; set; }

		public ChipsetsViewModel(
				IViewChipsetsUseCase viewChipsetsUseCase,
				IDeleteChipsetUseCase deleteChipsetUseCase,
				IViewChipsUseCase viewChipsUseCase,
				IEditChipsetUseCase editChipsetUseCase
				)
		{
			Chipsets = new ObservableCollection<Chipset>();

			this.viewChipsetsUseCase = viewChipsetsUseCase;
			this.deleteChipsetUseCase = deleteChipsetUseCase;
			this.viewChipsUseCase = viewChipsUseCase;
			this.editChipsetUseCase = editChipsetUseCase;
		}

		public async Task LoadChipsets()
		{
			Chipsets.Clear();

			var chipsets = await viewChipsetsUseCase.ExecuteAsync(Helper.ChipsetId.ToString());

			if (chipsets != null && chipsets.Count > 0)
				foreach (var chipset in chipsets)
				{
					string denominations = "";

					var chips = await viewChipsUseCase.ExecuteAsync(chipset.ChipsetId.ToString());

					foreach (var chip in chips)
						if (chip.Denomination >= 1000000)
							denominations += (chip.Denomination / 1000000).ToString() + "M, ";
						else if (chip.Denomination >= 1000)
							denominations += (chip.Denomination / 1000).ToString() + "K, ";
						else
							denominations += chip.Denomination.ToString() + ", ";

					if (denominations.EndsWith(", "))
						denominations = denominations.Substring(0, denominations.Length - 2);

					chipset.Denominations = denominations;

					await editChipsetUseCase.ExecuteAsync(chipset.ChipsetId, chipset);

					Chipsets.Add(chipset);
				}
		}

		[RelayCommand]
		public async Task DeleteChipset(int chipsetId)
		{
			await deleteChipsetUseCase.ExecuteAsync(chipsetId);

			await LoadChipsets();
		}

		[RelayCommand]
		public async Task GotoEditChipset(int chipsetId)
		{
			await Shell.Current.GoToAsync($"{nameof(EditChipsetPage_MVVM)}?ChipsetId={chipsetId}");
		}

		[RelayCommand]
		public async Task GotoAddChipset()
		{
			await Shell.Current.GoToAsync(nameof(AddChipsetPage_MVVM));
		}

		[RelayCommand]
		public async Task GotoHome()
		{
			await Shell.Current.GoToAsync("..");
		}

		[RelayCommand]
		public async Task GotoChips()
		{
			await Shell.Current.GoToAsync(nameof(Chips_Page_MVVM));
		}
	}
}
