﻿// <auto-generated />
using System;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppData.Migrations
{
    [DbContext(typeof(DBContextModel))]
    [Migration("20230729154839_Pass1")]
    partial class Pass1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AppData.Models.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid?>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ma")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("NgayThanhToan")
                        .HasColumnType("DateTime");

                    b.Property<string>("Sdt")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("TienShip")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("AppData.Models.BillDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("DonGia")
                        .HasColumnType("decimal");

                    b.Property<Guid?>("IdBill")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<Guid?>("IdCombo")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<Guid?>("IdProductDetail")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdBill");

                    b.HasIndex("IdCombo");

                    b.HasIndex("IdProductDetail");

                    b.ToTable("BillDetails");
                });

            modelBuilder.Entity("AppData.Models.Cart", b =>
                {
                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserID");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("AppData.Models.CartDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DetailProductID")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<decimal>("Dongia")
                        .HasColumnType("decimal");

                    b.Property<Guid>("IdCombo")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<int>("Soluong")
                        .HasColumnType("int");

                    b.Property<Guid>("UserID")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.HasKey("Id");

                    b.HasIndex("DetailProductID");

                    b.HasIndex("IdCombo");

                    b.HasIndex("UserID");

                    b.ToTable("CartDetails");
                });

            modelBuilder.Entity("AppData.Models.Combo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ma")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Combos");
                });

            modelBuilder.Entity("AppData.Models.ComboDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("GiaBan")
                        .HasColumnType("decimal");

                    b.Property<Guid>("IdCombo")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<Guid>("IdProductDetail")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.HasKey("Id");

                    b.HasIndex("IdCombo");

                    b.HasIndex("IdProductDetail");

                    b.ToTable("comboDetails");
                });

            modelBuilder.Entity("AppData.Models.ProductDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Anh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GiaBan")
                        .HasColumnType("int");

                    b.Property<string>("Loai")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Ma")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("AppData.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("AppData.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<Guid>("IdRole")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ma")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Sdt")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.HasIndex("IdRole");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AppData.Models.Bill", b =>
                {
                    b.HasOne("AppData.Models.User", "User")
                        .WithMany("Bills")
                        .HasForeignKey("IdUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AppData.Models.BillDetail", b =>
                {
                    b.HasOne("AppData.Models.Bill", "Bill")
                        .WithMany("BillDetails")
                        .HasForeignKey("IdBill");

                    b.HasOne("AppData.Models.Combo", "Combo")
                        .WithMany("BillDetails")
                        .HasForeignKey("IdCombo");

                    b.HasOne("AppData.Models.ProductDetail", "ProductDetail")
                        .WithMany("BillDetail")
                        .HasForeignKey("IdProductDetail");

                    b.Navigation("Bill");

                    b.Navigation("Combo");

                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("AppData.Models.Cart", b =>
                {
                    b.HasOne("AppData.Models.User", "User")
                        .WithOne("Carts")
                        .HasForeignKey("AppData.Models.Cart", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AppData.Models.CartDetail", b =>
                {
                    b.HasOne("AppData.Models.ProductDetail", "ProductDetail")
                        .WithMany("CartDetail")
                        .HasForeignKey("DetailProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppData.Models.Combo", "Combo")
                        .WithMany("CartDetails")
                        .HasForeignKey("IdCombo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppData.Models.Cart", "Cart")
                        .WithMany("cartdetail")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Combo");

                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("AppData.Models.ComboDetail", b =>
                {
                    b.HasOne("AppData.Models.Combo", "Combo")
                        .WithMany("ComboDetail")
                        .HasForeignKey("IdCombo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppData.Models.ProductDetail", "Product")
                        .WithMany("ComboDetails")
                        .HasForeignKey("IdProductDetail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Combo");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AppData.Models.User", b =>
                {
                    b.HasOne("AppData.Models.Role", "Roles")
                        .WithMany("Users")
                        .HasForeignKey("IdRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("AppData.Models.Bill", b =>
                {
                    b.Navigation("BillDetails");
                });

            modelBuilder.Entity("AppData.Models.Cart", b =>
                {
                    b.Navigation("cartdetail");
                });

            modelBuilder.Entity("AppData.Models.Combo", b =>
                {
                    b.Navigation("BillDetails");

                    b.Navigation("CartDetails");

                    b.Navigation("ComboDetail");
                });

            modelBuilder.Entity("AppData.Models.ProductDetail", b =>
                {
                    b.Navigation("BillDetail");

                    b.Navigation("CartDetail");

                    b.Navigation("ComboDetails");
                });

            modelBuilder.Entity("AppData.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("AppData.Models.User", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Carts")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
