using Expense_Manager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Manager.Services.TransactionService
{
    public interface ITransactionService
    {
        object addTransaction(TransactionAddDto transactionAddDto);
        object updateTransaction();
        object deleteTransaction();
    }
}
