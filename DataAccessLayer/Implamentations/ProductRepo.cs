using DataAccessLayer.Abstracts;
using DataAccessLayer.ContextInfo;
using EntityLayer.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implamentations
{
    public class ProductRepo : Repository<Product, int>, IProductRepo
    {
        public ProductRepo(MyContext myContext) : base(myContext)
        {
        }
    }
}
