using P6Enroll_APP.ViewModels;

namespace P6Enroll_APP.Views;

public partial class StudentView : ContentPage
{
    StudentViewModel? vm;
    P6Enroll_APP.Models.Student currentStudent;

    public StudentView()
	{
		InitializeComponent();
        BindingContext = vm = new StudentViewModel();
        LoadStudents();

    }

    private async void LoadStudents() {
        CboxStudents.ItemsSource = await vm.GetAllStudentsAsync();
    }

    private async void BtnSave_Clicked(object sender, EventArgs e) {
        try {
            P6Enroll_APP.Models.Student newStudent = new Models.Student();
            newStudent.Id = (int)Convert.ToInt64(TxtId.Text);
            newStudent.IdStudent = TxtIdStudent.Text;
            newStudent.Name = TxtName.Text;
            newStudent.BirthDate = TxtBirthDate.Text;
            newStudent.Address = TxtAddress.Text;
            newStudent.Phone = TxtPhone.Text;
            newStudent.Email = TxtEmail.Text;


           



            if (String.IsNullOrEmpty(TxtId.Text)) {
                newStudent.Id = 0;
                bool saved = await vm.InsertStudentAsync(newStudent);
                if (saved) {
                    await DisplayAlert(":)", "Student saved", "OK");
                    CleanUp();
                } else {
                    await DisplayAlert(":(", "Error saving student", "OK");
                    CleanUp();
                }
            } else {
                bool saved = await vm.ModifyStudentAsync(newStudent);
                if (!saved) {
                    await DisplayAlert(":)", "Student Updated", "OK");
                    CleanUp();
                } else {
                    await DisplayAlert(":(", "Error updating student", "OK");
                    CleanUp();
                }
            }
        } catch (Exception) {
            throw;
        }
        LoadStudents();

    }

    private void BtnClean_Clicked(object sender, EventArgs e) {
        CleanUp();
    }

    private void CboxStudents_SelectedIndexChanged(object sender, EventArgs e) {
        if (CboxStudents.SelectedItem != null) {
            currentStudent = (Models.Student)CboxStudents.SelectedItem;
            TxtId.Text = "" + currentStudent.Id;
            TxtIdStudent.Text = "" + currentStudent.IdStudent;
            TxtName.Text = currentStudent.Name;
            TxtBirthDate.Text = currentStudent.BirthDate.ToString();
            TxtAddress.Text = currentStudent.Address;
            TxtPhone.Text = currentStudent.Phone;
            TxtEmail.Text = currentStudent.Email;
        }

    }

    private void CleanUp() {
        TxtId.Text = "";
        TxtIdStudent.Text = "";
        TxtName.Text = "";
        TxtBirthDate.Text = "";
        TxtAddress.Text = "";
        TxtPhone.Text = "";
        TxtEmail.Text = "";
    }

}