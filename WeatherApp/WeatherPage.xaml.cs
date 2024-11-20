namespace LifeManagementApp1{

    public partial class WeatherPage : ContentPage{
    public WeatherPage()
    {
        InitializeComponent();
    }
     private async void GoBackToLanding(object sender, EventArgs e)
        {
            // Navigate to the LandingPage
            await Shell.Current.GoToAsync("//LandingPage");
        }
}


}


