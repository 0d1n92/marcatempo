﻿using System;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;
using api.Model.Entity;
namespace api.Helpers
{
    public class DataContext : DbContext
    {

        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<QRcode> QRcodes { get; set; }
        public DbSet<Model.Entity.Action> Actions { get; set; }
        public DbSet<UserMeta> UserMetas { get; set; }
        public DbSet<Giustification> Giustifications  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            #region RoleSeed
            modelBuilder.Entity<Role>().HasData(
                new Role { Id =(int)EnumRoles.Administrator, Name = "Administrator", Description = "All Permission" },
                new Role { Id = (int)EnumRoles.Operator, Name = "Operator", Description = "Only marking and show" }
                ) ;
            #endregion
            modelBuilder.Entity<User>(
              entity =>
              {
                  entity.HasOne(d => d.Role).WithMany(d => d.Users).HasForeignKey("RoleId");
                  entity.HasOne(d => d.QRCode).WithOne(ad => ad.User).HasForeignKey<QRcode>(d => d.UserId);
              });

            #region UserSeed
            modelBuilder.Entity<User>().HasData(
             new { Id = 1, RoleId = (int)EnumRoles.Administrator, Username="Administrator", FirstName="admin", LastName = "admin", Password = BCryptNet.HashPassword("qwerty"), CreationDate = DateTime.Now, DateOfBirth = DateTime.Now},
             new { Id = 2, RoleId = (int)EnumRoles.Operator, Username = "Operator", FirstName = "operator", LastName = "operator", Password = BCryptNet.HashPassword("qwerty"), CreationDate = DateTime.Now, DateOfBirth = DateTime.Now },
             new { Id = 3, RoleId = (int)EnumRoles.Operator, Username = "Pippo", FirstName = "Jonh", LastName = "Doe", Password = BCryptNet.HashPassword("qwerty"), CreationDate = DateTime.Now, DateOfBirth = DateTime.Now },
             new { Id = 4, RoleId = (int)EnumRoles.Operator, Username = Faker.Internet.UserName(), FirstName = Faker.Name.First(), LastName = Faker.Name.Last(), Password = BCryptNet.HashPassword("qwerty"), CreationDate = DateTime.Now, DateOfBirth = DateTime.Now },
             new { Id = 5, RoleId = (int)EnumRoles.Operator, Username = Faker.Internet.UserName(), FirstName = Faker.Name.First(), LastName = Faker.Name.Last(), Password = BCryptNet.HashPassword("qwerty"), CreationDate = DateTime.Now, DateOfBirth = DateTime.Now },
             new { Id = 6, RoleId = (int)EnumRoles.Operator, Username = Faker.Internet.UserName(), FirstName = Faker.Name.First(), LastName = Faker.Name.Last(), Password = BCryptNet.HashPassword("qwerty"), CreationDate = DateTime.Now, DateOfBirth = DateTime.Now },
             new { Id = 7, RoleId = (int)EnumRoles.Operator, Username = Faker.Internet.UserName(), FirstName = Faker.Name.First(), LastName = Faker.Name.Last(), Password = BCryptNet.HashPassword("qwerty"), CreationDate = DateTime.Now, DateOfBirth = DateTime.Now },
             new { Id = 8, RoleId = (int)EnumRoles.Operator, Username = Faker.Internet.UserName(), FirstName = Faker.Name.First(), LastName = Faker.Name.Last(), Password = BCryptNet.HashPassword("qwerty"), CreationDate = DateTime.Now, DateOfBirth = DateTime.Now },
             new { Id = 9, RoleId = (int)EnumRoles.Operator, Username = Faker.Internet.UserName(), FirstName = Faker.Name.First(), LastName = Faker.Name.Last(), Password = BCryptNet.HashPassword("qwerty"), CreationDate = DateTime.Now, DateOfBirth = DateTime.Now },
             new { Id = 10, RoleId = (int)EnumRoles.Operator, Username = Faker.Internet.UserName(), FirstName = Faker.Name.First(), LastName = Faker.Name.Last(), Password = BCryptNet.HashPassword("qwerty"), CreationDate = DateTime.Now, DateOfBirth = DateTime.Now }
             );
            #endregion
            #region Qrcode


            modelBuilder.Entity<QRcode>().HasData(
              new { Id = 1, token = "dasdsadasdsadewqrwrfewrewrwerewrewrewrew", CreationDate = DateTime.Now,  UserId = 2},
              new { Id = 2, token = "lglglglgllglglglgllglglglgllglgglgllglglg", CreationDate = DateTime.Now, UserId = 3 },
              new { Id = 3, token = Faker.Identification.UkNationalInsuranceNumber(), CreationDate = DateTime.Now, UserId = 4 },
              new { Id = 4, token = Faker.Identification.UkNationalInsuranceNumber(), CreationDate = DateTime.Now, UserId = 5 },
              new { Id = 5, token = Faker.Identification.UkNationalInsuranceNumber(), CreationDate = DateTime.Now, UserId = 6 },
              new { Id = 6, token = Faker.Identification.UkNationalInsuranceNumber(),  CreationDate = DateTime.Now, UserId = 7 },
              new { Id = 7, token = Faker.Identification.UkNationalInsuranceNumber(), CreationDate = DateTime.Now, UserId = 8 },
              new { Id = 8, token = Faker.Identification.UkNationalInsuranceNumber(),CreationDate = DateTime.Now, UserId = 9 },
              new { Id = 9, token = Faker.Identification.UkNationalInsuranceNumber(), CreationDate = DateTime.Now, UserId = 10 }
            );


            #endregion

        }



    }
}
