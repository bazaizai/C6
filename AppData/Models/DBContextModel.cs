using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AppData.Models
{
    public class DBContextModel : DbContext
    {
        public DBContextModel() { }
        public DBContextModel(DbContextOptions options) : base(options) { }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<ComboDetail> comboDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=C6;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.
                ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
