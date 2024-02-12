using Lab3___zadanieContextConnection.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Lab3___zadanieContextConnection
{
        public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<EmployeeEntity> Employees { get; set; }

        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "employees.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={DbPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            string ADMIN_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();
            string ROLE_ID = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            var admin = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "adam@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "adam",
                NormalizedUserName = "ADMIN"
            };

            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = ph.HashPassword(admin, "1234abcd!@#$ABCD");

            modelBuilder.Entity<IdentityUser>().HasData(admin);

            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "user",
                NormalizedName = "USER",
                Id = USER_ROLE_ID,
                ConcurrencyStamp = USER_ROLE_ID
            });

            string USER_ID = Guid.NewGuid().ToString();
            var user = new IdentityUser
            {
                Id = USER_ID,
                Email = "user@example.com",
                EmailConfirmed = true,
                UserName = "user",
                NormalizedUserName = "USER"
            };

            PasswordHasher<IdentityUser> ph1 = new PasswordHasher<IdentityUser>();
            user.PasswordHash = ph1.HashPassword(user, "user123");

            modelBuilder.Entity<IdentityUser>().HasData(user);

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID
                });
            
            modelBuilder.Entity<EmployeeEntity>().HasData(
                new EmployeeEntity() { Id = 1, FirstName = "Adnrzej", LastName = "Kowalski", PESEL = "12345678910", Department = "XYS", Position = "pozycja", EmploymentDate = new DateTime(2020, 1, 1) },
                new EmployeeEntity() { Id = 2, FirstName = "LKia", LastName = "ASdasd", PESEL = "12352635213", Department = "XYS", Position = "pozycja", EmploymentDate = new DateTime(2020, 1, 1) }
            );
        }
    }
}
