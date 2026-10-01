
using FirstCrudOperation.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstCrudOperation
{
    public class ApplicationdbContext:DbContext
    {
        public ApplicationdbContext(DbContextOptions<ApplicationdbContext> options) 
            : base(options) { }


        public DbSet<User> Userabc { get; set; }
        public DbSet<Product>Products { get; set; }
    }
}
