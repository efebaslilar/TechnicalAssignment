using EntityLayer.AllEnums;
using EntityLayer.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace PresentationLayer.CreateDefaultDatas
{
    public static class CreateData
    {
        public static string LoggedInUser { get; set; }

        public static IApplicationBuilder PrepareData(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var serviceProvider = scopedServices.ServiceProvider;

            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();

            CreateAllRoles(roleManager);

            return app;
        }
        public static void CreateAllRoles(RoleManager<AppRole> roleManager)
        {
            try
            {
                string[] allRoles = Enum.GetNames(typeof(AllRoles));
                foreach (string role in allRoles)
                {
                    if (!roleManager.RoleExistsAsync(role).Result)
                    {
                        //eğer o rol yoksa ekle
                        AppRole r = new AppRole()
                        {
                            Name = role,
                            CreatedDate = DateTime.Now,
                            IsDeleted = false,
                            Description = $"Sistem tarafından '{role}' rolü oluşturuldu."
                        };
                        var result = roleManager.CreateAsync(r).Result;
                    }
                }
            }
            catch (Exception)
            {


            }
        }
    }
}
