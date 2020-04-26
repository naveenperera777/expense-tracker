using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using Expense_Manager.Repository;
using Expense_Manager.DTO;
using Expense_Manager.Controller;
using Expense_Manager.Services.CategoryService;
using Expense_Manager.Views;
using Expense_Manager.Views.Category;

namespace Expense_Manager
{
    public partial class CategoryBase : Form
    {
        public CategoryController categoryController;
        public ICategoryService categoryService = new CategoryServiceImpl();

        DataTable dataTable = new DataTable();

        DBAccess dBAccess = new DBAccess();
        public CategoryBase(CategoryController _categoryController)
        {
            InitializeComponent();
            string sql = "select * from Category";
            dBAccess.readDatathroughAdapter(sql, dataTable);
            dataGridView1.DataSource = dataTable;
            dBAccess.closeConn();
        }

        public CategoryBase()
        {
            this.categoryController = new CategoryController(categoryService);
            InitializeComponent();
            string sql = "select * from Category";
            dBAccess.readDatathroughAdapter(sql, dataTable);
            dataGridView1.DataSource = dataTable;
            dBAccess.closeConn();
        }

        public void PerformRefresh()
        {
            dataGridView1.DataSource = null;
            DataTable UpdatedTable = new DataTable();
            object newCategories = categoryController.getAllCategoriesAsTable(UpdatedTable);
            dataGridView1.DataSource = newCategories;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CategoryAdd categoryAddView = new CategoryAdd(this);
            categoryAddView.Show();

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void viewAllCategoriesBtn_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CategoryEditDto categoryEditDto = new CategoryEditDto();
            string categoryType = this.dataGridView1.CurrentRow.Cells["categoryType"].Value.ToString();
            string categoryName = this.dataGridView1.CurrentRow.Cells["categoryName"].Value.ToString();
            int categoryId = int.Parse(this.dataGridView1.CurrentRow.Cells["categoryId"].Value.ToString());
            double categoryLimit = double.Parse(this.dataGridView1.CurrentRow.Cells["categoryLimit"].Value.ToString());

            categoryEditDto.categoryId = categoryId;
            categoryEditDto.categoryName = categoryName;
            categoryEditDto.categoryType = categoryType;
            categoryEditDto.categoryLimit = categoryLimit;
            UpdateCategory updateCategory = new UpdateCategory(categoryEditDto, this);

            updateCategory.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            var gridView = new CategoryView();
            gridView.Show();


        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            string sql = "delete from Category where categoryId=11";
            MySqlCommand sqlCommand = new MySqlCommand(sql);
            dBAccess.executeQuery(sqlCommand);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
                
        }
    }
}
