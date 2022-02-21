using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using src.Entities;

namespace src.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public AppDbContext(){}

        public DbSet<EntityPerson> Entities {get; set;}
    }
}