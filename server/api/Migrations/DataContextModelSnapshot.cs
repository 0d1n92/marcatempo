﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Helpers;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("api.Response.Activity", b =>
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

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("api.Response.Giustification", b =>
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

            modelBuilder.Entity("api.Response.QRcode", b =>
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
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("QRcodes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2022, 3, 26, 20, 54, 48, 583, DateTimeKind.Local).AddTicks(4475),
                            UserId = 2,
                            token = "dasdsadasdsadewqrwrfewrewrwerewrewrewrew"
                        });
                });

            modelBuilder.Entity("api.Response.Role", b =>
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

            modelBuilder.Entity("api.Response.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

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
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2022, 3, 26, 20, 54, 48, 439, DateTimeKind.Local).AddTicks(1293),
                            DateOfBirth = new DateTime(2022, 3, 26, 20, 54, 48, 439, DateTimeKind.Local).AddTicks(1345),
                            FirstName = "admin",
                            LastName = "admin",
                            Password = "$2a$11$sD7UBk.VQjWtblSkislsCelBEixFFzTplImx3XmXX/1ZApLmzPSyK",
                            RoleId = 1,
                            Username = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2022, 3, 26, 20, 54, 48, 583, DateTimeKind.Local).AddTicks(4157),
                            DateOfBirth = new DateTime(2022, 3, 26, 20, 54, 48, 583, DateTimeKind.Local).AddTicks(4204),
                            FirstName = "operator",
                            LastName = "operator",
                            Password = "$2a$11$qWBcvbFaYe9iiFL9bn1uPuTikr6wveS6Ch7LnMrh/tMnhAQYbyQWK",
                            RoleId = 2,
                            Username = "Operator"
                        });
                });

            modelBuilder.Entity("api.Response.Activity", b =>
                {
                    b.HasOne("api.Response.Giustification", "Giustification")
                        .WithMany("Activitis")
                        .HasForeignKey("GiustificationId");

                    b.HasOne("api.Response.User", "User")
                        .WithMany("Activities")
                        .HasForeignKey("UserId");

                    b.Navigation("Giustification");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Response.QRcode", b =>
                {
                    b.HasOne("api.Response.User", "User")
                        .WithOne("QRCode")
                        .HasForeignKey("api.Response.QRcode", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Response.User", b =>
                {
                    b.HasOne("api.Response.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("api.Response.Giustification", b =>
                {
                    b.Navigation("Activitis");
                });

            modelBuilder.Entity("api.Response.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("api.Response.User", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("QRCode");
                });
#pragma warning restore 612, 618
        }
    }
}
