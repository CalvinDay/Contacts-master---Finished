using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.Maui.Views_MVVM.Chipsets;
using Contacts.UseCases.Interfaces.Chipsets;
using Contacts.CoreBusiness;

namespace Contacts.Maui.ViewModels.Chipsets
{
	public partial class ChipsetViewModel : ObservableObject
	{
		private Chipset chipset;
		private readonly IViewChipsetUseCase viewChipsetUseCase;
		private readonly IEditChipsetUseCase editChipsetUseCase;
		private readonly IAddChipsetUseCase addChipsetUseCase;

		public Chipset Chipset
		{
			get => chipset;
			set => SetProperty(ref chipset, value);
		}

		public bool IsNameProvided { get; set; }

		public ChipsetViewModel(
				IViewChipsetUseCase viewChipsetUseCase,
				IEditChipsetUseCase editChipsetUseCase,
				IAddChipsetUseCase addChipsetUseCase)
		{
			this.Chipset = new Chipset();
			this.viewChipsetUseCase = viewChipsetUseCase;
			this.editChipsetUseCase = editChipsetUseCase;
			this.addChipsetUseCase = addChipsetUseCase;
		}

		public async Task LoadChipset(int chipsetId)
		{
			Chipset = await viewChipsetUseCase.ExecuteAsync(chipsetId);
		}

		[RelayCommand]
		public async Task EditChipset()
		{
			await editChipsetUseCase.ExecuteAsync(chipset.ChipsetId, chipset);
			await Shell.Current.GoToAsync("..");
		}

		[RelayCommand]
		public async Task AddChipset()
		{
			await addChipsetUseCase.ExecuteAsync(chipset);
			await Shell.Current.GoToAsync("..");
		}

		[RelayCommand]
		public async Task BackToChipsets()
		{
			await Shell.Current.GoToAsync("..");
		}
	}
}
