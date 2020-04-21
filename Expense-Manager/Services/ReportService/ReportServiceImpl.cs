using Expense_Manager.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Manager.Services.ReportService
{

    public class ReportServiceImpl : IReportService
    {
        DBAccess dBAccess = new DBAccess();

        public MySqlDataReader getExpensesSummary()
        {
            String query = "SELECT SUM(transactionAmount) as SUM FROM transaction AS t INNER JOIN category AS c ON t.categoryId=c.categoryId WHERE c.categoryType=@expense AND t.transactionDate BETWEEN @from AND @to";
            MySqlCommand getExpenses = new MySqlCommand(query);
            getExpenses.Parameters.AddWithValue("@expense", "expense");
            getExpenses.Parameters.AddWithValue("@from", "2020-04-20");
            getExpenses.Parameters.AddWithValue("@to", "2020-04-22");
            MySqlDataReader reader = dBAccess.readDatathroughReaderWithParams(getExpenses);
            
            return reader;

          
        }

        public MySqlDataReader getIncomeSummary()
        {
            String query = "SELECT SUM(transactionAmount) as SUM FROM transaction AS t INNER JOIN category AS c ON t.categoryId=c.categoryId WHERE c.categoryType=@income AND t.transactionDate BETWEEN @from AND @to";
            MySqlCommand getExpenses = new MySqlCommand(query);
            getExpenses.Parameters.AddWithValue("@income", "income");
            getExpenses.Parameters.AddWithValue("@from", "2020-04-20");
            getExpenses.Parameters.AddWithValue("@to", "2020-04-22");
            MySqlDataReader reader = dBAccess.readDatathroughReaderWithParams(getExpenses);

            return reader;


        }
    }
}
