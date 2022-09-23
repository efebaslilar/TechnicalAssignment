using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ResultModels
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data) : base(true, data)
        {

        }
        public SuccessDataResult(T data, string msg) : base(true, msg, data)
        {

        }
    }
}
