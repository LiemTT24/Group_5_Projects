using Group5_API_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Group5_API_Project.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Orders");
                e.HasKey(order => order.OrderID);
                e.Property(order => order.OrderDate).HasDefaultValueSql("getutcdate()");
            });

            modelBuilder.Entity<OrderDetail>(e =>
            {
                e.ToTable("OrderDetails");
                e.HasKey(o => new { o.OrderID, o.ProductID });
                e.HasOne(o => o.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderID).HasConstraintName("FK_Orders_OrderDetails");
                e.HasOne(o => o.Product).WithMany(x => x.OrderDetails).HasForeignKey(x => x.ProductID).HasConstraintName("FK_Products_OrderDetails");
            });
        }

        /// <summary>
        /// Fluent Api in Entity Framework
        /// UseSqlServer >> connect Sql Server with uid, pwd and database
        /// UseQueryTrackingBehavior >> override behavior or individual queries(NoTracking)
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=123456;Database=Group5_ApplicationDB;Trusted_Connection=true;Encrypt=false");
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        /// <summary>
        /// represents the collection of all entities in the context or can be queries from the database
        /// Entities set for table Account, Category, Product, Supplier, Order, RoleManager, OrderDetail
        /// </summary>
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<RoleManager> RoleManagers { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
