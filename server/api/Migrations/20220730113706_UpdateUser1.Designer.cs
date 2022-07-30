﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Helpers;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220730113706_UpdateUser1")]
    partial class UpdateUser1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("api.Model.Entity.Action", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("Entry")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("Exit")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("GiustificationId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsPresent")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GiustificationId");

                    b.HasIndex("UserId");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("api.Model.Entity.Giustification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Duration")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.Property<string>("code")
                        .HasColumnType("longtext");

                    b.Property<string>("note")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Giustifications");
                });

            modelBuilder.Entity("api.Model.Entity.QRcode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("token")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.HasIndex("token")
                        .IsUnique();

                    b.ToTable("QRcodes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2022, 7, 30, 13, 37, 5, 880, DateTimeKind.Local).AddTicks(7442),
                            UserId = 2,
                            token = "81a130d2-502f-4cf1-a376-63edeb000e9f"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2022, 7, 30, 13, 37, 5, 880, DateTimeKind.Local).AddTicks(7449),
                            UserId = 3,
                            token = "67c5064b-7160-4d05-a62e-1799f0d13270"
                        },
                        new
                        {
                            Id = 3,
                            CreationDate = new DateTime(2022, 7, 30, 13, 37, 5, 880, DateTimeKind.Local).AddTicks(7480),
                            UserId = 4,
                            token = "44e6c5e0-f2cb-4ba5-bf36-b991fdd58da0"
                        },
                        new
                        {
                            Id = 4,
                            CreationDate = new DateTime(2022, 7, 30, 13, 37, 5, 880, DateTimeKind.Local).AddTicks(7482),
                            UserId = 5,
                            token = "736289c5-60ce-488b-9787-4eb2a4fb6059"
                        },
                        new
                        {
                            Id = 5,
                            CreationDate = new DateTime(2022, 7, 30, 13, 37, 5, 880, DateTimeKind.Local).AddTicks(7484),
                            UserId = 6,
                            token = "856c2d80-ad33-44cd-86e1-0f62ff0ee0d4"
                        },
                        new
                        {
                            Id = 6,
                            CreationDate = new DateTime(2022, 7, 30, 13, 37, 5, 880, DateTimeKind.Local).AddTicks(7486),
                            UserId = 7,
                            token = "9b37cc2a-49ee-43af-90e1-65e93f3675a9"
                        },
                        new
                        {
                            Id = 7,
                            CreationDate = new DateTime(2022, 7, 30, 13, 37, 5, 880, DateTimeKind.Local).AddTicks(7488),
                            UserId = 8,
                            token = "795bec11-cc76-43b6-91ca-af26a84c4ec0"
                        },
                        new
                        {
                            Id = 8,
                            CreationDate = new DateTime(2022, 7, 30, 13, 37, 5, 880, DateTimeKind.Local).AddTicks(7490),
                            UserId = 9,
                            token = "8e8aa99b-087f-4130-b51b-533468961e0d"
                        },
                        new
                        {
                            Id = 9,
                            CreationDate = new DateTime(2022, 7, 30, 13, 37, 5, 880, DateTimeKind.Local).AddTicks(7492),
                            UserId = 10,
                            token = "d11cd38d-336c-4008-a20c-10540c13e71e"
                        });
                });

            modelBuilder.Entity("api.Model.Entity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "All Permission",
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Only marking and show",
                            Name = "Operator"
                        });
                });

            modelBuilder.Entity("api.Model.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2022, 7, 30, 13, 37, 4, 547, DateTimeKind.Local).AddTicks(526),
                            DateOfBirth = new DateTime(2022, 7, 30, 13, 37, 4, 547, DateTimeKind.Local).AddTicks(565),
                            Email = "admin@mail.com",
                            FirstName = "admin",
                            LastName = "admin",
                            Password = "$2a$11$uNBPtjKJs6StvtCiDGt35ORja4IYYnj5eregWvgweZq6HRmnqRD5q",
                            RoleId = 1,
                            Username = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2022, 7, 30, 13, 37, 4, 693, DateTimeKind.Local).AddTicks(1659),
                            DateOfBirth = new DateTime(2022, 7, 30, 13, 37, 4, 693, DateTimeKind.Local).AddTicks(1721),
                            Email = "operator@mail.com",
                            FirstName = "operator",
                            LastName = "operator",
                            Password = "$2a$11$OHAUNcLiv41nLM765zqWhOxHwNh33WX7ferYnvqzWVbvn1ZQKVVQO",
                            RoleId = 2,
                            Username = "Operator"
                        },
                        new
                        {
                            Id = 3,
                            CreationDate = new DateTime(2022, 7, 30, 13, 37, 4, 841, DateTimeKind.Local).AddTicks(1827),
                            DateOfBirth = new DateTime(2022, 7, 30, 13, 37, 4, 841, DateTimeKind.Local).AddTicks(1896),
                            Email = "pippo@mail.com",
                            FirstName = "Jonh",
                            LastName = "Doe",
                            Password = "$2a$11$eG8k5VCUQddD7I5/Qwi6YepMhP19K6Gcx9/KVbU6bOvSBVBuxebdO",
                            RoleId = 2,
                            Username = "Pippo"
                        },
                        new
                        {
                            Id = 4,
                            CreationDate = new DateTime(2022, 7, 30, 13, 37, 4, 988, DateTimeKind.Local).AddTicks(7658),
                            DateOfBirth = new DateTime(2022, 7, 30, 13, 37, 4, 988, DateTimeKind.Local).AddTicks(7679),
                            Email = "elenora@jast.com",
                            FirstName = "Edward",
                            LastName = "Torphy",
                            Password = "$2a$11$rsvhtxvoRus2sN5Mm5s.KeMDIpj3cVoULSnx0ZvT0mj4R6wXGkcVK",
                            RoleId = 2,
                            Username = "gina"
                        },
                        new
                        {
                            Id = 5,
                            CreationDate = new DateTime(2022, 7, 30, 13, 37, 5, 142, DateTimeKind.Local).AddTicks(9576),
                            DateOfBirth = new DateTime(2022, 7, 30, 13, 37, 5, 142, DateTimeKind.Local).AddTicks(9597),
                            Email = "forrest@nitzsche.name",
                            FirstName = "Damien",
                            LastName = "Roberts",
                            Password = "$2a$11$bTIhcnIZVTjllnV/DbBzZejx1Mhpufw4N5Qfr6pPgwUZgLGWIK8py",
                            RoleId = 2,
                            Username = "fern"
                        },
                        new
                        {
                            Id = 6,
                            CreationDate = new DateTime(2022, 7, 30, 13, 37, 5, 292, DateTimeKind.Local).AddTicks(5834),
                            DateOfBirth = new DateTime(2022, 7, 30, 13, 37, 5, 292, DateTimeKind.Local).AddTicks(5856),
                            Email = "connor_adams@vonruedenbeahan.info",
                            FirstName = "Garret",
                            LastName = "Wisoky",
                            Password = "$2a$11$Nl6WW7.P01KYLkHQzdog2OF15NT9XXB1QUNSfTgyPQI8kPbtxT58i",
                            RoleId = 2,
                            Username = "fredrick_shields"
                        },
                        new
                        {
                            Id = 7,
                            CreationDate = new DateTime(2022, 7, 30, 13, 37, 5, 441, DateTimeKind.Local).AddTicks(1103),
                            DateOfBirth = new DateTime(2022, 7, 30, 13, 37, 5, 441, DateTimeKind.Local).AddTicks(1125),
                            Email = "terrell.kulas@carter.ca",
                            FirstName = "Vinnie",
                            LastName = "Bode",
                            Password = "$2a$11$AD2K8FIj8lyDMUHJapaf1.BC2I0jZnBle1Bm85leJJ.xa0oU9CjWG",
                            RoleId = 2,
                            Username = "daphne"
                        },
                        new
                        {
                            Id = 8,
                            CreationDate = new DateTime(2022, 7, 30, 13, 37, 5, 588, DateTimeKind.Local).AddTicks(5908),
                            DateOfBirth = new DateTime(2022, 7, 30, 13, 37, 5, 588, DateTimeKind.Local).AddTicks(5924),
                            Email = "alford.vandervort@wilderman.info",
                            FirstName = "Rick",
                            LastName = "Dach",
                            Password = "$2a$11$dniwHzuEsD4KoduDd0a9wO58fG1eihofxyOVekrq0sL3EVh3jWZzi",
                            RoleId = 2,
                            Username = "bryana_reichel"
                        },
                        new
                        {
                            Id = 9,
                            CreationDate = new DateTime(2022, 7, 30, 13, 37, 5, 734, DateTimeKind.Local).AddTicks(9403),
                            DateOfBirth = new DateTime(2022, 7, 30, 13, 37, 5, 734, DateTimeKind.Local).AddTicks(9420),
                            Email = "lawrence@nicolas.co.uk",
                            FirstName = "Russel",
                            LastName = "Lynch",
                            Password = "$2a$11$Q8NYN56./s6F5aGgGnZp0.jlJwt9NjP2D5Ed/WkI9OjobQsCCiV.O",
                            RoleId = 2,
                            Username = "demarcus"
                        },
                        new
                        {
                            Id = 10,
                            CreationDate = new DateTime(2022, 7, 30, 13, 37, 5, 880, DateTimeKind.Local).AddTicks(7145),
                            DateOfBirth = new DateTime(2022, 7, 30, 13, 37, 5, 880, DateTimeKind.Local).AddTicks(7170),
                            Email = "prince@littel.com",
                            FirstName = "Freda",
                            LastName = "Mertz",
                            Password = "$2a$11$GSG0JCnOT.vSk8vAgWKM1uNe0oqvix8ebi8cgKlWtuWDC2myUw0um",
                            RoleId = 2,
                            Username = "tamia_mitchell"
                        });
                });

            modelBuilder.Entity("api.Model.Entity.UserMeta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.Property<string>("metaLabel")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserMetas");
                });

            modelBuilder.Entity("api.Model.Entity.Action", b =>
                {
                    b.HasOne("api.Model.Entity.Giustification", "Giustification")
                        .WithMany("Activitis")
                        .HasForeignKey("GiustificationId");

                    b.HasOne("api.Model.Entity.User", "User")
                        .WithMany("Activities")
                        .HasForeignKey("UserId");

                    b.Navigation("Giustification");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Model.Entity.QRcode", b =>
                {
                    b.HasOne("api.Model.Entity.User", "User")
                        .WithOne("QRCode")
                        .HasForeignKey("api.Model.Entity.QRcode", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Model.Entity.User", b =>
                {
                    b.HasOne("api.Model.Entity.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("api.Model.Entity.UserMeta", b =>
                {
                    b.HasOne("api.Model.Entity.User", "User")
                        .WithMany("UserMetas")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Model.Entity.Giustification", b =>
                {
                    b.Navigation("Activitis");
                });

            modelBuilder.Entity("api.Model.Entity.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("api.Model.Entity.User", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("QRCode");

                    b.Navigation("UserMetas");
                });
#pragma warning restore 612, 618
        }
    }
}
