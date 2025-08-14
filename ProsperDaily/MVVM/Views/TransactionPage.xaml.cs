using ProsperDaily.MVVM.ViewModels;

namespace ProsperDaily.MVVM.Views;

public partial class TransactionPage : ContentPage
{
	public TransactionPage()
	{
		InitializeComponent();

		BindingContext = new TransactionViewModel();
    }

    private void Save_Clicked(object sender, EventArgs e)
    {
        var currentVM = (TransactionViewModel)BindingContext;

        var message = currentVM.SaveTransaction();

        DisplayAlert("Info", message, "Ok");

        Navigation.PopAsync();
    }

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}