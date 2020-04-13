using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Manager.Response
{
    public class SuccessResponse
    {

        public string message { get; set; }
        public int code { get; set; }

        public SuccessResponse()
        {
            code = 200;
            message = "Operation Successfull";
        }
    }
}
