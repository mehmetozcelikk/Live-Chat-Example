using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace DataAccess.Concrete.EntityFramework
{
    public class DataContext : DbContext
    {

        public DataContext( )
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; initial catalog=Database5;");
                //optionsBuilder.UseNpgsql("User ID=postgres2;Password=123456;Host=localhost;Port=5432;Database=Database5;");

            }
        }

        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<EmailConfirmed> EmailConfirmeds { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasOne(x => x.Country)
                    .WithMany(y => y.Cities)
                    .HasForeignKey(z => z.CountryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Image>(entity => 
            { 
                entity.HasOne(x => x.ApplicationUser)
                     .WithMany(y => y.Image)
                     .HasForeignKey(z => z.UserId)
                     .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.HasOne(x => x.Country)
                    .WithMany(y => y.ApplicationUsers)
                    .HasForeignKey(z => z.CountryId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.City)
                     .WithMany(y => y.ApplicationUsers)
                     .HasForeignKey(z => z.CityId)
                     .OnDelete(DeleteBehavior.Cascade);

            });
            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasOne(x => x.ApplicationUser)
                    .WithMany(y => y.Message)
                    .HasForeignKey(z => z.ApplicationUserId)
                    .OnDelete(DeleteBehavior.Restrict);

            });
        }
        }
}
