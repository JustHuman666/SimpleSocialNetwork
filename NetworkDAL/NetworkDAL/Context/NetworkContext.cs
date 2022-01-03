using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetworkDAL.Enteties;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkDAL.Context
{
    /// <summary>
    /// Class that represents a database with all information of network
    /// </summary>
    public class NetworkContext : IdentityDbContext<User, Role, int>
    {
        /// <summary>
        /// Constructor for creating of DB context with some options
        /// </summary>
        /// <param name="options">Instance of DbContextOptions for creating DB context</param>
        public NetworkContext(DbContextOptions<NetworkContext> options) : base(options)
        {
        }

        public NetworkContext(DbContextOptions options) : base(options)
        {
        }

        public NetworkContext():base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("DefaultConnection");
        }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<MessageStatus> MessageStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var guest = new Role() { Id = 1, Name = "Guest", NormalizedName = "GUEST" };
            var admin = new Role() { Id = 2, Name = "Admin", NormalizedName = "ADMIN" };
            var registered = new Role() { Id = 3, Name = "Registered", NormalizedName = "REGISTERED" };

            builder.Entity<Role>().HasData(guest, admin, registered);

            var adminData = new User()
            {
                Id = 0,
                Email = "e.myhalchuk@gmail.com",
                NormalizedEmail = "E.MYHALCHUK@GMAIL.COM",
                UserName = "AdminElya",
                NormalizedUserName = "ADMINELYA",
            };
            var adminProfile = new UserProfile()
            {
                Id = adminData.Id,
                FirstName = "Eleonora",
                LastName = "Mykhalchuk",
                Country = "Ukraine"
            };

            var passwordHasher = new PasswordHasher<User>();
            adminData.PasswordHash = passwordHasher.HashPassword(adminData, "MyPassword");

            var messageStatuses = new[]
            {
                new MessageStatus(){ Id = 1, StatusName = "Sent"},
                new MessageStatus(){ Id = 2, StatusName = "Seen"},
                new MessageStatus(){ Id = 3, StatusName = "OnWay"},
                new MessageStatus(){ Id = 4, StatusName = "Error"},
            };

            builder.Entity<MessageStatus>().HasData(messageStatuses);
            builder.Entity<User>().HasData(adminData);
            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<int> { RoleId = admin.Id, UserId = adminProfile.Id },
                new IdentityUserRole<int> { RoleId = guest.Id, UserId = adminProfile.Id },
                new IdentityUserRole<int> { RoleId = registered.Id, UserId = adminProfile.Id });
        }

        
    }

}
