﻿// <auto-generated />
using System;
using EntityLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityLibrary.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityLibrary.Model.Customer", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Customer","ApplicationDB");
                });

            modelBuilder.Entity("EntityLibrary.Model.Product", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<long?>("PurchaseID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("PurchaseID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("EntityLibrary.Model.Purchase", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Purchase");
                });

            modelBuilder.Entity("EntityLibrary.Model.User", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PurchaseID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("PurchaseID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("EntityLibrary.Model.Product", b =>
                {
                    b.HasOne("EntityLibrary.Model.Purchase", null)
                        .WithMany("Product")
                        .HasForeignKey("PurchaseID");
                });

            modelBuilder.Entity("EntityLibrary.Model.User", b =>
                {
                    b.HasOne("EntityLibrary.Model.Purchase", null)
                        .WithMany("User")
                        .HasForeignKey("PurchaseID");
                });
#pragma warning restore 612, 618
        }
    }
}
