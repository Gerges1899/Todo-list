using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp
{
    public class ValidationResult
    {
        public bool IsSucceed { get; set; }
        public string ErrorCode { get; set; }
        public string Parameter { get; set; }
        public string ParameterValues { get; set; }

        public ValidationResult(bool isSucceed, string errorCode = "", string parameter = "", string parameterValues = "")
        {
            IsSucceed = isSucceed;
            ErrorCode = errorCode;
            Parameter = parameter;
            ParameterValues = parameterValues;
        }
    }
}
