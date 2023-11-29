namespace Contacts.Maui
{
	internal static class Helper
	{
		public static readonly List<string> Names = new();
//		public static bool IsEdit;
		public static int GameId;
		public static int ChipsetId;

		public static void Add(string name)
		{
			Names.Add(name);
		}
		public static void Clear()
		{
			Names.Clear();
		}

		public static async void ShowMessage(string message)
		{
			await Application.Current.MainPage.DisplayAlert("Note", message, "OK");
		}
	}
}
