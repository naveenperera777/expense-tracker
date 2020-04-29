using Expense_Manager.Controller;
using Expense_Manager.DTO;
using Expense_Manager.Services.CategoryService;
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
    public partial class BulkTransaction : Form
    {
        public TransactionController transactionController;
        public ITransactionService transactionService = new TransactionServiceImpl();
        public CategoryController categoryController;
        public ICategoryService categoryService = new CategoryServiceImpl();
        public EntityController entityController;
        public IEntityService entityService = new EntityServiceImpl();
        private int transactionCount = 0;
        TransactionHome _transactionHome;

        public BulkTransaction(TransactionHome transactionHome)
        {
            InitializeComponent();
            transactionController = new TransactionController(transactionService);
            categoryController = new CategoryController(categoryService);
            entityController = new EntityController(entityService);
            _transactionHome = transactionHome;

        }

        private void BulkTransaction_Load(object sender, EventArgs e)
        {
             
        }

        private void refreshTransactionList()
        {
            _transactionHome.PerformRefresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            transactionCount = int.Parse(numberTextBox.Text);
            if (transactionCount < 1)
            {
                MessageBox.Show("Transaction Count Cannot be less than one");
                return;
            }
            if (transactionCount > 6)
            {
                MessageBox.Show("Transaction Count Cannot be greater than six");
                return;
            }
            int startNameLabel = 0;
            int startText = 100;
            int startCategoryLabel = 200;
            int startCategoryCombo = 300;
            int startEntityLabel = 500;
            int startEntityCombo = 600;
            int startAmountLabel = 800;
            int startAmountText = 900;
            int starTimeLabel = 1000;
            int starPicker = 1100;



            int endNameLabel = 200;
            int endNameTextBox = 200;
            int endCategoryLabel = 200;
            int endCategoryComboLabel = 200;           
            int endEntityLabel = 200;            
            int endEntityCombo = 200;
            int endAmountLabel = 200;
            int endAmountText = 200;
            int endTimeLabel = 200;
            int endPicker = 200;


            for (int i = 0; i < transactionCount; i++)
            {
                Label Namelabel = addNameLabel(i, startNameLabel, endNameLabel);
                this.Controls.Add(Namelabel);
                endNameLabel += 70;
                TextBox textBox = addNameTextBox(i, startText, endNameTextBox);
                this.Controls.Add(textBox);
                endNameTextBox += 70;
                Label categoryLabel = addCategoryLabel(i, startCategoryLabel, endCategoryLabel);
                this.Controls.Add(categoryLabel);
                endCategoryLabel += 70;
                ComboBox combo = addCategoryComboBox(i, startCategoryCombo, endCategoryComboLabel);
                this.Controls.Add(combo);
                endCategoryComboLabel += 70;
                Label entityLabel = addEntityLabel(i, startEntityLabel, endEntityLabel);
                this.Controls.Add(entityLabel);
                endEntityLabel += 70;
                ComboBox entityCombo = addEntityComboBox(i, startEntityCombo, endEntityCombo);
                this.Controls.Add(entityCombo);
                endEntityCombo += 70;
                Label amountLabel = addAmountLabel(i, startAmountLabel, endAmountLabel);
                this.Controls.Add(amountLabel);
                endAmountLabel += 70;
                TextBox amountText = addAmountTextBox(i, startAmountText, endAmountText);
                this.Controls.Add(amountText);
                endAmountText += 70;
                Label timestampLabel = addTimeLabel(i, starTimeLabel, endTimeLabel);
                this.Controls.Add(timestampLabel);
                endTimeLabel += 70;
                DateTimePicker dateTimePicker = addDateTimePicker(i, starPicker, endPicker);
                this.Controls.Add(dateTimePicker);
                endPicker += 70;

            }

        }

        Label addNameLabel(int i, int start, int end)
        {
            Label label = new Label();
            label.Name = "TransactionName";
            label.Text = "Transaction Name";
            label.Location = new Point(start, end);

            return label;
        }

        Label addCategoryLabel(int i, int start, int end)
        {
            Label label = new Label();
            label.Name = "CategoryName";
            label.Text = "Category";
            label.Location = new Point(start, end);

            return label;
        }

        Label addEntityLabel(int i, int start, int end)
        {
            Label label = new Label();
            label.Name = "Entity";
            label.Text = "Entity";
            label.Location = new Point(start, end);

            return label;
        }

        Label addAmountLabel(int i, int start, int end)
        {
            Label label = new Label();
            label.Name = "Amount";
            label.Text = "Amount";
            label.Location = new Point(start, end);

            return label;
        }
        
        Label addTimeLabel(int i, int start, int end)
        {
            Label label = new Label();
            label.Name = "Timestamp";
            label.Text = "Timestamp";
            label.Location = new Point(start, end);

            return label;
        }


        TextBox addNameTextBox(int i, int start, int end)
        {
            TextBox textBox = new TextBox();
            textBox.Name = "textBox" + i.ToString();
            textBox.Location = new Point(start, end);


            return textBox;
        }
        
        TextBox addAmountTextBox(int i, int start, int end)
        {
            TextBox textBox = new TextBox();
            textBox.Name = "amountTextBox" + i.ToString();
            textBox.Location = new Point(start, end);
            return textBox;
        }

        ComboBox addCategoryComboBox(int i, int start, int end)
        {
            ComboBox categoryComboBox = new ComboBox();
            categoryComboBox.Name = "categoryComboBox" + i.ToString();
            categoryComboBox.Location = new Point(start, end);
            MySqlDataReader reader = categoryController.getAllCategories();
            while (reader.Read())
            {
                categoryComboBox.Items.Add(new KeyValuePair<string, int>(reader["categoryName"].ToString(), reader.GetInt32("categoryId")));

                categoryComboBox.DisplayMember = "key";
                categoryComboBox.ValueMember = "value";

            }
            reader.Close();

            return categoryComboBox;
        }

        ComboBox addEntityComboBox(int i, int start, int end)
        {
            ComboBox entityComboBox = new ComboBox();
            entityComboBox.Name = "entityComboBox" + i.ToString();
            entityComboBox.Location = new Point(start, end);
            MySqlDataReader entityReader = entityController.getAllEntities();

            while (entityReader.Read())
            {

                entityComboBox.Items.Add(new KeyValuePair<string, int>(entityReader["entityName"].ToString(), entityReader.GetInt32("entityId")));
                entityComboBox.DisplayMember = "key";
                entityComboBox.ValueMember = "value";

            }
            entityReader.Close();
            return entityComboBox;
        }
        
        DateTimePicker addDateTimePicker(int i, int start, int end)
        {
            DateTimePicker picker = new DateTimePicker();
            picker.Name = "picker" + i.ToString();
            picker.Location = new Point(start, end);
            
            return picker;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (transactionCount<1)
            {
                MessageBox.Show("Please Add Transactions");
                return;
            }
            for (int i = 0; i < transactionCount; i++)
            {
                string NametextBox = "textBox" + i.ToString();
                Control ctl = this.Controls.Find(NametextBox, true).FirstOrDefault();
                TextBox tb = (TextBox)ctl;
                if (string.IsNullOrEmpty(tb.Text))
                {
                    MessageBox.Show("You are missing field <Transaction Name> for a particular Transaction");
                    return;
                }               
                string transactionName = tb.Text;               
                string categoryBox = "categoryComboBox" + i.ToString();
                string entityBox = "entityComboBox" + i.ToString();
                string amountTextBox = "amountTextBox" + i.ToString();
                string picker = "picker" + i.ToString();
                Control categoryControl  = this.Controls.Find(categoryBox, true).FirstOrDefault();
                ComboBox categoryCombo = (ComboBox)categoryControl;
                if (categoryCombo.SelectedIndex == -1)
                {
                    MessageBox.Show("You are missing field <Category> for a particular Transaction");
                    return;
                }
                KeyValuePair<string, int> CategoryKeyValue = (KeyValuePair<string, int>)categoryCombo.SelectedItem;
                int category = CategoryKeyValue.Value;
                Control entityControl = this.Controls.Find(entityBox, true).FirstOrDefault();
                ComboBox entityCombo = (ComboBox)entityControl;
                if (entityCombo.SelectedIndex == -1)
                {
                    MessageBox.Show("You are missing field <Entity> for a particular Transaction");
                    return;
                }
                KeyValuePair<string, int> EntityKeyValue = (KeyValuePair<string, int>)entityCombo.SelectedItem;
                int entity = EntityKeyValue.Value;
                Control amountControl = this.Controls.Find(amountTextBox, true).FirstOrDefault();
                TextBox amountText = (TextBox)amountControl;
                if (string.IsNullOrEmpty(amountText.Text))
                {
                    MessageBox.Show("You are missing field <Amount> for a particular Transaction");
                    return;
                }
                if (!amountText.Text.All(char.IsDigit))
                {
                    MessageBox.Show("You have provided Non-Numeric value for field <Amount> for a particular Transaction");
                    return;
                }
                double amount = double.Parse(amountText.Text);
                Control timeControl = this.Controls.Find(picker, true).FirstOrDefault();
                DateTimePicker timePicker = (DateTimePicker)timeControl;
                DateTime transactionDate = timePicker.Value;
                string note = "Bulk Transaction Add";

                TransactionAddDto transactionAdd = new TransactionAddDto();
                transactionAdd.transactionName = transactionName;
                transactionAdd.transactionNote = note;
                transactionAdd.transactionAmount = amount;
                transactionAdd.transactionDate = transactionDate;
                transactionAdd.categoryId = category;
                transactionAdd.entityId = entity;

                object response = transactionController.addTransaction(transactionAdd);



            }
            MessageBox.Show("Bulk Transactions Added Successfully");
            this.refreshTransactionList();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
