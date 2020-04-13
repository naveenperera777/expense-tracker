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

namespace Expense_Manager
{
    public partial class Form1 : Form
    {
        DBAccess dBAccess = new DBAccess();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string categoryName = categoryInput.Text;
            int categoryId = 10;

            if (categoryName.Equals(""))
            {
                MessageBox.Show("Please Enter Category Name");
            }
            MySqlCommand insertCommand = new MySqlCommand("insert into Category(categoryId, CategoryName) values(@categoryId, @CategoryName)");

            insertCommand.Parameters.AddWithValue("@categoryId", categoryId);
            insertCommand.Parameters.AddWithValue("@categoryName", categoryName);

            int row = dBAccess.executeQuery(insertCommand);
            if(row == 1)
            {
                MessageBox.Show("Category Added Successfully");
              
            }
            else
            {
                MessageBox.Show("Error Occured!");
            }
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

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            var gridView = new CategoryView();
            gridView.Show();


        }
    }
}
