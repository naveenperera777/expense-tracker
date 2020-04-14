using Expense_Manager.Controller;
using Expense_Manager.DTO;
using Expense_Manager.Model.Category;
using Expense_Manager.Repository;
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
    public partial class AddTransaction : Form
    {
        public TransactionController transactionController;
        public ITransactionService transactionService = new TransactionServiceImpl();
        DBAccess dBAccess = new DBAccess();

        public AddTransaction()
        {
            InitializeComponent();
            transactionController = new TransactionController(transactionService);
          

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void submit_Click(object sender, EventArgs e)
        {
            string transaction_Name = transactionName.Text;
            double transaction_Amount = double.Parse(amount.Text);
            string transaction_notes = notes.Text;

            TransactionAddDto transactionAdd = new TransactionAddDto();
            transactionAdd.transactionName = transaction_Name;
            transactionAdd.transactionNote = transaction_notes;
            transactionAdd.transactionAmount = transaction_Amount;

            KeyValuePair<string, int> keyValue = (KeyValuePair<string, int>)comboBox2.SelectedItem;

            string key = keyValue.Key;
            int value = keyValue.Value;

            transactionAdd.categoryId = value;

            object response = transactionController.addTransaction(transactionAdd);


            if (response is Exception)
            {
                MessageBox.Show("Error Adding Category");
            }
            else
            {
                MessageBox.Show("Transaction Added Successfully");
            }


        }

        private void amount_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddTransaction_Load(object sender, EventArgs e)
        {
            String query = "select * from category";
            MySqlDataReader reader = dBAccess.readDatathroughReader(query);
            List<CategoryRetrieveDto> categories = new List<CategoryRetrieveDto>();
            while (reader.Read())
            {
                CategoryRetrieveDto category = new CategoryRetrieveDto();
                category.categoryName = reader["categoryName"].ToString();
                category.categoryLimit = reader.GetDouble("categoryLimit");
                category.categoryType = reader["categoryType"].ToString();
                category.categoryId = reader.GetInt32("categoryId");

                comboBox2.Items.Add(new KeyValuePair<string, int>(reader["categoryName"].ToString(), reader.GetInt32("categoryId")));

                categories.Add(category);
                comboBox2.DisplayMember = "key";
                comboBox2.ValueMember = "value";

            }
            reader.Close();

           
        }
    }
}
