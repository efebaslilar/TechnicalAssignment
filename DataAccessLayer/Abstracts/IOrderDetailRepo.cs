using EntityLayer.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstracts
{
    public interface IOrderDetailRepo:IRepository<OrderDetail,int>
    {
    }
}
