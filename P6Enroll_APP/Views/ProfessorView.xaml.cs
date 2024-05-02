namespace P6Enroll_APP.Views;
using P6Enroll_APP.Models;
using P6Enroll_APP.ViewModels;
using System.Xml.Linq;

public partial class ProfessorView : ContentPage
{

    ProfessorViewModel? vm;
    P6Enroll_APP.Models.Professor currentProfessor;


    public ProfessorView()
	{
		
        InitializeComponent();
        BindingContext = vm = new ProfessorViewModel();
        LoadProfessors();

    }
    private async void LoadProfessors()
    {
        CboxProfessor.ItemsSource = await vm.GetAllUsersAsync();
    }



    private async void BtnSave_Clicked(object sender, EventArgs e)
    {
        try
        {
            P6Enroll_APP.Models.Professor newProfessor = new Models.Professor();

            newProfessor.Id = (int)Convert.ToInt64(TxtId.Text);
            newProfessor.IdProfessor = TxtIdProfessor.Text;
            newProfessor.Name = TxtName.Text;
            newProfessor.Email = TxtEmail.Text;
            newProfessor.Phone = TxtPhone.Text;
            newProfessor.Assignment = TxtAssignment.Text;

            if (String.IsNullOrEmpty(TxtId.Text))
            {
                newProfessor.Id = 0;
                bool saved = await vm.insertProfessorAsync(newProfessor);
                if (saved)
                {
                    await DisplayAlert(":)", "Professor saved", "OK");
                    cleanUp();
                }
                else
                {
                    await DisplayAlert(":(", "Error saving Professor", "OK");
                    cleanUp();
                }
            }
            else
            {
                bool saved = await vm.modifyProfessorAsync(newProfessor);
                if (!saved)
                {
                    await DisplayAlert(":)", "Professor Updated", "OK");
                    cleanUp();
                }
                else
                {
                    await DisplayAlert(":(", "Error updating Professor", "OK");
                    cleanUp();
                }
            }

        }
        catch (Exception)
        {
            throw;
        }
        LoadProfessors();
    }

    private void BtnClean_Clicked(object sender, EventArgs e)
    {
        cleanUp();
    }

    private void CboxProfessor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CboxProfessor.SelectedItem != null)
        {
            currentProfessor = (Models.Professor)CboxProfessor.SelectedItem;
            TxtId.Text = "" + currentProfessor.Id;
            TxtIdProfessor.Text = currentProfessor.IdProfessor;
            TxtName.Text = currentProfessor.Name;
            TxtEmail.Text = currentProfessor.Email;
            TxtPhone.Text = currentProfessor.Phone;
            TxtAssignment.Text = currentProfessor.Assignment;
        }
    }

    private void cleanUp()
    {
        TxtId.Text = "";
        TxtIdProfessor.Text = "";
        TxtName.Text = "";
        TxtEmail.Text = "";
        TxtPhone.Text = "";
        TxtAssignment.Text = "";
    }

    //Cierre total
}