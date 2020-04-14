using Expense_Manager.Controller;
using Expense_Manager.DTO;
using Expense_Manager.Services.CategoryService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expense_Manager.Views
{
    public partial class CategoryAdd : Form
    {
        public CategoryController categoryController;
        public ICategoryService categoryService = new CategoryServiceImpl();

        public CategoryAdd()
        {
            this.categoryController = new CategoryController(categoryService);
            InitializeComponent();

          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {  

        }

        private void CategoryAdd_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add(new KeyValuePair<string, int>("Income", 0));
            comboBox1.Items.Add(new KeyValuePair<string, int>("Expense", 1));

            comboBox1.DisplayMember = "key";
            comboBox1.ValueMember = "value";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string categoryName = categoryBox.Text;
            double limit = double.Parse(categoryLimit.Text);
            KeyValuePair<string, int> keyValue = (KeyValuePair<string, int>)comboBox1.SelectedItem;

            string key = keyValue.Key;
            int value = keyValue.Value;

            if (categoryName.Equals(""))
            {
                MessageBox.Show("Please Enter Category Name");
            }

            CategoryAddDto categoryAdd = new CategoryAddDto();
            categoryAdd.categoryName = categoryName;
            categoryAdd.categoryType = key;
            categoryAdd.categoryLimit = limit;
           
            Object response = categoryController.addCategory(categoryAdd);

            if (response is Exception)
            {
                MessageBox.Show("Error Adding Category");
            } else
            {
                MessageBox.Show("Category Added Successfully");
            }

        }

        private void categoryBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


        }
    }
}
