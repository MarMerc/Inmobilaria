using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RealEstateFinal_Api.Models
{
    public partial class inmobilaryContext : DbContext
    {
        public inmobilaryContext()
        {
        }

        public inmobilaryContext(DbContextOptions<inmobilaryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Imagen> Imagens { get; set; } = null!;
        public virtual DbSet<Inmueble> Inmuebles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MARIANAMERC\\SQLEXPRESS; DataBase=inmobilary;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Imagen>(entity =>
            {
                entity.HasKey(e => e.IdImagen)
                    .HasName("PK__IMAGEN__B42D8F2AC0E06ADD");

                entity.ToTable("IMAGEN");

                entity.Property(e => e.UbicacionImg)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdInmuebleNavigation)
                    .WithMany(p => p.Imagens)
                    .HasForeignKey(d => d.IdInmueble)
                    .HasConstraintName("FK__IMAGEN__IdInmueb__267ABA7A");
            });

            modelBuilder.Entity<Inmueble>(entity =>
            {
                entity.HasKey(e => e.IdInmueble)
                    .HasName("PK__INMUEBLE__6B8E7D3E3E3C0CA4");

                entity.ToTable("INMUEBLE");

                entity.Property(e => e.Descripción)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.LatUbicación)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LongUbicación)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TipoInmueble)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoOperación)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
