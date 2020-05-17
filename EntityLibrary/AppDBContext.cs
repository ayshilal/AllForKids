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

        }
    }
}