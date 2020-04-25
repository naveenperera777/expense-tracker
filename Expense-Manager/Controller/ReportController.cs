using Expense_Manager.DTO;
using Expense_Manager.Services.EntityService;
using Expense_Manager.Services.ReportService;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Manager.Controller
{
    public class ReportController
    {
        public IReportService reportService;
        public ReportController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        public MySqlDataReader getExpenses(string from, string to)
        {
            return reportService.getExpensesSummary(from, to);
        }

        public MySqlDataReader getIncome(string from, string to)
        {
            return reportService.getIncomeSummary(from, to);
        }

        public MySqlDataReader getTransactionsByCategory(string from, string to)
        {
            return reportService.getTransactionsByCategory(from, to);
        }

        public MySqlDataReader getMinDate()
        {
            return reportService.getMinDate();
        }

        public MySqlDataReader getMaxDate()
        {
            return reportService.getMaxDate();
        }

        public double getTotalTransactionAmount()
        {
            return reportService.getTotalTransactionAmount();
        }
    }
}
