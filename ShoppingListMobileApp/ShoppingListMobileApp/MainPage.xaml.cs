namespace ShoppingListMobileApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			SignInBtn.Text = $"Clicked {count} time";
		else
			SignInBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(SignInBtn.Text);
	}
}


