using ProsperDaily.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperDaily.MVVM.ViewModels
{
    public class DashboardViewModel
    {
        public DashboardViewModel()
        {
            FillData();
        }


        public ObservableCollection<Transaction> Transactions { get; set; }


        public decimal Balance { get; set; }

        public decimal Income { get; set; }

        public decimal Expenses { get; set; }



        public void FillData()
        {
            var transactions = App.transactionRepository.GetItems();

            transactions = transactions.OrderByDescending(t => t.OperationDate).ToList();

            Transactions = new ObservableCollection<Transaction>(transactions);

            Balance = 0;

            Income = 0;

            Expenses = 0;

            foreach (var transaction in Transactions)
            {
                if (transaction.IsIncome)
                {
                    Income += transaction.Amount;
                }
                else
                {
                    Expenses += transaction.Amount;
                }

                Balance = Income - Expenses;
            }
        }

    }
}
