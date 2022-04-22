using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestApi.Models.DB
{
    public partial class testApiContext : DbContext
    {
        public testApiContext()
        {
        }

        public testApiContext(DbContextOptions<testApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Amortizacion> Amortizacions { get; set; } = null!;
        public virtual DbSet<Credito> Creditos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-2KQVE8N; Database=testApi; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amortizacion>(entity =>
            {
                entity.ToTable("Amortizacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FkCreditoId).HasColumnName("fk_credito_id");

                entity.Property(e => e.MontoCapital)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("montoCapital");

                entity.Property(e => e.MontoInteres).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.NumeroDeCuota).HasColumnName("numeroDeCuota");

                entity.Property(e => e.SaldoInsolutoCredito)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("saldoInsolutoCredito");

                entity.HasOne(d => d.FkCredito)
                    .WithMany(p => p.Amortizacions)
                    .HasForeignKey(d => d.FkCreditoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Amortizac__fk_cr__2A4B4B5E");
            });

            modelBuilder.Entity<Credito>(entity =>
            {
                entity.ToTable("Credito");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MontoPrestamo)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("montoPrestamo");

                entity.Property(e => e.Plazo).HasColumnName("plazo");

                entity.Property(e => e.Tasa)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("tasa");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
