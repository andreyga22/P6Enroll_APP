using P6Enroll_APP.Models;
using P6Enroll_APP.ViewModels;

namespace P6Enroll_APP.Views;

public partial class LocationView : ContentPage
{
    LocationViewModel? vm;
    P6Enroll_APP.Models.Location currentLocation;
    public LocationView()
	{
		InitializeComponent();
        BindingContext = vm = new LocationViewModel();
        LoadLocations();
    }

    private async void LoadLocations() {
        CboxLocation.ItemsSource = await vm.GetAllUsersAsync();
    }

    private void CboxLocation_SelectedIndexChanged(object sender, EventArgs e) {
        if (CboxLocation.SelectedItem != null) {
            currentLocation = (Models.Location)CboxLocation.SelectedItem;
            TxtId.Text = ""+currentLocation.Id;
            TxtIdLocation.Text = currentLocation.IdLocation;
            TxtName.Text = currentLocation.Name;
            TxtAddress.Text = currentLocation.Address;
        }
    }

    private void cleanUp() {
        TxtId.Text = "";
        TxtIdLocation.Text = "";
        TxtName.Text = "";
        TxtAddress.Text = "";
    }

    private async void BtnSave_Clicked(object sender, EventArgs e) {
        P6Enroll_APP.Models.Location newLocation =new Models.Location();

        newLocation.Id = (int)Convert.ToInt64(TxtId.Text);
        newLocation.IdLocation = TxtIdLocation.Text;
        newLocation.Name = TxtName.Text;
        newLocation.Address = TxtAddress.Text;

        await vm.modifyLocationAsync(newLocation);
    }

    private void BtnClean_Clicked(object sender, EventArgs e) {
        cleanUp();
    }
}