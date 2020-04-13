using Expense_Manager.Model.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Manager.Services.CategoryService
{
    interface ICategoryRepository
    {
        void addCategory(Category category);
        void updateCategory(Category category);
    }
}
