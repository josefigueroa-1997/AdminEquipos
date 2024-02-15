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
        public virtual DbSet<Oficina> Oficinas { get; set; } = null!;
        public virtual DbSet<Dispositivo> Dispositivos { get; set; } = null!;
        public virtual DbSet<Aplicacion> Aplicaciones { get; set; } = null!;
        public virtual DbSet<Dispositivo_Aplicacion> Dispositivo_Aplicacions { get; set; } = null!;
        public virtual DbSet<MONITOREO_DISP_APP> MONITOREO_DISP_APPs { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("REGION");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Nombre)
                   .IsUnicode(false).HasMaxLength(200)
                   .HasColumnName("NOMBRE").IsRequired();
                entity.HasIndex(e => e.Nombre).IsUnique();
            });
            modelBuilder.Entity<Comuna>(entity =>
            {
                entity.ToTable("COMUNA");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ID_REGION).IsRequired();
                entity.Property(e => e.Nombre)
                   .IsUnicode(false).HasMaxLength(200)
                   .HasColumnName("NOMBRE").IsRequired();
                entity.HasIndex(e => e.Nombre).IsUnique();
                entity.HasOne(e => e.Region).WithMany()
                .HasForeignKey(e => e.ID_REGION).HasConstraintName("ID_REGION_FK")
                .OnDelete(DeleteBehavior.Cascade);
                
            });
            modelBuilder.Entity<Oficina>(entity =>
            {
                entity.ToTable("OFICINA");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ID_COMUNA).IsRequired();
                entity.Property(e => e.Nombre).IsUnicode(false).HasMaxLength(200)
                   .HasColumnName("NOMBRE").IsRequired();
                entity.HasIndex(e => e.Nombre).IsUnique();
                entity.HasOne(e => e.Comuna).WithMany()
                .HasForeignKey(e => e.ID_COMUNA).HasConstraintName("ID_COMUNA_FK")
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Dispositivo>(entity =>
            {
                entity.ToTable("DISPOSITIVO");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ID_OFICINA).IsRequired();
                entity.HasOne(e => e.Oficina).WithMany().
                HasForeignKey(e => e.ID_OFICINA).HasConstraintName("ID_OFICINA_FK").OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.Tipodispositivo).IsUnicode(false)
                .HasMaxLength(200).HasColumnName("TIPODISPOSITIVO").IsRequired();

                entity.HasCheckConstraint("TIPODISPOSITIVO_CHECK", "[TIPODISPOSITIVO] IN ('servidor','impresora','pc','celular')");

                entity.Property(e => e.cpu).IsUnicode(false)
                .HasMaxLength(100).HasColumnName("CPU").IsRequired();

                entity.Property(e => e.disco_duro).IsUnicode(false)
                .HasMaxLength(100).HasColumnName("DISCO_DURO").IsRequired();

                entity.Property(e => e.ram).IsUnicode(false)
                .HasMaxLength(200).HasColumnName("RAM").IsRequired();

            });
            modelBuilder.Entity<Aplicacion>(entity => {

                entity.ToTable("APLICACION");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Nombre).IsUnicode(false).
                HasMaxLength(200).HasColumnName("NOMBRE").IsRequired();
                entity.HasIndex(e => e.Nombre).IsUnique();
            
            
            });
            modelBuilder.Entity<Dispositivo_Aplicacion>(entity =>
            {
                entity.ToTable("DISPOISITIVO_APLICACION");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ID_Dispositivo).IsRequired();
                entity.HasOne(e => e.Dispositivo).WithMany(e => e.Dispositivo_Aplicacions)
                .HasForeignKey(e => e.ID_Dispositivo).HasConstraintName("ID_DISPOSITVO_APLICACION_FK").OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.ID_Aplicacion).IsRequired();
                entity.HasOne(e => e.Aplicacion).WithMany(e => e.Dispositivo_Aplicacions)
                .HasForeignKey(e => e.ID_Aplicacion).HasConstraintName("ID_DISPOSITVO_APLICACIONES_FK").OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.Fecha_instalacion).IsRequired().IsUnicode(false);

            });
            modelBuilder.Entity<MONITOREO_DISP_APP>(entity =>
            {
                entity.ToTable("MONITOREO_DISP_APP");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ID_DISPOSITIVO_APP).IsRequired();

                entity.HasOne(e => e.Dispositivo_Aplicacion).WithMany()
                .HasForeignKey(e => e.ID_DISPOSITIVO_APP).HasConstraintName("ID_DISPOSITIVO_FK").OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.Estado_CPU).IsUnicode(false)
                .HasMaxLength(100).HasColumnName("ESTADO_CPU").IsRequired();

                entity.Property(e => e.Estado_RAM).IsUnicode(false)
                .HasMaxLength(100).HasColumnName("ESTADO_RAM").IsRequired();

                entity.Property(e => e.Estado_DISCODURO).IsUnicode(false)
                .HasMaxLength(100).HasColumnName("ESTADO_DISCODURO").IsRequired();

                entity.Property(e => e.Estado_APLICACION).IsUnicode(false)
                .HasMaxLength(100).HasColumnName("ESTADO_APLICACION").IsRequired();



            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
