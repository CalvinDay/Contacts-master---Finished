using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.Maui.Views_MVVM.Blinds;
using System.Collections.ObjectModel;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Blinds;
using Contacts.Maui.Views_MVVM.Games;
using Contacts.UseCases.Interfaces.Games;
using Contacts.UseCases.Interfaces.Chips;

namespace Contacts.Maui.ViewModels.Blinds
{
	public partial class BlindsViewModel : ObservableObject
	{
		private readonly IViewBlindsUseCase viewBlindsUseCase;
		private readonly IDeleteBlindUseCase deleteBlindUseCase;
		private readonly IRebuyBlindUseCase rebuyBlindUseCase;
		private readonly IEditBlindUseCase editBlindUseCase;
		private readonly IViewGameUseCase viewGameUseCase;
		private readonly IViewChipsUseCase viewChipsUseCase;
		private readonly IAddBlindUseCase addBlindUseCase;

		public ObservableCollection<Blind> Blinds { get; set; }

		public BlindsViewModel(
				IViewBlindsUseCase viewBlindsUseCase,
				IDeleteBlindUseCase deleteBlindUseCase,
				IRebuyBlindUseCase rebuyBlindUseCase,
				IEditBlindUseCase editBlindUseCase,
				IViewGameUseCase viewGameUseCase,
				IViewChipsUseCase viewChipsUseCase,
				IAddBlindUseCase addBlindUseCase
				)
		{
			Blinds = new ObservableCollection<Blind>();

			this.viewBlindsUseCase = viewBlindsUseCase;
			this.deleteBlindUseCase = deleteBlindUseCase;
			this.rebuyBlindUseCase = rebuyBlindUseCase;
			this.editBlindUseCase = editBlindUseCase;
			this.viewGameUseCase = viewGameUseCase;
			this.viewChipsUseCase = viewChipsUseCase;
			this.addBlindUseCase = addBlindUseCase;
		}

		public async Task LoadBlinds()
		{
			Blinds.Clear();

			var blinds = await viewBlindsUseCase.ExecuteAsync(Helper.GameId.ToString());

			if (blinds != null && blinds.Count > 0)
				foreach (var blind in blinds)
					Blinds.Add(blind);
		}

		public int BestFit(double num, List<Chip> chips)
		{
			int i;
			int j;
			int best = 0;

			int[] test = new int[3];
			double[] error = new double[3];

			// loop here until num / denomination is greater than 1.0
			for (i = 1; i < chips.Count - 2; i++)
			{
				if ((num / chips[i].Denomination) > 1.0)
				{
					// calculate previous values plus 2 lower ones
					for (j = 0; j <= 2; j++)
					{
						test[j] = (int)(Math.Round(num / chips[i + j - 1].Denomination) * chips[i + j - 1].Denomination);
						error[j] = Math.Abs(test[j] - num) / num;
					}

					// see which one is closest
					if ((error[0] < error[1]) && (error[0] < error[2]))
						best = 0;
					else if ((error[1] < error[0]) && (error[1] < error[2]))
						best = 1;
					else
						best = 2;

					break;
				}
			}

			return test[best];
		}

		private async Task AddBlinds()
		{
			// most poker tournaments begin to end when 10 blinds are left
			const int blindsLeft = 10;

			Game game = await viewGameUseCase.ExecuteAsync(Helper.GameId);

			int duration = game.DurationExp;
			int blindTime = game.BlindTime;

			// levelCount should be duration / blindtime 
			int levelCount = duration / blindTime;

			int total = (game.PlayersExp * game.ChipsStart + game.RebuyExp * game.RebuyChips + game.AddonExp * game.AddonChips) / blindsLeft;

			var chips = await viewChipsUseCase.ExecuteAsync((game.ChipSet + 1).ToString());

			chips.Sort((x, y) => y.Denomination.CompareTo(x.Denomination));

			// the blinds should increase exponentially where y = a * b^x
			// a is the BlindStart and b = (total / a)^(1/levelCount)
			double a = game.BlindStart;
			double b = Math.Pow(total / a, 1.0 / levelCount);

			// add 8 more blind levels in case tournament lasts longer
			for (int i = 0; i < levelCount + 8; i++)
			{
				double target = a * Math.Pow(b, i);
				int actual = BestFit(target, chips);

        Blind blind = new()
        {
          GameId = Helper.GameId,
          BlindNo = i + 1,
          Amount = actual,
          Ante = (int)target
        };

        await addBlindUseCase.ExecuteAsync(blind);
			}
		}

		[RelayCommand]
		public async Task CreateBlinds()
		{
			Blinds.Clear();

			var blinds = await viewBlindsUseCase.ExecuteAsync(Helper.GameId.ToString());

			foreach (Blind blind in blinds)
				await deleteBlindUseCase.ExecuteAsync(blind.BlindId);

			await AddBlinds();

			await LoadBlinds();
		}

		[RelayCommand]
		public async Task DeleteBlind(int blindId)
		{
			await deleteBlindUseCase.ExecuteAsync(blindId);

			await LoadBlinds();
		}

		[RelayCommand]
		public async Task GotoEditBlind(int blindId)
		{
			await Shell.Current.GoToAsync($"{nameof(EditBlindPage_MVVM)}?BlindId={blindId}");
		}

		[RelayCommand]
		public async Task GotoAddBlind()
		{
			await Shell.Current.GoToAsync(nameof(AddBlindPage_MVVM));
		}

		[RelayCommand]
		public async Task GoBack()
		{
			await Shell.Current.GoToAsync("..");
		}
	}
}
