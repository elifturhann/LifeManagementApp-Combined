using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace LifeManagementApp1.ViewModel;

public partial class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
        Items = new ObservableCollection<string>();
    }

    [ObservableProperty]
    ObservableCollection<string> items;

    [ObservableProperty]
    string text;

    [RelayCommand]
    void Add()
    {
        if (string.IsNullOrWhiteSpace(Text))
            return;

        Items.Add(Text);
        Text = string.Empty;
    }
     [RelayCommand]
     void Delete(string s){
        if(Items.Contains(s)){
            Items.Remove(s);
        }
     }
     [RelayCommand]
     async Task Tap (string s){
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
     }

     [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("//LandingPage"); // Navigates back in the Shell stack
    }

}
