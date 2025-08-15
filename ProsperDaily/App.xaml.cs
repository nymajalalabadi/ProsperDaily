using ProsperDaily.MVVM.Models;
using ProsperDaily.MVVM.Views;
using ProsperDaily.Repositories;

namespace ProsperDaily
{
    public partial class App : Application
    {
        public static BaseRepository<Transaction> transactionRepository { get; private set; }

        public App(BaseRepository<Transaction> _transactionRepository)
        {
            SQLitePCL.Batteries.Init();

            InitializeComponent();

            transactionRepository = _transactionRepository;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new AppContainer()));
        }
    }
}