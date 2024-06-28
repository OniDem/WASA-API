﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WASA_API.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Entity.CategoryShowEntity", b =>
                {
                    b.Property<string>("CategoryName")
                        .HasColumnType("text");

                    b.HasKey("CategoryName");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("Core.Entity.ProductEntity", b =>
                {
                    b.Property<string>("ProductCode")
                        .HasColumnType("text");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Count")
                        .HasColumnType("double precision");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProductCode");

                    b.ToTable("products");
                });

            modelBuilder.Entity("Core.Entity.ReceiptEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CancelDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CancelReason")
                        .HasColumnType("integer");

                    b.Property<bool>("Canceled")
                        .HasColumnType("boolean");

                    b.Property<bool>("Closed")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ClosedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double?>("LoyaltyBonusAdded")
                        .HasColumnType("double precision");

                    b.Property<int?>("LoyaltyCardID")
                        .HasColumnType("integer");

                    b.Property<int?>("PayMethod")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<List<string>>("ProductCategories")
                        .HasColumnType("text[]");

                    b.Property<List<string>>("ProductCodes")
                        .HasColumnType("text[]");

                    b.Property<List<double>>("ProductCount")
                        .HasColumnType("double precision[]");

                    b.Property<List<string>>("ProductNames")
                        .HasColumnType("text[]");

                    b.Property<List<double>>("ProductPrices")
                        .HasColumnType("double precision[]");

                    b.Property<string>("Seller")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Total")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("receipts");
                });

            modelBuilder.Entity("Core.Entity.ShiftEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double?>("Acquiring")
                        .HasColumnType("double precision");

                    b.Property<bool?>("AcquiringApproved")
                        .HasColumnType("boolean");

                    b.Property<double?>("Cash")
                        .HasColumnType("double precision");

                    b.Property<double?>("CashBox")
                        .HasColumnType("double precision");

                    b.Property<List<string>>("CashBoxOperations")
                        .HasColumnType("text[]");

                    b.Property<DateTime?>("CloseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool?>("Closed")
                        .HasColumnType("boolean");

                    b.Property<string>("ClosedBy")
                        .HasColumnType("text");

                    b.Property<string>("OpenBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<List<int>>("ReceiptsList")
                        .HasColumnType("integer[]");

                    b.Property<double?>("Total")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("Acquiring");

                    NpgsqlIndexBuilderExtensions.AreNullsDistinct(b.HasIndex("Acquiring"), true);

                    b.HasIndex("AcquiringApproved");

                    NpgsqlIndexBuilderExtensions.AreNullsDistinct(b.HasIndex("AcquiringApproved"), true);

                    b.HasIndex("Cash");

                    NpgsqlIndexBuilderExtensions.AreNullsDistinct(b.HasIndex("Cash"), true);

                    b.HasIndex("CashBox");

                    NpgsqlIndexBuilderExtensions.AreNullsDistinct(b.HasIndex("CashBox"), true);

                    b.HasIndex("CashBoxOperations");

                    NpgsqlIndexBuilderExtensions.AreNullsDistinct(b.HasIndex("CashBoxOperations"), true);

                    b.HasIndex("CloseDate");

                    NpgsqlIndexBuilderExtensions.AreNullsDistinct(b.HasIndex("CloseDate"), true);

                    b.HasIndex("Closed");

                    NpgsqlIndexBuilderExtensions.AreNullsDistinct(b.HasIndex("Closed"), true);

                    b.HasIndex("ClosedBy");

                    NpgsqlIndexBuilderExtensions.AreNullsDistinct(b.HasIndex("ClosedBy"), true);

                    b.HasIndex("ReceiptsList");

                    NpgsqlIndexBuilderExtensions.AreNullsDistinct(b.HasIndex("ReceiptsList"), true);

                    b.HasIndex("Total");

                    NpgsqlIndexBuilderExtensions.AreNullsDistinct(b.HasIndex("Total"), true);

                    b.ToTable("shifts");
                });

            modelBuilder.Entity("Core.Entity.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}
