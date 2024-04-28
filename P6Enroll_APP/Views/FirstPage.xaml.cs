using P6Enroll_APP.Models;
using P6Enroll_APP.ViewModels;

namespace P6Enroll_APP.Views;

public partial class FirstPage : ContentPage
{
    LocationViewModel? vm;
	public FirstPage()
	{
		InitializeComponent();
        BindingContext = vm = new LocationViewModel();
        LoadLocations();

    }

    private async void LoadLocations() {
        CboxLocation.ItemsSource = await vm.GetAllUsersAsync();

    }
}