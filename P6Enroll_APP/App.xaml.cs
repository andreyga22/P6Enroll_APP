using P6Enroll_APP.Views;

namespace P6Enroll_APP {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            MainPage = new NavigationPage(new P6Enroll_APP.Views.LocationView());
        }
    }
}
