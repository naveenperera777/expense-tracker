﻿using Expense_Manager.DTO;
using Expense_Manager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Expense_Manager.Response;
using Expense_Manager.Model.Transaction;
using System.Data;
using System.Windows.Forms;

namespace Expense_Manager.Services.TransactionService
{
    class TransactionServiceImpl : ITransactionService
    {
        DBAccess dBAccess = new DBAccess();

        public object addTransaction(TransactionAddDto transactionAddDto)
        {
            MySqlCommand insertCommand = new MySqlCommand("insert into Transaction(transactionName, transactionAmount, transactionDate, categoryId, transactionNote, entityId) values(@transactionName, @transactionAmount, @transactionDate, @categoryId, @transactionNote, @entityId)");

            insertCommand.Parameters.AddWithValue("@transactionName", transactionAddDto.transactionName);
            insertCommand.Parameters.AddWithValue("@transactionAmount", transactionAddDto.transactionAmount);
            insertCommand.Parameters.AddWithValue("@transactionDate", transactionAddDto.transactionDate);
            insertCommand.Parameters.AddWithValue("@categoryId", transactionAddDto.categoryId);
            insertCommand.Parameters.AddWithValue("@transactionNote", transactionAddDto.transactionNote);
            insertCommand.Parameters.AddWithValue("@entityId", transactionAddDto.entityId);

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
        }

        public object deleteTransaction(int transactionId)
        {
            string sql = "delete from transaction where transactionId=@transactionId";
            MySqlCommand deleteTransaction = new MySqlCommand(sql);
            deleteTransaction.Parameters.AddWithValue("@transactionId", transactionId);
            int row = dBAccess.executeQuery(deleteTransaction);

            if (row < 0)
            {
                throw new Exception();
            }
            else
            {
                SuccessResponse successResponse = new SuccessResponse();
                return successResponse;
            }

        }

        public object deleteTransactions(string transactionId)
        {

            string query = "select * from transaction";
            MySqlDataReader reader = dBAccess.readDatathroughReader(query);
            List<Transaction> categories = new List<Transaction>();
            while (reader.Read())
            {
                Transaction transaction = new Transaction();
                transaction.transactionId = reader.GetInt32("transactionId");
                transaction.transactionAmount = reader.GetDouble("transactionAmount");
                transaction.transactionName = reader["transactionName"].ToString();
                transaction.transactionNote = reader["transactionNote"].ToString();
                transaction.categoryId = reader.GetInt32("categoryId");
                transaction.transactionDate = reader.GetDateTime("transactionDate");

            }
            reader.Close();
            throw new NotImplementedException();

        }

        public object getAllTransactions(DataTable dataTable)
        {
            string sql = "select t.transactionId , t.transactionName, t.transactionAmount, t.transactionNote, t.categoryId, c.categoryName, CAST(t.transactionDate AS DATETIME) AS transactionDate FROM transaction AS t INNER JOIN category AS c ON t.categoryId = c.categoryId";
            //string sql = "select t.transactionId , t.transactionName, t.transactionAmount, t.transactionNote, t.categoryId, c.categoryName FROM transaction as t INNER JOIN category AS c ON t.categoryId = c.categoryId";
            dBAccess.readDatathroughAdapter(sql, dataTable);
            dBAccess.closeConn();

            return dataTable;
                               
        }

        public object updateTransactions(TransactionEditDto transactionEditDto)
        {
            string sql = "update transaction set transactionName=@transactionName, transactionAmount=@transactionAmount, transactionNote=@transactionNote, transactionDate=@transactionDate, categoryId=@categoryId  where transactionId=@transactionId";
            MySqlCommand updateTransaction = new MySqlCommand(sql);
            updateTransaction.Parameters.AddWithValue("@transactionName", transactionEditDto.transactionName);
            updateTransaction.Parameters.AddWithValue("@transactionAmount", transactionEditDto.transactionAmount);
            updateTransaction.Parameters.AddWithValue("@transactionNote", transactionEditDto.transactionNote);
            updateTransaction.Parameters.AddWithValue("@transactionDate", transactionEditDto.transactionDate);
            updateTransaction.Parameters.AddWithValue("@categoryId", transactionEditDto.categoryId);

            updateTransaction.Parameters.AddWithValue("@transactionId", transactionEditDto.transactionId);

            int row = dBAccess.executeQuery(updateTransaction);
            if (row < 0)
            {
                throw new Exception();
            }
            else
            {
                SuccessResponse successResponse = new SuccessResponse();
                return successResponse;
            }

        }
    }
}
