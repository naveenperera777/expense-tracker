using Expense_Manager.Controller;
using Expense_Manager.DTO;
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
        public UpdateCategory(CategoryEditDto categoryEditDto)
        {
            InitializeComponent();
            categoryController = new CategoryController(categoryService);
            categoryName.Text = categoryEditDto.categoryName;
            categoryLimit.Text = categoryEditDto.categoryLimit.ToString();
            MySqlDataReader reader = categoryController.getAllCategories();
            while (reader.Read())
            {
                comboBox1.Items.Add(new KeyValuePair<string, int>(reader["categoryName"].ToString(), reader.GetInt32("categoryId")));

                comboBox1.DisplayMember = "key";
                comboBox1.ValueMember = "value";

            }
            reader.Close();
            comboBox1.Text = categoryEditDto.categoryName;
        }

        private void UpdateCategory_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
