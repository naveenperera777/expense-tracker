using Expense_Manager.DTO;
using Expense_Manager.Services.TransactionService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Manager.Controller
{
    public class TransactionController
    {
        public ITransactionService transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        public object addTransaction(TransactionAddDto transactionAdd)
        {
            object response = transactionService.addTransaction(transactionAdd);
            return response;
        }

        public object deleteTransaction(int transactionId)
        {
            object response = transactionService.deleteTransaction(transactionId);
            return response;
        }

        public object GetAllTransacttions(DataTable dataTable)
        {
            object response = transactionService.getAllTransactions(dataTable);
            return response;
        }

        public object updateTransactions(TransactionEditDto transactionEditDto)
        {
            object response = transactionService.updateTransactions(transactionEditDto);
            return response;
        }
    }
}
