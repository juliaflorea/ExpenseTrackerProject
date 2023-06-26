using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ExpenseTrackerProject.Models
{
    public class ExpenseTrackerDbContext : IdentityDbContext<ApplicationUser>
        /*: IdentityDbContext<ApplicationUser, IdentityRole<int>, int>*/
    {
        public ExpenseTrackerDbContext(DbContextOptions<ExpenseTrackerDbContext> options) : base(options) 
        { 
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Budget> Budgets { get; set; }protected override void OnModelCreating(ModelBuilder builder)
{
    base.OnModelCreating(builder);

    builder.Entity<ApplicationUser>(entity =>
    {
        entity.Property(e => e.Id)
            .ValueGeneratedOnAdd();
    });
}


        //public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

        //public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<AspNetRole>(entity =>
        //    {
        //        entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
        //            .IsUnique()
        //            .HasFilter("([NormalizedName] IS NOT NULL)");

        //        entity.Property(e => e.Name).HasMaxLength(256);
        //        entity.Property(e => e.NormalizedName).HasMaxLength(256);
        //    });

        //    modelBuilder.Entity<AspNetUser>(entity =>
        //    {
        //        entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

        //        entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
        //            .IsUnique()
        //            .HasFilter("([NormalizedUserName] IS NOT NULL)");

        //        entity.Property(e => e.Email).HasMaxLength(256);
        //        entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
        //        entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
        //        entity.Property(e => e.UserName).HasMaxLength(256);
        //    });

            
        //}
    }
}
