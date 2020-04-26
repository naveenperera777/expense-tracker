using Expense_Manager.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Manager.Services.CategoryService
{
    public interface ICategoryService
    {
        object addCategory(CategoryAddDto categoryAddDto);
        MySqlDataReader getAllCategories();
        object getAllCategoriesAsTable(DataTable dataTable);
        object updateCategory(CategoryEditDto categoryEditDto);
        object deleteCategory(int categoryId);
    }
}
