using DemoMarketPlace.WebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoMarketPlace.WebApi.Context
{
    public class BaseContext:DbContext
    {
        public BaseContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasOne(x => x.TopAddress).WithMany(x=> x.Addresses).OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder); 
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }

}
