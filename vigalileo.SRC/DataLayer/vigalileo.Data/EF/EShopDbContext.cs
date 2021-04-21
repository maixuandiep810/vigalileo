using vigalileo.Data.Configurations;
using vigalileo.Data.Entities;
// using eShopSolution.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace vigalileo.Data.EF
{
    public class vigalileoDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public vigalileoDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API

            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new BrandInCategoryConfiguration());


            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerDetailConfiguration());

            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());

            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionInRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTranslationConfiguration());

            modelBuilder.ApplyConfiguration(new SellerDetailConfiguration());
            modelBuilder.ApplyConfiguration(new StoreConfiguration());
            modelBuilder.ApplyConfiguration(new StoreInOrderConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("ApplicationUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("ApplicationUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("ApplicationUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("ApplicationRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("ApplicationUserTokens").HasKey(x => x.UserId);

            //Data seeding
            // modelBuilder.Seed();
            //base.OnModelCreating(modelBuilder);
        }

        // public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        // public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        // public DbSet<IdentityUserRole<Guid>> ApplicationUserRoles { get; set; }
        // // public DbSet<AppConfig> AppConfigs { get; set; }
        // // public DbSet<AppConfig> AppConfigs { get; set; }


        public DbSet<AppConfig> AppConfigs { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandInCategory> BrandInCategories { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<CustomerDetail> CustomerDetails { get; set; }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionInRole> PermissionInRoles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInCategory> ProductInCategories { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }

        public DbSet<SellerDetail> SellerDetails { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreInOrder> StoreInOrders { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}