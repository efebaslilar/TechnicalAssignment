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
    public class BrandOwnerService : Service<BrandOwnerDTO, BrandOwner, int>, IBrandOwnerService
    {
        public BrandOwnerService(IMapper mapper, IBrandOwnerRepo repo, string includeEntities = null) : base(mapper, repo, "Brand,AppUser")
        {
        }
    }
}
