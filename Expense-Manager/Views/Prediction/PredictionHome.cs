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

namespace Expense_Manager.Views.Prediction
{
    public partial class PredictionHome : Form
    {
        public ReportController reportController;
        public IReportService reportService = new ReportServiceImpl();
        private double totalAmount = 0.00;
        private int days = 1;
        public PredictionHome()
        {
            InitializeComponent();
            reportController = new ReportController(reportService);
            MySqlDataReader minDateReader = reportController.getMinDate();
            DateTime maxDate = DateTime.Now;
            DateTime minDate = DateTime.Now;

            while (minDateReader.Read())
            {
                minDate = minDateReader.GetDateTime("MIN");
            }
            minDateReader.Close();
            MySqlDataReader maxDateReader = reportController.getMaxDate();
            while (maxDateReader.Read())
            {
                maxDate = maxDateReader.GetDateTime("MAX");
            }
            maxDateReader.Close();
            totalAmount = reportController.getTotalTransactionAmount();
            days = (maxDate - minDate).Days;

            textBox1.Text = (totalAmount / days).ToString();
            textBox1.ReadOnly = true;
            textBox2.Text = (totalAmount / (days / 7)).ToString();
            textBox2.ReadOnly = true;
            textBox3.Text = (totalAmount / (days / 30)).ToString();
            textBox3.ReadOnly = true;

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void PredictionHome_Load(object sender, EventArgs e)
        {

        }
    }
}
