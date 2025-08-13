using ProsperDaily.MVVM.ViewModels;

namespace ProsperDaily.MVVM.Views;

public partial class TransactionPage : ContentPage
{
	public TransactionPage()
	{
		InitializeComponent();

		BindingContext = new TransactionViewModel();
    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
        var currentVM = (TransactionViewModel)BindingContext;

        var message = currentVM.SaveTransaction();

        await DisplayAlert("Info", message, "Ok");

        await Navigation.PopToRootAsync();

    }

    private async void Cancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}