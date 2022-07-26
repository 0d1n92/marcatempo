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
    [Migration("20220720210354_Dbinit")]
    partial class Dbinit
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
                            CreationDate = new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6151),
                            UserId = 2,
                            token = "81a130d2-502f-4cf1-a376-63edeb000e9f"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6155),
                            UserId = 3,
                            token = "67c5064b-7160-4d05-a62e-1799f0d13270"
                        },
                        new
                        {
                            Id = 3,
                            CreationDate = new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6187),
                            UserId = 4,
                            token = "7775286b-4123-4e89-ba8e-f59dec0deb2a"
                        },
                        new
                        {
                            Id = 4,
                            CreationDate = new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6199),
                            UserId = 5,
                            token = "dde23727-5cae-4cf0-8adf-3ee8238d33b1"
                        },
                        new
                        {
                            Id = 5,
                            CreationDate = new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6201),
                            UserId = 6,
                            token = "426b8696-84d2-45d2-91b7-eb4eccece2fc"
                        },
                        new
                        {
                            Id = 6,
                            CreationDate = new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6203),
                            UserId = 7,
                            token = "02dc24d8-5f53-4e4a-b1c7-5636b864e6c2"
                        },
                        new
                        {
                            Id = 7,
                            CreationDate = new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6205),
                            UserId = 8,
                            token = "0c49a450-b2ba-4024-ac97-3482de9618b8"
                        },
                        new
                        {
                            Id = 8,
                            CreationDate = new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6207),
                            UserId = 9,
                            token = "63b0a13c-6366-45ec-8586-119a384de033"
                        },
                        new
                        {
                            Id = 9,
                            CreationDate = new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6208),
                            UserId = 10,
                            token = "961c4a82-9a03-4211-8b9a-60d986f66398"
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

                    b.Property<string>("Token")
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
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
                            CreationDate = new DateTime(2022, 7, 20, 23, 3, 53, 117, DateTimeKind.Local).AddTicks(1687),
                            DateOfBirth = new DateTime(2022, 7, 20, 23, 3, 53, 117, DateTimeKind.Local).AddTicks(1751),
                            FirstName = "admin",
                            LastName = "admin",
                            Password = "$2a$11$Vq5U9P2BVI24IyGfdLpbWeULwZ/t2RejCPuMEvJYc5PINZ25THZF.",
                            RoleId = 1,
                            Username = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2022, 7, 20, 23, 3, 53, 265, DateTimeKind.Local).AddTicks(7100),
                            DateOfBirth = new DateTime(2022, 7, 20, 23, 3, 53, 265, DateTimeKind.Local).AddTicks(7132),
                            FirstName = "operator",
                            LastName = "operator",
                            Password = "$2a$11$S5/s/4kigUp7hmnf6fLlTuAhoV0aj9ZK3Au6avjEt/F4px0ac0WCm",
                            RoleId = 2,
                            Username = "Operator"
                        },
                        new
                        {
                            Id = 3,
                            CreationDate = new DateTime(2022, 7, 20, 23, 3, 53, 416, DateTimeKind.Local).AddTicks(9927),
                            DateOfBirth = new DateTime(2022, 7, 20, 23, 3, 53, 417, DateTimeKind.Local).AddTicks(2),
                            FirstName = "Jonh",
                            LastName = "Doe",
                            Password = "$2a$11$KWAX85M0NVuntHi/N/2rfe6rW6JoAY/aZgXVV6/Z06JfF7EWrccju",
                            RoleId = 2,
                            Username = "Pippo"
                        },
                        new
                        {
                            Id = 4,
                            CreationDate = new DateTime(2022, 7, 20, 23, 3, 53, 565, DateTimeKind.Local).AddTicks(5460),
                            DateOfBirth = new DateTime(2022, 7, 20, 23, 3, 53, 565, DateTimeKind.Local).AddTicks(5491),
                            FirstName = "Hunter",
                            LastName = "Schmidt",
                            Password = "$2a$11$0L/dgczJvXEQroRYYNrGIO8EYXLYDfuoLL2Irm4YKkSe9Bcq9eIty",
                            RoleId = 2,
                            Username = "arielle"
                        },
                        new
                        {
                            Id = 5,
                            CreationDate = new DateTime(2022, 7, 20, 23, 3, 53, 717, DateTimeKind.Local).AddTicks(8320),
                            DateOfBirth = new DateTime(2022, 7, 20, 23, 3, 53, 717, DateTimeKind.Local).AddTicks(8352),
                            FirstName = "Helene",
                            LastName = "Hills",
                            Password = "$2a$11$RQmX726DCCUVPUTkmCJ1GuFaASBY5ICV2agbyn761teY6geQQaX5O",
                            RoleId = 2,
                            Username = "ruben"
                        },
                        new
                        {
                            Id = 6,
                            CreationDate = new DateTime(2022, 7, 20, 23, 3, 53, 866, DateTimeKind.Local).AddTicks(4601),
                            DateOfBirth = new DateTime(2022, 7, 20, 23, 3, 53, 866, DateTimeKind.Local).AddTicks(4629),
                            FirstName = "Unique",
                            LastName = "Oberbrunner",
                            Password = "$2a$11$GuE7N9mrLYoTRRvj47Yoiexg3.Y9iJQEvpMchFvpZq5sxTC3HlZNG",
                            RoleId = 2,
                            Username = "audrey.konopelski"
                        },
                        new
                        {
                            Id = 7,
                            CreationDate = new DateTime(2022, 7, 20, 23, 3, 54, 15, DateTimeKind.Local).AddTicks(9638),
                            DateOfBirth = new DateTime(2022, 7, 20, 23, 3, 54, 15, DateTimeKind.Local).AddTicks(9666),
                            FirstName = "Wiley",
                            LastName = "Roob",
                            Password = "$2a$11$jKCS0CShf5QpjISrZ0QS9.ifnlGqG63a86XuhFvRY6Vc4B6JdnyCy",
                            RoleId = 2,
                            Username = "elta"
                        },
                        new
                        {
                            Id = 8,
                            CreationDate = new DateTime(2022, 7, 20, 23, 3, 54, 164, DateTimeKind.Local).AddTicks(5676),
                            DateOfBirth = new DateTime(2022, 7, 20, 23, 3, 54, 164, DateTimeKind.Local).AddTicks(5704),
                            FirstName = "Elisha",
                            LastName = "Stokes",
                            Password = "$2a$11$4MPrETWyC09jy8DlmTkseuIuaR1wIqPjxUVB.2FVjb18qomA9vg.e",
                            RoleId = 2,
                            Username = "deborah"
                        },
                        new
                        {
                            Id = 9,
                            CreationDate = new DateTime(2022, 7, 20, 23, 3, 54, 313, DateTimeKind.Local).AddTicks(2339),
                            DateOfBirth = new DateTime(2022, 7, 20, 23, 3, 54, 313, DateTimeKind.Local).AddTicks(2368),
                            FirstName = "Jamel",
                            LastName = "Ziemann",
                            Password = "$2a$11$IMeg3lyORLRggsdR6xrTEuvhbzLsSRcghnGLGq.08buyS08SFZuh.",
                            RoleId = 2,
                            Username = "wava_reinger"
                        },
                        new
                        {
                            Id = 10,
                            CreationDate = new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(5577),
                            DateOfBirth = new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(5605),
                            FirstName = "Naomi",
                            LastName = "Welch",
                            Password = "$2a$11$M.vwVLKPQI0wc3itBBq9luiQkEq3YT7JW4lnjpDyLznrcLOZar24u",
                            RoleId = 2,
                            Username = "charlotte_stiedemann"
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
                        .WithMany()
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
                });
#pragma warning restore 612, 618
        }
    }
}