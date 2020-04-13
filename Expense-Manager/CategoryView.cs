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
        public CategoryView()
        {
            InitializeComponent();
            string sql = "select * from Category";
            DataTable dataTable = new DataTable();
            dBAccess.readDatathroughAdapter(sql, dataTable);
            dataGridView1.DataSource = dataTable;
            dBAccess.closeConn();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
