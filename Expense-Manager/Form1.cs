﻿using System;
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

namespace Expense_Manager
{
    public partial class Form1 : Form
    {
        public CategoryController categoryController;
        public ICategoryService categoryService = new CategoryServiceImpl();

        DBAccess dBAccess = new DBAccess();
        public Form1(CategoryController _categoryController)
        {
            InitializeComponent();
            categoryController = _categoryController;

        }

        public Form1()
        {
            this.categoryController = new CategoryController(categoryService);
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CategoryAdd categoryAddView = new CategoryAdd();
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
    }
}
