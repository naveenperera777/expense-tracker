using Expense_Manager.Controller;
using Expense_Manager.Repository;
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
    public partial class AllTransactions : Form
    {
        public TransactionController transactionController;
        public ITransactionService transactionService = new TransactionServiceImpl();

        DBAccess dBAccess = new DBAccess();
        DataTable dataTable = new DataTable();
        public AllTransactions()
        {
            InitializeComponent();
            transactionController = new TransactionController(transactionService);
            string sql = "select `transactionId`, `transactionName`, `transactionAmount`, `transactionNote`, `categoryId`, CAST(`transactionDate` AS DATETIME) AS trDate  from transaction";
            dBAccess.readDatathroughAdapter(sql, dataTable);
            dataGridView1.DataSource = dataTable;
            dBAccess.closeConn();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCell EventArgs e)
        {
     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            string str = row.Cells["transactionId"].Value.ToString();
            int transactionId = int.Parse(str);

            object response = transactionController.deleteTransaction(transactionId);


            if (response is Exception)
            {
                MessageBox.Show("Error Deleting Transaction");
            }
            else
            {
                MessageBox.Show("Transaction Deleted Successfully");
            }




        }
    }
}
