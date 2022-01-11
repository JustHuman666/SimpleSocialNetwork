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

        //public NetworkContext(DbContextOptions options) : base(options)
        //{
        //}

        //public NetworkContext() : base()
        //{
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server = localhost, 1433; Database = SocialNetwork; User ID = sa; Password = <password12345>")
        //        .EnableSensitiveDataLogging();
        //}

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserChat> UsersChats { get; set; }
        public DbSet<UserFriends> UsersFriends { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new Role() { Id = 1, Name = "Admin", NormalizedName = "ADMIN" };
            var registered = new Role() { Id = 2, Name = "Registered", NormalizedName = "REGISTERED" };

            builder.Entity<Role>().HasData(admin, registered);

            var adminData = new User()
            {
                Id = 1,
                Email = "e.myhalchuk@gmail.com",
                PhoneNumber = "+380671234567",
                NormalizedEmail = "E.MYHALCHUK@GMAIL.COM",
                UserName = "AdminElya",
                NormalizedUserName = "ADMINELYA",
            };
            var adminProfile = new UserProfile()
            {
                Id = adminData.Id,
                FirstName = "Eleonora",
                LastName = "Mykhalchuk",
            };

            var defaultUser = new User()
            {
                Id = 2,
                Email = "default@gmail.com",
                PhoneNumber = "+380000000000",
                NormalizedEmail = "DEFAULT@GMAIL.COM",
                UserName = "Default",
                NormalizedUserName = "DEFAULT",
            };
            var defaultProfile = new UserProfile()
            {
                Id = defaultUser.Id,
                FirstName = "DefaultName",
                LastName = "DefaultLast",
            };

            var passwordHasher = new PasswordHasher<User>();
            adminData.PasswordHash = passwordHasher.HashPassword(adminData, "AdminPassword_1");
            defaultUser.PasswordHash = passwordHasher.HashPassword(defaultUser, "DefaultPassword_2");

            builder.Entity<User>().HasData(adminData, defaultUser);
            builder.Entity<UserProfile>().HasData(adminProfile, defaultProfile);

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { RoleId = admin.Id, UserId = adminProfile.Id },
                new IdentityUserRole<int> { RoleId = registered.Id, UserId = adminProfile.Id },
                new IdentityUserRole<int> { RoleId = registered.Id, UserId = defaultUser.Id });

            builder.Entity<UserProfile>().HasMany(x => x.Chats).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            builder.Entity<Chat>().HasMany(x => x.Users).WithOne(x => x.Chat).HasForeignKey(x => x.ChatId);
            builder.Entity<UserProfile>().HasOne(x => x.AppUser).WithOne(x => x.UserProfile).HasForeignKey<UserProfile>(x => x.Id);
            builder.Entity<UserFriends>().HasKey(x => new { x.UserId, x.FriendId});
            builder.Entity<UserFriends>().HasOne(x => x.User).WithMany(x => x.ThisUserFriends).OnDelete(DeleteBehavior.NoAction).HasForeignKey(x => x.UserId); 
            builder.Entity<UserFriends>().HasOne(x => x.Friend).WithMany(x => x.UserIsFriend).OnDelete(DeleteBehavior.NoAction).HasForeignKey(x => x.FriendId);
            builder.Entity<UserChat>().HasKey(x => new { x.UserId, x.ChatId });
            builder.Entity<UserChat>().HasOne(x => x.User).WithMany(x => x.Chats).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x => x.UserId);
            builder.Entity<UserChat>().HasOne(x => x.Chat).WithMany(x => x.Users).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x => x.ChatId);


        }

    }

}
