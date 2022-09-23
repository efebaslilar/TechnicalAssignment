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
    }
}
