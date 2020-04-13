using Expense_Manager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Manager.Services.CategoryService
{
    public interface ICategoryService
    {
        object addCategory(CategoryAddDto categoryAddDto);
    }
}
