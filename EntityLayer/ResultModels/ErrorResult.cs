using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ResultModels
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(false)
        {

        }
        public ErrorResult(string msg) : base(false, msg)
        {

        }
    }
}
