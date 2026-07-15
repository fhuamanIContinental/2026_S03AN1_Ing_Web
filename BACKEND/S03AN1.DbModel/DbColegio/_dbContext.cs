using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace S03AN1.DbModel.DbColegio;

public partial class _dbContext : DbContext
{
    public _dbContext()
    {
    }

    public _dbContext(DbContextOptions<_dbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DboCliente> DboCliente { get; set; }

    public virtual DbSet<DboClienteSuscripcion> DboClienteSuscripcion { get; set; }

    public virtual DbSet<DboEstadoCliente> DboEstadoCliente { get; set; }

    public virtual DbSet<DboEstadoSuscripcion> DboEstadoSuscripcion { get; set; }

    public virtual DbSet<DboPlan> DboPlan { get; set; }

    public virtual DbSet<DboUsuarioPlataforma> DboUsuarioPlataforma { get; set; }

    public virtual DbSet<Mascota> Mascota { get; set; }

    public virtual DbSet<Persona> Persona { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=2026_S03AN1;user=root;password=root123", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.45-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<DboCliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("utc_timestamp()");
            entity.Property(e => e.IdEstado).HasDefaultValueSql("'1'");
            entity.Property(e => e.Ruc).IsFixedLength();

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.DboCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_EstadoCliente");
        });

        modelBuilder.Entity<DboClienteSuscripcion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("utc_timestamp()");
            entity.Property(e => e.IdEstado).HasDefaultValueSql("'1'");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.DboClienteSuscripcion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClienteSuscripcion_Cliente");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.DboClienteSuscripcion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClienteSuscripcion_EstadoSuscripcion");

            entity.HasOne(d => d.IdPlanNavigation).WithMany(p => p.DboClienteSuscripcion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClienteSuscripcion_Plan");
        });

        modelBuilder.Entity<DboEstadoCliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<DboEstadoSuscripcion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<DboPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Estado).HasDefaultValueSql("b'1'");
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("utc_timestamp()");
        });

        modelBuilder.Entity<DboUsuarioPlataforma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Estado).HasDefaultValueSql("b'1'");
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("utc_timestamp()");
        });

        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("utc_timestamp()");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("utc_timestamp()");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
