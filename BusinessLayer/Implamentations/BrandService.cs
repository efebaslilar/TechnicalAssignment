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
    public class BrandService : Service<BrandDTO, Brand, int>, IBrandService
    {
        public BrandService(IMapper mapper, IBrandRepo repo, string includeEntities = null) : base(mapper, repo, "Brands")
        {
        }
    }
}
