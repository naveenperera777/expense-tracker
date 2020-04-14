using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Manager.DTO
{
    class CategoryRetrieveDto
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string categoryType { get; set; }
        public double categoryLimit { get; set; }
    }
}
