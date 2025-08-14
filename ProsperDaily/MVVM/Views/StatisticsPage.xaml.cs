using ProsperDaily.MVVM.ViewModels;

namespace ProsperDaily.MVVM.Views;

public partial class StatisticsPage : ContentPage
{
	public StatisticsPage()
	{
		InitializeComponent();

		BindingContext = new StatisticsViewModel();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var vm = (StatisticsViewModel)BindingContext;

        vm.GetTransactionsSummary();
    }
}