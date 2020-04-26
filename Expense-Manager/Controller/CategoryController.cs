using Expense_Manager.DTO;
using Expense_Manager.Services.CategoryService;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Manager.Controller
{
    public class CategoryController
    {
        private ICategoryService categoryService;

        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        public CategoryController()
        {
        }

        public object addCategory(CategoryAddDto categoryAddDto) {
            object response = categoryService.addCategory(categoryAddDto);
            return response;
        }

        public MySqlDataReader getAllCategories()
        {
            MySqlDataReader response = categoryService.getAllCategories();
            return response;
        }

        public object updateCategory(CategoryEditDto categoryEditDto)
        {
            object response = categoryService.updateCategory(categoryEditDto);
            return response;
        }
    }
}
