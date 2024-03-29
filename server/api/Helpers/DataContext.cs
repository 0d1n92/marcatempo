﻿using System;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;
using api.Model.Entity;
using api.Utilitis.Enum;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace api.Helpers;
    public class DataContext : DbContext
    {
        private readonly IWebHostEnvironment _env;
         private readonly IConfiguration _config;
        public DataContext(DbContextOptions<DataContext> options, IWebHostEnvironment env, IConfiguration config) : base(options)
    {
          _env = env;
        _config = config;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<QRcode> QRcodes { get; set; }
        public DbSet<Model.Entity.Action> Actions { get; set; }
        public DbSet<UserMeta> UserMetas { get; set; }
        public DbSet<Giustification> Giustifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<User>(
               entity =>
               {
                   entity.HasIndex(x => x.Email).IsUnique();
                   entity.HasIndex(x => x.Username).IsUnique();
                   entity.HasOne(d => d.Role).WithMany(d => d.Users).HasForeignKey("RoleId");
                   entity.HasOne(d => d.QRCode).WithOne(ad => ad.User).HasForeignKey<QRcode>(d => d.UserId).OnDelete(DeleteBehavior.Cascade);
                   entity.HasMany(usr => usr.UserMetas).WithOne(meta => meta.User).HasForeignKey("UserId").OnDelete(DeleteBehavior.Cascade);
               }
           );

            modelBuilder.Entity<QRcode>(entity => entity.HasIndex(x => x.Token).IsUnique());

            #region RoleSeed
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = (int)EnumRoles.Administrator, Name = EnumRoles.Administrator, Description = "All Permission" },
                new Role { Id = (int)EnumRoles.Operator, Name = EnumRoles.Operator, Description = "Only marking and show" }
                );
        #endregion

        #region UserSeed
        modelBuilder.Entity<User>().HasData(
            new
            {
                Id = 1,
                RoleId = (int)EnumRoles.Administrator,
                Username = _config["AdministratorSettings:Username"],
                FirstName = _config["AdministratorSettings:FirstName"],
                LastName = _config["AdministratorSettings:LastName"],
                Password = _config["AdministratorSettings:Password"],
                Email = _config["AdministratorSettings:Email"],
                CreationDate = DateTime.Now,
                DateOfBirth = DateTime.Now,
                LoginAttempts = 0
            }
        );
        if (_env.IsDevelopment())
        {
            modelBuilder.Entity<User>().HasData(
             new { Id = 2, RoleId = (int)EnumRoles.Operator, Username = "Operator", FirstName = "operator", LastName = "operator", Password = BCryptNet.HashPassword("qwerty"), Email = "operator@mail.com", CreationDate = DateTime.Now, DateOfBirth = DateTime.Now, LoginAttempts = 0 },
             new { Id = 3, RoleId = (int)EnumRoles.Operator, Username = "Pippo", FirstName = "Jonh", LastName = "Doe", Password = BCryptNet.HashPassword("qwerty"), Email = "pippo@mail.com", CreationDate = DateTime.Now, DateOfBirth = DateTime.Now, LoginAttempts = 0 },
             new { Id = 4, RoleId = (int)EnumRoles.Operator, Username = Faker.Internet.UserName(), FirstName = Faker.Name.First(), LastName = Faker.Name.Last(), Password = BCryptNet.HashPassword("qwerty"), Email = Faker.Internet.Email(), CreationDate = DateTime.Now, DateOfBirth = DateTime.Now, LoginAttempts = 0 },
             new { Id = 5, RoleId = (int)EnumRoles.Operator, Username = Faker.Internet.UserName(), FirstName = Faker.Name.First(), LastName = Faker.Name.Last(), Password = BCryptNet.HashPassword("qwerty"), Email = Faker.Internet.Email(), CreationDate = DateTime.Now, DateOfBirth = DateTime.Now, LoginAttempts = 0 },
             new { Id = 6, RoleId = (int)EnumRoles.Operator, Username = Faker.Internet.UserName(), FirstName = Faker.Name.First(), LastName = Faker.Name.Last(), Password = BCryptNet.HashPassword("qwerty"), Email = Faker.Internet.Email(), CreationDate = DateTime.Now, DateOfBirth = DateTime.Now, LoginAttempts = 0 },
             new { Id = 7, RoleId = (int)EnumRoles.Operator, Username = Faker.Internet.UserName(), FirstName = Faker.Name.First(), LastName = Faker.Name.Last(), Password = BCryptNet.HashPassword("qwerty"), Email = Faker.Internet.Email(), CreationDate = DateTime.Now, DateOfBirth = DateTime.Now, LoginAttempts = 0 },
             new { Id = 8, RoleId = (int)EnumRoles.Operator, Username = Faker.Internet.UserName(), FirstName = Faker.Name.First(), LastName = Faker.Name.Last(), Password = BCryptNet.HashPassword("qwerty"), Email = Faker.Internet.Email(), CreationDate = DateTime.Now, DateOfBirth = DateTime.Now, LoginAttempts = 0 },
             new { Id = 9, RoleId = (int)EnumRoles.Operator, Username = Faker.Internet.UserName(), FirstName = Faker.Name.First(), LastName = Faker.Name.Last(), Password = BCryptNet.HashPassword("qwerty"), Email = Faker.Internet.Email(), CreationDate = DateTime.Now, DateOfBirth = DateTime.Now, LoginAttempts = 0 },
             new { Id = 10, RoleId = (int)EnumRoles.Operator, Username = Faker.Internet.UserName(), FirstName = Faker.Name.First(), LastName = Faker.Name.Last(), Password = BCryptNet.HashPassword("qwerty"), Email = Faker.Internet.Email(), CreationDate = DateTime.Now, DateOfBirth = DateTime.Now, LoginAttempts = 0 }
             );

            #endregion
            #region Qrcode


            modelBuilder.Entity<QRcode>().HasData(
              new { Id = 1, Token = Guid.Parse("81a130d2-502f-4cf1-a376-63edeb000e9f"), CreationDate = DateTime.Now, UserId = 2 },
              new { Id = 2, Token = Guid.Parse("67c5064b-7160-4d05-a62e-1799f0d13270"), CreationDate = DateTime.Now, UserId = 3 },
              new { Id = 3, Token = Guid.NewGuid(), CreationDate = DateTime.Now, UserId = 4 },
              new { Id = 4, Token = Guid.NewGuid(), CreationDate = DateTime.Now, UserId = 5 },
              new { Id = 5, Token = Guid.NewGuid(), CreationDate = DateTime.Now, UserId = 6 },
              new { Id = 6, Token = Guid.NewGuid(), CreationDate = DateTime.Now, UserId = 7 },
              new { Id = 7, Token = Guid.NewGuid(), CreationDate = DateTime.Now, UserId = 8 },
              new { Id = 8, Token = Guid.NewGuid(), CreationDate = DateTime.Now, UserId = 9 },
              new { Id = 9, Token = Guid.NewGuid(), CreationDate = DateTime.Now, UserId = 10 }
            );


      #endregion
    }

  }



    }
