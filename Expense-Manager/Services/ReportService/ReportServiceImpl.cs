using Expense_Manager.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expense_Manager.Services.ReportService
{

    public class ReportServiceImpl : IReportService
    {
        DBAccess dBAccess = new DBAccess();

        public MySqlDataReader getExpensesSummary(string from, string to)
        {
            string query;
            if (!from.Equals("default"))
            {
                query = "SELECT SUM(transactionAmount) as SUM FROM transaction AS t INNER JOIN category AS c ON t.categoryId=c.categoryId WHERE c.categoryType=@expense AND t.transactionDate BETWEEN @from AND @to";
                MySqlCommand getExpenses = new MySqlCommand(query);
                getExpenses.Parameters.AddWithValue("@expense", "expense");
                getExpenses.Parameters.AddWithValue("@from", from);
                getExpenses.Parameters.AddWithValue("@to", to);
                MySqlDataReader reader = dBAccess.readDatathroughReaderWithParams(getExpenses);

                return reader;
            }
            else
            {
                query = "SELECT SUM(transactionAmount) as SUM FROM transaction AS t INNER JOIN category AS c ON t.categoryId=c.categoryId WHERE c.categoryType=@expense";
                MySqlCommand getExpenses = new MySqlCommand(query);
                getExpenses.Parameters.AddWithValue("@expense", "expense");
                MySqlDataReader reader = dBAccess.readDatathroughReaderWithParams(getExpenses);

                return reader;
            }

          
        }

        public MySqlDataReader getIncomeSummary(string from, string to)
        {
            string query;
            if (!from.Equals("default"))
            {
                query = "SELECT SUM(transactionAmount) as SUM FROM transaction AS t INNER JOIN category AS c ON t.categoryId=c.categoryId WHERE c.categoryType=@income AND t.transactionDate BETWEEN @from AND @to";
                MySqlCommand getIncome = new MySqlCommand(query);
                getIncome.Parameters.AddWithValue("@income", "income");
                getIncome.Parameters.AddWithValue("@from", from);
                getIncome.Parameters.AddWithValue("@to",to);
                MySqlDataReader reader = dBAccess.readDatathroughReaderWithParams(getIncome);

                return reader;
            } else
            {
                query = "SELECT SUM(transactionAmount) as SUM FROM transaction AS t INNER JOIN category AS c ON t.categoryId=c.categoryId WHERE c.categoryType=@income";
                MySqlCommand getIncome = new MySqlCommand(query);
                getIncome.Parameters.AddWithValue("@income", "income");
                MySqlDataReader reader = dBAccess.readDatathroughReaderWithParams(getIncome);

                return reader;
            }


        }

        public MySqlDataReader getMaxDate()
        {
            string sqlMax = "SELECT  MAX(transactionDate) as MAX FROM transaction";

            MySqlCommand maxDate = new MySqlCommand(sqlMax);

            MySqlDataReader reader = dBAccess.readDatathroughReaderWithParams(maxDate);

            return reader;
        }

        public MySqlDataReader getMinDate()
        {
            string sqlMin = "SELECT  MIN(transactionDate) as MIN FROM transaction";

            MySqlCommand getMinDate = new MySqlCommand(sqlMin);

            MySqlDataReader reader = dBAccess.readDatathroughReaderWithParams(getMinDate);

            return reader;
           
        }

        public double getTotalTransactionAmount()
        {
            string sql = "SELECT SUM(transactionAmount) as TOTAL FROM transaction";

            MySqlCommand totalCommand = new MySqlCommand(sql);

            MySqlDataReader reader = dBAccess.readDatathroughReaderWithParams(totalCommand);
            double amount = 0.00;
            while (reader.Read())
            {
                amount = reader.GetDouble("TOTAL");             

            }
            reader.Close();
            return amount;
        }

        public MySqlDataReader getTransactionsByCategory(string from, string to)
        {
            string sql;
            if (from.Equals("default"))
            {
                sql = "SELECT *, SUM(t.transactionAmount) as transactionSum FROM transaction AS t INNER JOIN category AS c ON t.categoryId=c.categoryId GROUP BY c.categoryId";
                MySqlCommand transactions = new MySqlCommand(sql);
                MySqlDataReader reader = dBAccess.readDatathroughReaderWithParams(transactions);

                return reader;
            } else
            {
                sql = "SELECT *, SUM(t.transactionAmount) as transactionSum FROM transaction AS t INNER JOIN category AS c ON t.categoryId=c.categoryId WHERE t.transactionDate BETWEEN @from AND @to GROUP BY c.categoryId";
                MySqlCommand transactions = new MySqlCommand(sql);
                transactions.Parameters.AddWithValue("@from", from);
                transactions.Parameters.AddWithValue("@to", to);
                MySqlDataReader reader = dBAccess.readDatathroughReaderWithParams(transactions);

                return reader;
            }

        }
    }
}
