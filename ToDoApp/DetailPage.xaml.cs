using LifeManagementApp1.ViewModel;


namespace LifeManagementApp1;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailViewModel vm){
        
        InitializeComponent();
       BindingContext = vm;
	
    }

   
}
