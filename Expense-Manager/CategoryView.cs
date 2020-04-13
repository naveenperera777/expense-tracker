using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Expense_Manager.Repository;
using MySql.Data.MySqlClient;

namespace Expense_Manager
{
    public partial class CategoryView : Form
    {
        DBAccess dBAccess = new DBAccess();
        DataTable dataTable = new DataTable();

        public CategoryView()
        {
            InitializeComponent();
            string sql = "select * from Category";
            dBAccess.readDatathroughAdapter(sql, dataTable);
            dataGridView1.DataSource = dataTable;
            dBAccess.closeConn();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select * from Category";
            int changes = dBAccess.executeDataAdapter(dataTable, query);

            MessageBox.Show("Count = " + changes);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("First");

          
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string str = row.Cells["categoryId"].Value.ToString();
                int categoryId = int.Parse(str);
                MessageBox.Show("HIIII");
                MessageBox.Show(str);

                string sql = "delete from Category where categoryId=@categoryId";
                MySqlCommand sqlCommand = new MySqlCommand(sql);
                sqlCommand.Parameters.AddWithValue("@categoryId", categoryId);
                dBAccess.executeQuery(sqlCommand);



            
        }
    }
}
