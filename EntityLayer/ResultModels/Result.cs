using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ResultModels
{
    public class Result : IResult
    {

        public Result(bool success)
        {
            IsSuccess = success;
        }

        public Result(bool success, string message) : this(success)
        {
            //IsSuccess = success;
            Message = message;
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }


    }
}
