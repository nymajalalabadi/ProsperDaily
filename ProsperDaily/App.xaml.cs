using ProsperDaily.MVVM.Models;
using ProsperDaily.MVVM.Views;
using ProsperDaily.Repositories;

namespace ProsperDaily
{
    public partial class App : Application
    {
        public static BaseRepository<Transaction> _transactionRepository { get; private set; }

        public App(BaseRepository<Transaction> transactionRepository)
        {
            InitializeComponent();
            _transactionRepository = transactionRepository;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new TransactionPage());
        }
    }
}