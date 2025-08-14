using ProsperDaily.MVVM.ViewModels;
using System.Threading.Tasks;

namespace ProsperDaily.MVVM.Views;

public partial class DashboardPage : ContentPage
{
	public DashboardPage()
	{
		InitializeComponent();
		BindingContext = new DashboardViewModel();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var vm = (DashboardViewModel)BindingContext;

        vm.FillData();
    }

    private void AddTransaction_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TransactionPage());
    }
}