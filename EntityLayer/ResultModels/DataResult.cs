using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ResultModels
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; set; }
        public DataResult(bool success, T data) : base(success)
        {
            Data = data;
        }
        public DataResult(bool success, string message, T data) : base(success, message)
        {
            Data = data;
        }
    }
}
