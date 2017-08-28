namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RestaurantDB : DbContext
    {
        public RestaurantDB()
            : base("name=RestaurantDB")
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Formula> Formulas { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<TypeOfEmployeeBLL> TypeOfEmployees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

           

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Divisions)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.TotalPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Divisions)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Prices)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderDetail>()
                .HasMany(e => e.ProductDetails)
                .WithRequired(e => e.OrderDetail)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Prices)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.ExportPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Formulae)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProductParentID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Formulae1)
                .WithRequired(e => e.Product1)
                .HasForeignKey(e => e.ProductID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductDetail>()
                .Property(e => e.Prices)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TypeOfEmployeeBLL>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.TypeOfEmployee)
                .WillCascadeOnDelete(false);
        }
    }
}
