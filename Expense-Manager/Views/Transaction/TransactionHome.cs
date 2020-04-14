using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expense_Manager.Views.Transaction
{
    public partial class TransactionHome : Form
    {
        public TransactionHome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTransaction addTransaction = new AddTransaction();
            addTransaction.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AllTransactions allTransactions = new AllTransactions();
            allTransactions.Show();
        }
    }
}
