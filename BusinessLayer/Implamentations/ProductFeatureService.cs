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
    public class ProductFeatureService : Service<ProductFeatureDTO, ProductFeature, int>, IProductFeatureService
    {
        public ProductFeatureService(IMapper mapper, IProductFeatureRepo repo, string includeEntities = null) : base(mapper, repo, "Product")
        {
        }
    }
}
