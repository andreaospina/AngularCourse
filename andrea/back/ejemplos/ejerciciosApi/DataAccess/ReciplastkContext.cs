using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ejerciciosApi.DataAccess
{
    public partial class ReciplastkContext : DbContext
    {
        public ReciplastkContext()
        {
        }

        public ReciplastkContext(DbContextOptions<ReciplastkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Secondarytabletest> Secondarytabletests { get; set; } = null!;
        public virtual DbSet<Test> Tests { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=reciplastk.cty0a2ewmeb5.us-east-1.rds.amazonaws.com;Database=Reciplastk;Username=postgres;Password=Admin123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Createddate).HasDefaultValueSql("now()");

                entity.Property(e => e.Isactive).HasDefaultValueSql("true");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Creationdate).HasDefaultValueSql("now()");

                entity.Property(e => e.Isactive).HasDefaultValueSql("true");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Roleid)
                    .HasConstraintName("employee_roleid_fkey");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Creationdate).HasDefaultValueSql("now()");

                entity.Property(e => e.Isactive).HasDefaultValueSql("true");

                entity.Property(e => e.Updatedate).HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.Creationdate).HasDefaultValueSql("now()");

                entity.Property(e => e.Isactive).HasDefaultValueSql("true");
            });

            modelBuilder.Entity<Secondarytabletest>(entity =>
            {
                entity.Property(e => e.Createddate).HasDefaultValueSql("now()");

                entity.Property(e => e.Isactive).HasDefaultValueSql("true");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Secondarytabletests)
                    .HasForeignKey(d => d.Testid)
                    .HasConstraintName("secondarytabletest_testid_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
