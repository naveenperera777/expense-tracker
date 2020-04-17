using Expense_Manager.DTO;
using Expense_Manager.Model.Transaction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Manager.Services.TransactionService
{
    public interface ITransactionService
    {
        object addTransaction(TransactionAddDto transactionAddDto);
        object deleteTransaction(int transactionId);
        object getAllTransactions(DataTable dataTable);
        object updateTransactions(TransactionEditDto transactionEditDto);
    }
}
