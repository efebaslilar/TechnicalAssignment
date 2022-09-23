using EntityLayer.AllEnums;
using EntityLayer.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signManager;

        public AccountController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signManager = signManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Register()
        {
            if (_signManager.IsSignedIn(HttpContext.User))
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var checkEmail = _userManager.FindByEmailAsync(model.Email).Result;
                if (checkEmail != null)
                {
                    throw new Exception("HATA! Bu email sisteme zaten kayıtlıdır!");
                }
                AppUser user = new AppUser()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now,
                    UserName = model.Email,
                    EmailConfirmed = true //todo email gönderme mekanizması
                    //TODO birthdate appuser classına eklenecek migra ekleyip update database yapıcaz
                };
                //aspnetusers tablosuna eklenmesi
                var result = _userManager.CreateAsync(user, model.Password).Result;

                //Bu kişiye customer rolü verelim
                var roleResult = _userManager.AddToRoleAsync(user, AllRoles.Customer.ToString()).Result;

                if (result.Succeeded && roleResult.Succeeded)
                {
                    return RedirectToAction("Login", "Account", new { email = model.Email });
                }

                ViewBag.RegisterFailedMessage = "Beklenmedik bir hata oluştu! Tekrar deneyiniz!\n";
                foreach (var item in result.Errors)
                {
                    ViewBag.RegisterFailedMessage += item.Description + "\n";
                }
                foreach (var item in roleResult.Errors)
                {
                    ViewBag.RegisterFailedMessage += item.Description + "\n";
                }
                return View(model);

            }
            catch (Exception ex)
            {
                //ex loglanacak
                ViewBag.RegisterFailedMessage = "Beklenmedik bir hata oluştu! " + ex.Message;
                return View(model);
            }
        }

        public IActionResult Login(string email)
        {
            if (_signManager.IsSignedIn(HttpContext.User))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var user = _userManager.FindByNameAsync(model.Email).Result;
                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı bulunamadı!");
                    return View(model);
                }
                if (!user.EmailConfirmed)
                {
                    ModelState.AddModelError("", "Sistemi kullanabilmeniz için emailinize gönderilen aktivasyon emailine tıklayarak aktifleştirme yapınız!");
                    return View(model);
                }
                var result = _signManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    if (_userManager.IsInRoleAsync(user, AllRoles.Customer.ToString()).Result)
                    {
                        //usermanager IsInRole metodu ile parametre olarak verilen kullanıcının parametre olarak verilen rolde olup olmadığına bakar.
                        //Betül Customer mı? Evet --> home indexe git
                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {
                        return RedirectToAction("Index", "Home", new { area = "Management" });
                    }
                }

                ModelState.AddModelError("", "Kullanıcı adı ya da parolanız hatalıdır!");
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Beklenmedik bir hata oluştu! " + ex.Message);
                return View(model);
            }
        }

        public IActionResult Logout()
        {
            _signManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
