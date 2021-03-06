﻿using Expense_Manager.Controller;
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
            MySqlDataReader reader =  reportController.getExpenses("default", "defualt");
           
                while (reader.Read())
                {
                    textBox1.Text = reader.GetInt32("SUM").ToString();
                }
                reader.Close();         

            MySqlDataReader incomeReader = reportController.getIncome("default", "defualt");
            while (incomeReader.Read()){
                textBox2.Text = incomeReader.GetInt32("SUM").ToString();
            }
            incomeReader.Close();          

            MySqlDataReader categoryTransactions = reportController.getTransactionsByCategory("default", "default");
            while (categoryTransactions.Read())
            {
                chartTransaction.Series["Category"].Points.AddXY(categoryTransactions.GetString("categoryName"), categoryTransactions.GetInt32("transactionSum"));
            }
            categoryTransactions.Close();
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

        private void filterBtn_Click(object sender, EventArgs e)
        {
            string from = fromDateTimePicker.Value.ToString("yyyy-MM-dd");
            string to = toDateTimePicker.Value.ToString("yyyy-MM-dd");
            MySqlDataReader reader = reportController.getExpenses(from, to);


            while (reader.Read())
            {
                    textBox1.Text = reader.GetInt32("SUM").ToString();
            }
            reader.Close();
            MySqlDataReader readerIncome = reportController.getIncome(from, to);

            while (readerIncome.Read())
            {
                textBox2.Text = readerIncome.GetInt32("SUM").ToString();
            }
            readerIncome.Close();

            MySqlDataReader categoryTransactions = reportController.getTransactionsByCategory(from, to);
            chartTransaction.Series["Category"].Points.Clear();
            while (categoryTransactions.Read())
            {
                chartTransaction.Series["Category"].Points.AddXY(categoryTransactions.GetString("categoryName"), categoryTransactions.GetInt32("transactionSum"));
            }
            categoryTransactions.Close();


        }

        private void chart1_Click(object sender, EventArgs e)
        {
           

        }
    }
}
