using EntityLayer.EntityModels;
using EntityLayer.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ContextInfo
{
    public class MyContext : IdentityDbContext<AppUser, AppRole, string>
    {
        // Program.cs içinde bu options'ı ayarlayacağız.
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
       public DbSet<Brand> Brands { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductFeatureInformation> ProductFeatureInformations { get; set; }
    }
}
