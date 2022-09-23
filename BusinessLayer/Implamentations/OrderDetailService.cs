using AutoMapper;
using BusinessLayer.Abstracts;
using DataAccessLayer.Abstracts;
using EntityLayer.EntityModels;
using EntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implamentations
{
    public class OrderDetailService : Service<OrderDetailDTO, OrderDetail, int>, IOrderDetailService
    {
        public OrderDetailService(IMapper mapper, IOrderDetailRepo repo, string includeEntities = null) : base(mapper, repo, "Order,Product")
        {
        }
    }
}
