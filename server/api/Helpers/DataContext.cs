
using Microsoft.EntityFrameworkCore;
using api.Model.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using api.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace api.Helpers;
    public class DataContext : DbContext
    {
        private readonly IWebHostEnvironment _env;

        private readonly ISeeder _seeder;
    public DataContext(DbContextOptions<DataContext> options, IWebHostEnvironment env, ISeeder seeder) : base(options)
    {
          _env = env;
          _seeder = seeder;
    }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<QRcode> QRcodes { get; set; }
        public DbSet<Model.Entity.Action> Actions { get; set; }
        public DbSet<UserMeta> UserMetas { get; set; }
        public DbSet<Giustification> Giustifications { get; set; }
        public DbSet<Configuration> Configuration { get; set; }

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
                    entity.HasMany(usr => usr.Activities).WithOne(act => act.User).HasForeignKey("UserId").OnDelete(DeleteBehavior.Cascade);
                }
            );

            modelBuilder.Entity<QRcode>(entity => entity.HasIndex(x => x.Token).IsUnique());

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.Property(e => e.Value)
                    .HasConversion(
                        value => JsonConvert.SerializeObject(value),
                        value => JsonConvert.DeserializeObject<JObject>(value)
                    );
            });

            _seeder.Seeding(modelBuilder);
           
            if (_env.IsDevelopment())
            {

                _seeder.DevelopSeeding(modelBuilder);
         
            } else
            {
                _seeder.ProductionSeeding(modelBuilder);
             }

         }



    }
