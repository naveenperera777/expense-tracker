using Expense_Manager.Controller;
using Expense_Manager.DTO;
using Expense_Manager.Services.TransactionService;
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
        public TransactionController transactionController;
        public ITransactionService transactionService = new TransactionServiceImpl();

        DataTable dataTable = new DataTable();


        public TransactionHome()
        {
            InitializeComponent();
            transactionController = new TransactionController(transactionService);
            object allTransactions = transactionController.GetAllTransacttions(dataTable);
            dataGridView1.DataSource = allTransactions;
        }

   

        private void button1_Click(object sender, EventArgs e)
        {
            AddTransaction addTransaction = new AddTransaction(this);
            addTransaction.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AllTransactions allTransactions = new AllTransactions();
            allTransactions.Show();
        }

        public void PerformRefresh()
        {
            dataGridView1.DataSource = null;
            DataTable UpdatedTable = new DataTable();
            object newTransactions = transactionController.GetAllTransacttions(UpdatedTable);
            dataGridView1.DataSource = newTransactions;
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = this.dataGridView1.CurrentRow.Cells["transactionName"].Value.ToString();
            string id = this.dataGridView1.CurrentRow.Cells["transactionId"].Value.ToString();
            double amount = double.Parse(this.dataGridView1.CurrentRow.Cells["transactionAmount"].Value.ToString());
            int categoryId = int.Parse(this.dataGridView1.CurrentRow.Cells["categoryId"].Value.ToString());
            string note = this.dataGridView1.CurrentRow.Cells["transactionNote"].Value.ToString();
            DateTime date = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["transactionDate"].Value.ToString());

            TransactionEditDto transactionEditDto = new TransactionEditDto();
            transactionEditDto.transactionId = id;
            transactionEditDto.categoryId = categoryId;
            transactionEditDto.transactionAmount = amount;
            transactionEditDto.transactionNote = note;
            transactionEditDto.transactionName = name;
            transactionEditDto.transactionDate = date;

            EditTransaction editTransaction = new EditTransaction(this, transactionEditDto);
            editTransaction.Show();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BulkTransaction bulkTransaction = new BulkTransaction();
            bulkTransaction.Show();
        }
    }
}



