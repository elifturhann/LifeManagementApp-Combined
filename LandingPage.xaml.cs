namespace LifeManagementApp1;

public partial class LandingPage : ContentPage
{
    public LandingPage()
    {
        InitializeComponent();
    }

    private async void OnWeatherButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Weather");
    }

    private async void OnToDoButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ToDo");
    }
}
