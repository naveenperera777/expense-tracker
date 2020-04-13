using Expense_Manager.Model.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Manager.Services.CategoryService
{
    class CategoryServiceImpl : ICategoryService, ICategoryRepository
    {
        public ICategoryRepository _categoryRepository;

        public CategoryServiceImpl(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void addCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void updateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
