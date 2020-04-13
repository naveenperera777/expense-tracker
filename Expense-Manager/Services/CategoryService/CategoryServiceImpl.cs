using Expense_Manager.Model.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Expense_Manager.Repository;
using Expense_Manager.DTO;
using Expense_Manager.Response;

namespace Expense_Manager.Services.CategoryService
{
    class CategoryServiceImpl : ICategoryService
    {

        DBAccess dBAccess = new DBAccess();

        public object addCategory(CategoryAddDto categoryAddDto)
        {

            MySqlCommand insertCommand = new MySqlCommand("insert into Category(CategoryName) values(@CategoryName)");

            insertCommand.Parameters.AddWithValue("@categoryName", categoryAddDto.categoryName);

            int row = dBAccess.executeQuery(insertCommand);

            if (row < 0)
            {
                throw new Exception();
            } else
            {
                SuccessResponse successResponse = new SuccessResponse();
                return successResponse;
            }
          
        }
    }
}
