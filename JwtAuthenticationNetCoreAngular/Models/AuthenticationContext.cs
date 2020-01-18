using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthenticationNetCoreAngular.Models
{
    public class AuthenticationContext : IdentityDbContext
    {
        public AuthenticationContext(DbContextOptions dbCntextOption) :base(dbCntextOption)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
