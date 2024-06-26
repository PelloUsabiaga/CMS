﻿// <auto-generated />
using System;
using CMS02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CMS02.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20210618071022_18062021")]
    partial class _18062021
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("CMS02.Models.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("DocTipe")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Public")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("ShowDescription")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("DocumentId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("CMS02.Models.Ouners", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("DocumentId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "DocumentId");

                    b.ToTable("Ouners");
                });

            modelBuilder.Entity("CMS02.Models.Permisions", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("CanShare")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("CanUseGenerics")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("MaxPDFAmount")
                        .HasColumnType("int");

                    b.Property<int>("MaxPDFSize")
                        .HasColumnType("int");

                    b.Property<int>("MaxPictureAmount")
                        .HasColumnType("int");

                    b.Property<int>("MaxPictureSize")
                        .HasColumnType("int");

                    b.Property<int>("MaxVideoAmount")
                        .HasColumnType("int");

                    b.Property<int>("MaxVideoSize")
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RoleId");

                    b.ToTable("Permisions");
                });

            modelBuilder.Entity("CMS02.Models.Roles", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CMS02.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("State");
                });

            modelBuilder.Entity("CMS02.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
