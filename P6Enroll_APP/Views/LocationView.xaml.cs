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
        
        try {
            P6Enroll_APP.Models.Location newLocation = new Models.Location();
            newLocation.Id = (int)Convert.ToInt64(TxtId.Text);
            newLocation.IdLocation = TxtIdLocation.Text;
            newLocation.Name = TxtName.Text;
            newLocation.Address = TxtAddress.Text;
            
            if (String.IsNullOrEmpty(TxtId.Text)) {
                newLocation.Id = 0;
                bool saved = await vm.insertLocationAsync(newLocation);
                if (saved) {
                    await DisplayAlert(":)", "Location saved", "OK");
                    cleanUp();
                } else {
                    await DisplayAlert(":(", "Error saving location", "OK");
                    cleanUp();
                }
            } else {
                bool saved = await vm.modifyLocationAsync(newLocation);
                if (!saved) {
                    await DisplayAlert(":)", "Location Updated", "OK");
                    cleanUp();
                } else {
                    await DisplayAlert(":(", "Error updating location", "OK");
                    cleanUp();
                }
            }
            
        }catch (Exception) {
            throw;
        }
        LoadLocations();
    }

    private void BtnClean_Clicked(object sender, EventArgs e) {
        cleanUp();
    }
}