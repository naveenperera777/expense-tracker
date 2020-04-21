using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Manager.Services.ReportService
{
    public interface IReportService
    {
        MySqlDataReader getExpensesSummary();
        MySqlDataReader getIncomeSummary();
    }
}
