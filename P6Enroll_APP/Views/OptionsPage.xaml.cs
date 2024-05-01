
namespace P6Enroll_APP.Views;

public partial class OptionsPage : ContentPage
{
	public OptionsPage()
	{
		InitializeComponent();
	}

    private async Task BtnLocations_ClickedAsync(object sender, EventArgs e) {
        
    }

    private void BtnLocations_Clicked(object sender, EventArgs e) {

    }

    private async void BtnLocations_Clicked_1(object sender, EventArgs e) {
        await Navigation.PushAsync(new P6Enroll_APP.Views.LocationView());
    }
}