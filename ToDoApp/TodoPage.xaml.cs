using LifeManagementApp1.ViewModel;

namespace LifeManagementApp1;

public partial class TodoPage : ContentPage
{
	

	public TodoPage(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	

	

}

