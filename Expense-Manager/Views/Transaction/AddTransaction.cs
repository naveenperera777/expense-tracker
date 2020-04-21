using Expense_Manager.Controller;
using Expense_Manager.DTO;
using Expense_Manager.Model.Category;
using Expense_Manager.Repository;
using Expense_Manager.Services.EntityService;
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
        public EntityController entityController;
        public IEntityService entityService = new EntityServiceImpl();
        public ITransactionService transactionService = new TransactionServiceImpl();
        DBAccess dBAccess = new DBAccess();
        TransactionHome _transactionHome;

        public AddTransaction(TransactionHome transactionHome)
        {
            InitializeComponent();
            this._transactionHome = transactionHome;
            this.FormClosing += new FormClosingEventHandler(this.EditTransactionClosing);
            transactionController = new TransactionController(transactionService);
            entityController = new EntityController(entityService);
          

        }

        private void EditTransactionClosing(object sender, FormClosingEventArgs e)
        {
            _transactionHome.PerformRefresh();
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
            DateTime tansaction_date = dateTimePicker1.Value;

            TransactionAddDto transactionAdd = new TransactionAddDto();
            transactionAdd.transactionName = transaction_Name;
            transactionAdd.transactionNote = transaction_notes;
            transactionAdd.transactionAmount = transaction_Amount;
            transactionAdd.transactionDate = tansaction_date;

            KeyValuePair<string, int> keyValueCategory = (KeyValuePair<string, int>)comboBox2.SelectedItem;
            KeyValuePair<string, int> keyValueEntity = (KeyValuePair<string, int>)entityComboBox.SelectedItem;

            int categoryValue = keyValueCategory.Value;
            int EntityValue = keyValueEntity.Value;


            transactionAdd.categoryId = categoryValue;
            transactionAdd.entityId = EntityValue;

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
            while (reader.Read())
            {
                CategoryRetrieveDto category = new CategoryRetrieveDto();
                category.categoryName = reader["categoryName"].ToString();
                category.categoryLimit = reader.GetDouble("categoryLimit");
                category.categoryType = reader["categoryType"].ToString();
                category.categoryId = reader.GetInt32("categoryId");

                comboBox2.Items.Add(new KeyValuePair<string, int>(reader["categoryName"].ToString(), reader.GetInt32("categoryId")));

                comboBox2.DisplayMember = "key";
                comboBox2.ValueMember = "value";

            }
            reader.Close();

            MySqlDataReader entityReader = entityController.getAllEntities();

            while (entityReader.Read())
            {

                entityComboBox.Items.Add(new KeyValuePair<string, int>(entityReader["entityName"].ToString(), entityReader.GetInt32("entityId")));
                entityComboBox.DisplayMember = "key";
                entityComboBox.ValueMember = "value";

            }
            entityReader.Close();



        }

        private void entityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

