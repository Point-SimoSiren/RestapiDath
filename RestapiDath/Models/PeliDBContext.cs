using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestapiDath.Models
{
    public partial class PeliDBContext : DbContext
    {
        public PeliDBContext()
        {
        }

        public PeliDBContext(DbContextOptions<PeliDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Genret> Genrets { get; set; } = null!;
        public virtual DbSet<Pelit> Pelits { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-4BCAT9M\\SQLEXPRESS01;Database=PeliDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genret>(entity =>
            {
                entity.HasKey(e => e.GenreId);

                entity.ToTable("Genret");

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.Kuvaus).HasMaxLength(50);

                entity.Property(e => e.Nimi).HasMaxLength(50);
            });

            modelBuilder.Entity<Pelit>(entity =>
            {
                entity.HasKey(e => e.PeliId);

                entity.ToTable("Pelit");

                entity.Property(e => e.PeliId).HasColumnName("PeliID");

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.Nimi).HasMaxLength(50);

                entity.Property(e => e.Tekijä).HasMaxLength(50);

               // Tästä poistettu roskaa
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
