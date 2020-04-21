using Expense_Manager.Controller;
using Expense_Manager.DTO;
using Expense_Manager.Services.CategoryService;
using Expense_Manager.Services.TransactionService;
using MySql.Data.MySqlClient;
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
    public partial class EditTransaction : Form
    {
        public TransactionController transactionController;
        public CategoryController categoryController;
        public ITransactionService transactionService = new TransactionServiceImpl();
        public ICategoryService categoryService = new CategoryServiceImpl();
        TransactionHome _transactionHome;
        private TransactionEditDto transactionEditDto = new TransactionEditDto();

        private int transactionId;
        public EditTransaction()
        {
            transactionController = new TransactionController(transactionService);
            categoryController = new CategoryController(categoryService);
            InitializeComponent();
        }

        public EditTransaction(TransactionHome transactionHome, TransactionEditDto transactionEdit)
        {
            InitializeComponent();
            transactionController = new TransactionController(transactionService);
            categoryController = new CategoryController(categoryService);
            _transactionHome = transactionHome;
            this.FormClosing += new FormClosingEventHandler(this.EditTransactionClosing);

            this.transactionEditDto = transactionEdit;
            transactionName.Text = transactionEdit.transactionName;
            transactionAmount.Text = (transactionEdit.transactionAmount).ToString();
            transactionNote.Text = transactionEdit.transactionNote;
            dateTimePicker1.Value = transactionEdit.transactionDate;
            this.transactionId = int.Parse(transactionEdit.transactionId);
            comboBox1.SelectedItem = "test1";

        }

     
        private void EditTransactionClosing(object sender, FormClosingEventArgs e)
        {
            _transactionHome.PerformRefresh();
        }


        private void transactionName_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            transactionEditDto.transactionName = transactionName.Text;
            transactionEditDto.transactionAmount = Double.Parse(transactionAmount.Text);
            transactionEditDto.transactionNote = transactionNote.Text;
            transactionEditDto.transactionDate = dateTimePicker1.Value;
            KeyValuePair<string, int> keyValue = (KeyValuePair<string, int>)comboBox1.SelectedItem;
            transactionEditDto.categoryId = keyValue.Value;

            object response = transactionController.updateTransactions(transactionEditDto);

            if (response is Exception)
            {
                MessageBox.Show("Error Updating Transaction");
            }
            else
            {
                MessageBox.Show("Transaction Updated Successfully");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void EditTransactionLoad(object sender, EventArgs e)
        {
            MySqlDataReader reader = categoryController.getAllCategories();
            while (reader.Read())
            {
                comboBox1.Items.Add(new KeyValuePair<string, int>(reader["categoryName"].ToString(), reader.GetInt32("categoryId")));

                comboBox1.DisplayMember = "key";
                comboBox1.ValueMember = "value";

            }
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                object response = transactionController.deleteTransaction(this.transactionId);


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
