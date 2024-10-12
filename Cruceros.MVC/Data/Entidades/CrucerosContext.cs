using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cruceros.Data.Entidades;

public partial class CrucerosContext : DbContext
{
    public CrucerosContext()
    {
    }

    public CrucerosContext(DbContextOptions<CrucerosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cabina> Cabinas { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Fecha> Fechas { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Tipo> Tipos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cabina>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cabina__3214EC071D6E9AC3");

            entity.ToTable("Cabina", "Habitaciones");

            entity.HasIndex(e => e.CabinCod, "UQ_Cabina_CabinCod").IsUnique();

            entity.Property(e => e.CabinCod).HasMaxLength(50);

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Cabinas)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cabina_Tipo");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Factura__3214EC07E90585B1");

            entity.ToTable("Factura", "Reservas");

            entity.HasIndex(e => e.BillCod, "UQ_Factura_BillCod").IsUnique();

            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
        });

        modelBuilder.Entity<Fecha>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Fecha__3214EC073CF48849");

            entity.ToTable("Fecha", "Reservas");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reserva__3214EC07E76BC1FB");

            entity.ToTable("Reserva", "Reservas");

            entity.Property(e => e.CabinCod).HasMaxLength(50);
            entity.Property(e => e.Cod).HasMaxLength(50);
            entity.Property(e => e.User).HasMaxLength(100);

            entity.HasOne(d => d.BillCodNavigation).WithMany(p => p.Reservas)
                .HasPrincipalKey(p => p.BillCod)
                .HasForeignKey(d => d.BillCod)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reserva_Factura");

            entity.HasOne(d => d.CabinCodNavigation).WithMany(p => p.Reservas)
                .HasPrincipalKey(p => p.CabinCod)
                .HasForeignKey(d => d.CabinCod)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reserva_Cabina");

            entity.HasOne(d => d.DateCodNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.DateCod)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reserva_Fecha");
        });

        modelBuilder.Entity<Tipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tipo__3214EC0798B0805D");

            entity.ToTable("Tipo", "Habitaciones");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Identify)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC07B7D75DB8");

            entity.ToTable("Usuario", "Usuarios");

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
