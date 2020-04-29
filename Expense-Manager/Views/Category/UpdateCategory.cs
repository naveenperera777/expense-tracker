using Expense_Manager.Controller;
using Expense_Manager.DTO;
using Expense_Manager.Response;
using Expense_Manager.Services.CategoryService;
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

namespace Expense_Manager.Views.Category
{
    public partial class UpdateCategory : Form
    {
        public CategoryController categoryController;
        public ICategoryService categoryService = new CategoryServiceImpl();
        private int categoryId;
        CategoryBase _categoryBase;
        public UpdateCategory(CategoryEditDto categoryEditDto, CategoryBase categoryBase)
        {
            InitializeComponent();
            this._categoryBase = categoryBase;
            categoryController = new CategoryController(categoryService);
            categoryName.Text = categoryEditDto.categoryName;
            categoryLimit.Text = categoryEditDto.categoryLimit.ToString();
            categoryId = categoryEditDto.categoryId;
           
            comboBox1.Items.Add(new KeyValuePair<string, int>("Income", 0));
            comboBox1.Items.Add(new KeyValuePair<string, int>("Expense", 1));

            comboBox1.DisplayMember = "key";
            comboBox1.ValueMember = "value";
            comboBox1.Text = categoryEditDto.categoryType;
        }

        private void refreshTransactionList()
        {
            _categoryBase.PerformRefresh();
        }

        private void UpdateCategory_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(categoryName.Text))
            {
                MessageBox.Show("Please Enter Category Name");
                return;
            }
            if (string.IsNullOrEmpty(categoryLimit.Text))
            {
                MessageBox.Show("Please Enter Category Amount");
                return;
            }
            if (!categoryLimit.Text.All(char.IsDigit))
            {
                MessageBox.Show("Please Enter Numeric Amount");
                return;
            }
            if (this.comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select a Category Type");
                return;
            }
            CategoryEditDto categoryEditDto = new CategoryEditDto();
            categoryEditDto.categoryId = this.categoryId;
            categoryEditDto.categoryName = categoryName.Text;
            KeyValuePair<string, int> keyValue = (KeyValuePair<string, int>)comboBox1.SelectedItem;
            categoryEditDto.categoryType = keyValue.Key;
            categoryEditDto.categoryLimit = double.Parse(categoryLimit.Text);
            object response = categoryController.updateCategory(categoryEditDto);

            if (response is Exception)
            {
                MessageBox.Show("Error Updating Transaction");
            }
            else
            {
                MessageBox.Show("Transaction Updated Successfully");
            }
            this.refreshTransactionList();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            object response = categoryController.deleteCategory(categoryId);

            if (response is Exception)
            {
                MessageBox.Show("Error Deleting Category");
            }
            else
            {
                MessageBox.Show("Transaction Deleted Successfully");
            }
            this.refreshTransactionList();
            this.Hide();
        }
    }
}
