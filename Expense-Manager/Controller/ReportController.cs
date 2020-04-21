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

        public MySqlDataReader getExpenses()
        {
            return reportService.getExpensesSummary();
        }

        public MySqlDataReader getIncome()
        {
            return reportService.getIncomeSummary();
        }
    }
}
