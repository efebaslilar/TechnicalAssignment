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
    public class ProductFeatureInformationService : Service<ProductFeatureInformationDTO, ProductFeatureInformation, int>,IProductFeatureInformationService
    {
        public ProductFeatureInformationService(IMapper mapper, IProductFeatureInformationRepo repo) : base(mapper, repo, "ProductFeature")
        {
        }
    }
}
