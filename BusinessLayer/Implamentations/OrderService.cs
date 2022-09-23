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
    public class OrderService : Service<OrderDTO, Order, int>, IOrderService
    {
        public OrderService(IMapper mapper, IOrderRepo repo, string includeEntities = null) : base(mapper, repo, "Customer,OrderDetailList")
        {
        }
    }
}
