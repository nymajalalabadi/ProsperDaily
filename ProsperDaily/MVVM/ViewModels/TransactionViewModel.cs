using PropertyChanged;
using ProsperDaily.MVVM.Models;

namespace ProsperDaily.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class TransactionViewModel
    {
        public Transaction Transaction { get; set; } = new Transaction()
        {
            OperationDate = DateTime.Now,
        };


        public string SaveTransaction()
        {
            App.transactionRepository.SaveItem(Transaction);

            return App.transactionRepository.StatusMessage;
        }
    }
}
