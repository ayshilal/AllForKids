using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient; 
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using EntityLibrary.Model;

namespace EntityLibrary
{
    public partial class AppDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=AYSEHILALYALCIN\SQLEXPRESS;Database=ApplicationDB;Trusted_Connection=True;");
            }
        }
        public AppDBContext()
        {
        }

        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER", "ApplicationDB");
                entity.Property(e => e.ID).HasColumnName("ID");
                entity.Property(e => e.Name)
                  .IsRequired()
                  .HasColumnName("NAME")
                  .HasMaxLength(25);

                entity.Property(e => e.InsertUserId).HasColumnName("INSERT_USER_ID");

                entity.Property(e => e.InsertDate)
                    .HasColumnName("INSERT_DATE")
                    .HasColumnType("datetime");

                entity.HasIndex(e => e.InsertUserId);

                entity.HasIndex(e => e.LastUpdateUserId).IsUnique(false);

                entity.Property(e => e.LastUpdateUserId).HasColumnName("LAST_UPDATE_USER_ID");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnName("LAST_UPDATE_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnName("STATUS");

            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "ApplicationDB");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.Name).HasColumnName("NAME");
                entity.Property(e => e.InsertDate)
                   .HasColumnName("INSERT_DATE")
                   .HasColumnType("datetime");

                entity.Property(e => e.InsertUserId).HasColumnName("INSERT_USER_ID");

                entity.Property(e => e.LastUpdateDate)
                   .HasColumnName("LAST_UPDATE_DATE")
                   .HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserId).HasColumnName("LAST_UPDATE_USER_ID");


                entity.Property(e => e.Status).HasColumnName("STATUS");

                //entity.HasOne(d => d.InsertUser)
                //  .WithMany(p => p.CustomerInsertuser)
                //  .HasForeignKey(d => d.InsertUserId)
                //  .OnDelete(DeleteBehavior.Cascade)
                //  .HasConstraintName("FK_CUSTOMER_INSERTUSER");

                //entity.HasOne(d => d.LastUpdateUser)
                //   .WithMany(p => p.CustomerLastupdateuser)
                //   .HasForeignKey(d => d.LastUpdateUserId)
                //   .HasConstraintName("FK_CUSTOMER_LASTUPDATEUSER");

            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.ID).HasColumnName("ID");
                entity.Property(e => e.Name).HasColumnName("NAME");
                entity.Property(e => e.Type).HasColumnName("TYPE");
                entity.Property(e => e.Slug).HasColumnName("SLUG");
                entity.Property(e => e.Path).HasColumnName("PATH");
                entity.Property(e => e.Image).HasColumnName("IMAGE");
                entity.Property(e => e.Items).HasColumnName("ITEMS");

                entity.Property(e => e.InsertDate)
                   .HasColumnName("INSERT_DATE")
                   .HasColumnType("datetime");

                entity.Property(e => e.InsertUserId).HasColumnName("INSERT_USER_ID");

                entity.Property(e => e.LastUpdateDate)
                   .HasColumnName("LAST_UPDATE_DATE")
                   .HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserId).HasColumnName("LAST_UPDATE_USER_ID");

                entity.Property(e => e.Status).HasColumnName("STATUS");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ID).HasColumnName("ID");
                entity.Property(e => e.Slug).HasColumnName("SLUG");
                entity.Property(e => e.Name).HasColumnName("NAME");
                entity.Property(e => e.Price).HasColumnName("PRICE");
                entity.Property(e => e.CompareAtPrice).HasColumnName("COMPAREATPRICE");
                entity.Property(e => e.Images).HasColumnName("IMAGES");
                //entity.Property(e => e.Badges).HasColumnName("BADGES");
                entity.Property(e => e.Rating).HasColumnName("RATING");
                entity.Property(e => e.Reviews).HasColumnName("REVIEWS");
                entity.Property(e => e.Availability).HasColumnName("AVAILABILITY");
                //entity.Property(e => e.Brand).HasColumnName("BRAND");

                entity.Property(e => e.InsertDate)
                   .HasColumnName("INSERT_DATE")
                   .HasColumnType("datetime");

                entity.Property(e => e.InsertUserId).HasColumnName("INSERT_USER_ID");

                entity.Property(e => e.LastUpdateDate)
                   .HasColumnName("LAST_UPDATE_DATE")
                   .HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserId).HasColumnName("LAST_UPDATE_USER_ID");

                entity.Property(e => e.Status).HasColumnName("STATUS");
            }); 

            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                 entity.ToTable("ProductAttribute");

                 entity.Property(e => e.ID).HasColumnName("ID");
                 entity.Property(e => e.Slug).HasColumnName("SLUG");
                 entity.Property(e => e.Name).HasColumnName("NAME");
                 entity.Property(e => e.Featured).HasColumnName("FEATURED");
                 //entity.Property(e => e.Values).HasColumnName("VALUES");

                 entity.Property(e => e.InsertDate)
                       .HasColumnName("INSERT_DATE")
                       .HasColumnType("datetime");

                 entity.Property(e => e.InsertUserId).HasColumnName("INSERT_USER_ID");

                 entity.Property(e => e.LastUpdateDate)
                       .HasColumnName("LAST_UPDATE_DATE")
                       .HasColumnType("datetime");

                 entity.Property(e => e.LastUpdateUserId).HasColumnName("LAST_UPDATE_USER_ID");

                 entity.Property(e => e.Status).HasColumnName("STATUS");
             });

            modelBuilder.Entity<ProductAttributeValue>(entity =>
            {
                entity.ToTable("ProductAttributeValue");

                entity.Property(e => e.ID).HasColumnName("ID");
                entity.Property(e => e.Slug).HasColumnName("SLUG");
                entity.Property(e => e.Name).HasColumnName("NAME");

                entity.Property(e => e.InsertDate)
                   .HasColumnName("INSERT_DATE")
                   .HasColumnType("datetime");

                entity.Property(e => e.InsertUserId).HasColumnName("INSERT_USER_ID");

                entity.Property(e => e.LastUpdateDate)
                   .HasColumnName("LAST_UPDATE_DATE")
                   .HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserId).HasColumnName("LAST_UPDATE_USER_ID");

                entity.Property(e => e.Status).HasColumnName("STATUS");
            });
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.ID).HasColumnName("ID");
                entity.Property(e => e.Slug).HasColumnName("SLUG");
                entity.Property(e => e.Name).HasColumnName("NAME");

                entity.Property(e => e.InsertDate)
                   .HasColumnName("INSERT_DATE")
                   .HasColumnType("datetime");

                entity.Property(e => e.InsertUserId).HasColumnName("INSERT_USER_ID");

                entity.Property(e => e.LastUpdateDate)
                   .HasColumnName("LAST_UPDATE_DATE")
                   .HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserId).HasColumnName("LAST_UPDATE_USER_ID");

                entity.Property(e => e.Status).HasColumnName("STATUS");
            });
        }
    }
}