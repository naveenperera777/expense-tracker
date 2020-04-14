using Expense_Manager.DTO;
using Expense_Manager.Services.TransactionService;
using System;
using System.Collections.Generic;
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
    }
}
