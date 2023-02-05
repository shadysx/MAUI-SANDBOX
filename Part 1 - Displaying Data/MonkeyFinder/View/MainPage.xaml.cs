namespace MonkeyFinder.View;

public partial class MainPage : ContentPage
{
	public MainPage(MonkeysViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}

