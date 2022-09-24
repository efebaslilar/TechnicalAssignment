using BusinessLayer.Abstracts;
using EntityLayer.IdentityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;
using System.Data;
using System.Security.Claims;

namespace PresentationLayer.Controllers
{
    [Area("Management")]
    [Route("b/[Controller]/[Action]/{id?}")]
    [Authorize(Roles = "Admin,SysAdmin")]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly UserManager<AppUser> _userManager;

        public AdminController(IProductService productService, UserManager<AppUser> userManager)
        {
            _productService = productService;
            _userManager = userManager;
        }

        [Authorize(Roles = "SysAdmin")]
        public IActionResult SysIndex(int? page = 1, string search = "")
        {

            var products = _productService.GetAll(x => !x.IsDeleted).Data;
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(x => x.ProductName.ToLower().Contains(search.ToLower())).ToList();
            }

            ViewBag.TotalProducts = products.Count; // toplam kitap sayısı

            return View(products);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult AdminIndex(int? page = 1, string search = "")
        {

            var roles = ((ClaimsIdentity)User.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);
            if (roles.ToString() == "SysAdmin")
            {
                var products = _productService.GetAll(x => !x.IsDeleted).Data;
                if (!string.IsNullOrEmpty(search))
                {
                    products = products.Where(x => x.ProductName.ToLower().Contains(search.ToLower())).ToList();
                }
                return View(products);

            }
            return View();
        }

        

    }
}
