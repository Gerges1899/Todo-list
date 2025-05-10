using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp
{
    public class ResponseAPI
    {
        public bool succeed { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public string code { get; set; }

        public ResponseAPI(bool _succeed, string _message, object _data, string _messageCode)
        {
            succeed = _succeed;
            message = _message;
            data = _data;
            code = _messageCode;
        }
    }
}
