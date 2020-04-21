using Expense_Manager.Views.Report;
using Expense_Manager.Views.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expense_Manager
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void categoryViewBtn_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TransactionHome transactionHome = new TransactionHome();
            transactionHome.Show();
        }

        private void reportBtn_Click(object sender, EventArgs e)
        {
            ReportHome reportHome = new ReportHome();
            reportHome.Show();
        }
    }
}
