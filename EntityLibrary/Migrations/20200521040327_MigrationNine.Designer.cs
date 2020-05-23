﻿// <auto-generated />
using System;
using EntityLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityLibrary.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20200521040327_MigrationNine")]
    partial class MigrationNine
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityLibrary.Model.Category", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .HasColumnName("IMAGE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnName("INSERT_DATE")
                        .HasColumnType("datetime");

                    b.Property<long>("InsertUserId")
                        .HasColumnName("INSERT_USER_ID")
                        .HasColumnType("bigint");

                    b.Property<int>("Items")
                        .HasColumnName("ITEMS")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnName("LAST_UPDATE_DATE")
                        .HasColumnType("datetime");

                    b.Property<long?>("LastUpdateUserId")
                        .HasColumnName("LAST_UPDATE_USER_ID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnName("PATH")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnName("SLUG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnName("STATUS")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnName("TYPE")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category","ApplicationDB");
                });

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
                        .HasColumnName("INSERT_DATE")
                        .HasColumnType("datetime");

                    b.Property<long>("InsertUserId")
                        .HasColumnName("INSERT_USER_ID")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnName("LAST_UPDATE_DATE")
                        .HasColumnType("datetime");

                    b.Property<long?>("LastUpdateUserId")
                        .HasColumnName("LAST_UPDATE_USER_ID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnName("STATUS")
                        .HasColumnType("int");

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

                    b.Property<long>("InsertUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LastUpdateUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

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

                    b.Property<long>("InsertUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LastUpdateUserId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Purchase");
                });

            modelBuilder.Entity("EntityLibrary.Model.User", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertDate")
                        .HasColumnName("INSERT_DATE")
                        .HasColumnType("datetime");

                    b.Property<long>("InsertUserId")
                        .HasColumnName("INSERT_USER_ID")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnName("LAST_UPDATE_DATE")
                        .HasColumnType("datetime");

                    b.Property<long?>("LastUpdateUserId")
                        .HasColumnName("LAST_UPDATE_USER_ID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<int>("Status")
                        .HasColumnName("STATUS")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("InsertUserId");

                    b.HasIndex("LastUpdateUserId");

                    b.ToTable("USER","ApplicationDB");
                });
#pragma warning restore 612, 618
        }
    }
}
