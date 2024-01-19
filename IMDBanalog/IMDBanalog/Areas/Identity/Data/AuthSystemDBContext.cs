using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBanalog.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IMDBanalog.Data
{
    public class AuthSystemDBContext : IdentityDbContext<ApplicationUser>
    {
        public AuthSystemDBContext(DbContextOptions<AuthSystemDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }
    }
}
