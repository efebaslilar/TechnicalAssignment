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
    public class BrandOwnerRepo : Repository<BrandOwner, int>, IBrandOwnerRepo
    {
        public BrandOwnerRepo(MyContext myContext) : base(myContext)
        {
        }
    }
}
