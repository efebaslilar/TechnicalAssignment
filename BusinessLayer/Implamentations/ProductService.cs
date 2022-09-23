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
    public class ProductService : Service<ProductDTO, Product, int>, IProductService
    {
        public ProductService(IMapper mapper, IProductRepo repo) : base(mapper, repo,"Brand")
        {
        }
    }
}
