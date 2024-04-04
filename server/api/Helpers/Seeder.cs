using api.Interface;
using api.Model.Entity;
using api.Utilitis.Enum;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using api.Models.Data;
using AutoMapper;
using Newtonsoft.Json.Linq;

namespace api.Helpers
{
    public class Seeder : ISeeder
    {

        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public Seeder(IConfiguration config, IMapper mapper)
        {
            
            _config = config;
            _mapper = mapper;
        }
   
        public void DevelopSeeding(ModelBuilder modelBuilder)
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


            var stmpConfig = new SmtpConfig
            {
                Server = _config["MailSettings:Server"],
                UserName = _config["MailSettings:UserName"],
                Port = int.Parse(_config["MailSettings:Port"]),
                SenderEmail = _config["MailSettings:SenderEmail"],
                SenderName = _config["MailSettings:SenderName"],
                Password = _config["MailSettings:Password"],
            };

      

            modelBuilder.Entity<Configuration>().HasData(
                new Configuration
                {
                    Id = 1,
                    MetaName = "mail_smtp_server",
                    Description = "server smtp",
                    Category = "mail",
                    Value = JObject.FromObject(stmpConfig)
                }
                );

        }

        public void ProductionSeeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Configuration>().HasData(
            new Configuration
            {
                Id = 1,
                MetaName = "mail_smtp_server",
                Description = "server smtp",
                Category = "mail",
                Value = JObject.FromObject(new SmtpConfig())
            }
            );
        }

        public void Seeding(ModelBuilder modelBuilder)
        {
            

            #region RoleSeed
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = (int)EnumRoles.Administrator, Name = EnumRoles.Administrator, Description = "All Permission" },
                new Role { Id = (int)EnumRoles.Operator, Name = EnumRoles.Operator, Description = "Only marking and show" }
                );
            #endregion

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
        }
    }
}
