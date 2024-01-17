using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;




namespace AdminEquipoApi.Models
{
    public partial class ADMINEQUIPOSDbContext : DbContext
    {
        public ADMINEQUIPOSDbContext()
        {

        }

        public ADMINEQUIPOSDbContext(DbContextOptions<ADMINEQUIPOSDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Region> Regiones { get; set; } = null!;
        public virtual DbSet<Comuna> Comunas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("REGION");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Nombre)
                   .IsUnicode(false).HasMaxLength(200)
                   .HasColumnName("NOMBRE").IsRequired();

            });
            modelBuilder.Entity<Comuna>(entity =>
            {
                entity.ToTable("COMUNA");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ID_REGION).IsRequired();
                entity.Property(e => e.Nombre)
                   .IsUnicode(false).HasMaxLength(200)
                   .HasColumnName("NOMBRE").IsRequired();

                entity.HasOne(e => e.Region).WithMany()
                .HasForeignKey(e => e.ID_REGION).HasConstraintName("ID_REGION_FK")
                .OnDelete(DeleteBehavior.Cascade);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
