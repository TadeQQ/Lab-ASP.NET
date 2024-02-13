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
            string USER_ID = Guid.NewGuid().ToString();
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();



            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ADMIN_ROLE_ID,
                ConcurrencyStamp = ADMIN_ROLE_ID
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
                Name = "user",
                NormalizedName = "USER",
                Id = USER_ROLE_ID,
                ConcurrencyStamp = USER_ROLE_ID
            });

            var admin = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "tadeusz@employees.pl",
                NormalizedEmail = "TADEUSZ@EMPLOYEES.PL",
                EmailConfirmed = true,
                UserName = "Tadeusz",
                NormalizedUserName = "TADEUSZ"
            };

            var user = new IdentityUser
            {
                Id = USER_ID,
                Email = "adam@employees.pl",
                NormalizedEmail = "ADAM@EMPLOYEES.PL",
                EmailConfirmed = true,
                UserName = "Adam",
                NormalizedUserName = "ADAM"
            };

            PasswordHasher<IdentityUser> passHasher = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = passHasher.HashPassword(admin, "Haslo23!");
            user.PasswordHash = passHasher.HashPassword(user, "Haselko23!");

            modelBuilder.Entity<IdentityUser>().HasData(admin);
            modelBuilder.Entity<IdentityUser>().HasData(user);


            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>()
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                });
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>()
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID
                });
            
            modelBuilder.Entity<EmployeeEntity>().HasData(
                new EmployeeEntity() { Id = 1, FirstName = "Andrzej", LastName = "Kowalski", PESEL = "12345678910", Department = "IT", Position = "Java Developer", EmploymentDate = new DateTime(2020, 1, 1) },
                new EmployeeEntity() { Id = 2, FirstName = "Adam", LastName = "Nowacki", PESEL = "12352635213", Department = "HR", Position = "Intern", EmploymentDate = new DateTime(2020, 1, 1) }
            );
        }
    }
}
