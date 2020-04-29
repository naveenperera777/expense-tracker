using Expense_Manager.Controller;
using Expense_Manager.DTO;
using Expense_Manager.Services.CategoryService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Expense_Manager.Views
{
    public partial class CategoryAdd : Form
    {
        public CategoryController categoryController;
        public ICategoryService categoryService = new CategoryServiceImpl();
        CategoryBase _categoryBase;

        public CategoryAdd(CategoryBase categoryBase)
        {
            InitializeComponent();
            this._categoryBase = categoryBase;
            this.categoryController = new CategoryController(categoryService);

          
        }

        private void refreshTransactionList()
        {
            _categoryBase.PerformRefresh();
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
            if (string.IsNullOrEmpty(categoryLimit.Text))
            {
                MessageBox.Show("Please Enter Amount");
                return;
            }
            if (!categoryLimit.Text.All(char.IsDigit))
            {
                MessageBox.Show("Please Enter Numeric Amount");
                return;
            }
            if (this.comboBox1.SelectedIndex == -1) {
                MessageBox.Show("Please Select a Category");
                return;
            }
            string categoryName = categoryBox.Text;
            double limit = double.Parse(categoryLimit.Text);
            KeyValuePair<string, int> keyValue = (KeyValuePair<string, int>)comboBox1.SelectedItem;

            string key = keyValue.Key;
            int value = keyValue.Value;

            if (string.IsNullOrEmpty(categoryName))
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
            this.refreshTransactionList();

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

        private void button2_Click(object sender, EventArgs e)
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
         

            XmlSerializer serializer = new XmlSerializer(typeof(CategoryAddDto));

            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\category.xml", FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fs, categoryAdd);
                MessageBox.Show("Xml File Created", "Success");
              
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CategoryAddDto));
            CategoryAddDto categoryAddDto = new CategoryAddDto();
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\category.xml", FileMode.Open, FileAccess.Read))
            {
                categoryAddDto = serializer.Deserialize(fs) as CategoryAddDto;
                categoryBox.Text = categoryAddDto.categoryName;
                categoryLimit.Text = categoryAddDto.categoryLimit.ToString();
                comboBox1.Text = categoryAddDto.categoryType;

            }
        }
    }
}
