using Expense_Manager.Controller;
using Expense_Manager.Services.ReportService;
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

namespace Expense_Manager.Views.Report
{
    public partial class ReportHome : Form
    {
        public ReportController reportController;
        public IReportService reportService = new ReportServiceImpl();
        public ReportHome()
        {
            InitializeComponent();
            reportController = new ReportController(reportService);
            MySqlDataReader reader =  reportController.getExpenses();
            while (reader.Read()) {             
                textBox1.Text = reader.GetInt32("SUM").ToString();
            }
            reader.Close();

            MySqlDataReader incomeReader = reportController.getIncome();
            while (incomeReader.Read())            {

                textBox2.Text = incomeReader.GetInt32("SUM").ToString();
            }
            incomeReader.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
