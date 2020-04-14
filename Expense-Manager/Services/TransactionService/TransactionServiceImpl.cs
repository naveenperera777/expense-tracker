using Expense_Manager.DTO;
using Expense_Manager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Expense_Manager.Response;

namespace Expense_Manager.Services.TransactionService
{
    class TransactionServiceImpl : ITransactionService
    {
        DBAccess dBAccess = new DBAccess();

        public object addTransaction(TransactionAddDto transactionAddDto)
        {
            MySqlCommand insertCommand = new MySqlCommand("insert into Transaction(transactionName, transactionAmount, transactionDate, categoryId, transactionNote) values(@transactionName, @transactionAmount, @transactionDate, @categoryId, @transactionNote)");

            insertCommand.Parameters.AddWithValue("@transactionName", transactionAddDto.transactionName);
            insertCommand.Parameters.AddWithValue("@transactionAmount", transactionAddDto.transactionAmount);
            insertCommand.Parameters.AddWithValue("@transactionDate", new DateTime());
            insertCommand.Parameters.AddWithValue("@categoryId", transactionAddDto.categoryId);
            insertCommand.Parameters.AddWithValue("@transactionNote", transactionAddDto.transactionNote);


            int row = dBAccess.executeQuery(insertCommand);

            if (row < 0)
            {
                throw new Exception();
            }
            else
            {
                SuccessResponse successResponse = new SuccessResponse();
                return successResponse;
            }
            throw new NotImplementedException();
        }

        public object deleteTransaction()
        {
            throw new NotImplementedException();
        }

        public object updateTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
