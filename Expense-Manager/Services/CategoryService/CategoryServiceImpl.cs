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

            MySqlCommand insertCommand = new MySqlCommand("insert into Category(CategoryName, CategoryType, categoryLimit) values(@CategoryName, @CategoryType, @CategoryLimit)");

            insertCommand.Parameters.AddWithValue("@categoryName", categoryAddDto.categoryName);
            insertCommand.Parameters.AddWithValue("@categoryType", categoryAddDto.categoryType);
            insertCommand.Parameters.AddWithValue("@categoryLimit",categoryAddDto.categoryLimit);

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

        public MySqlDataReader getAllCategories()
        {
            String query = "select * from category";
            MySqlDataReader reader = dBAccess.readDatathroughReader(query);
            return reader;
        }

        public object updateCategory(CategoryEditDto categoryEditDto)
        {
            string sql = "update category set categoryName=@categoryName, categoryType=@categoryType, categoryLimit=@categoryLimit  where categoryId=@categoryId";
            MySqlCommand updateCategory = new MySqlCommand(sql);
            updateCategory.Parameters.AddWithValue("@categoryName", categoryEditDto.categoryName);
            updateCategory.Parameters.AddWithValue("@categoryType", categoryEditDto.categoryType);
            updateCategory.Parameters.AddWithValue("@categoryLimit", categoryEditDto.categoryLimit);
            updateCategory.Parameters.AddWithValue("@categoryId", categoryEditDto.categoryId);


            int row = dBAccess.executeQuery(updateCategory);
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
