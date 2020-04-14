using Expense_Manager.Controller;
using Expense_Manager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expense_Manager.View
{
    public partial class AddCategory : Form
       
    {
        public CategoryController categoryController;

        public AddCategory(CategoryController _categoryController)
        {
            InitializeComponent();
            categoryController = _categoryController;
           
        }
      

        public AddCategory()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string categoryName = categoryNameInput.Text;

            if (categoryName.Equals(""))
            {
                MessageBox.Show("Please Enter Category Name");
            }

            CategoryAddDto categoryAdd = new CategoryAddDto();
            categoryAdd.categoryName = categoryName;

            object response = categoryController.addCategory(categoryAdd);

            if (response is Exception)
            {
                MessageBox.Show("Category Added Successfully");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
