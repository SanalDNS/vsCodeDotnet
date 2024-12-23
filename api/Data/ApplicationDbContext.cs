using Microsoft.EntityFrameworkCore;
using api.Model;

namespace api.Data{
    public class ApplicationDbContext : DbContext{
        public ApplicationDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }

        public DbSet<Admin> Admins {get; set;}
        public DbSet<Category>Categories{get;set;}

        public DbSet<Menuitem>Menuitems{get;set;} // this is being used in controllers
    }
}