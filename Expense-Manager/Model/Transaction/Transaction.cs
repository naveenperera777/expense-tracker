using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Manager.Model.Transaction
{
    class Transaction
    {
        public int transactionId { get; set; }
        public int categoryId { get; set; }
        public string transactionName { get; set; }
        public double transactionAmount { get; set; }
        public DateTime transactionDate { get; set; }
        public string transactionNote { get; set; }
                     
    }
}
