using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DigitalArt.Models;

public partial class DigitalartIiContext : DbContext
{
    public DigitalartIiContext()
    {
    }

    public DigitalartIiContext(DbContextOptions<DigitalartIiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Arte> Artes { get; set; }

    public virtual DbSet<Opinione> Opiniones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
/*
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-C282210\\SQLEXPRESS; database=digitalartII; integrated security=true; TrustServerCertificate=true;");
*/
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Arte>(entity =>
        {
            entity.HasKey(e => e.IdArte).HasName("PK__arte__750EB095318653CE");

            entity.ToTable("arte");

            entity.Property(e => e.IdArte).HasColumnName("idArte");
            entity.Property(e => e.DescripcionArte)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcionArte");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Img)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("img");
            entity.Property(e => e.LinkArte)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("linkArte");
            entity.Property(e => e.NombreArte)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombreArte");
        });

        modelBuilder.Entity<Opinione>(entity =>
        {
            entity.HasKey(e => e.IdOpinion).HasName("PK__opinione__83A5899B7CE1B984");

            entity.ToTable("opiniones");

            entity.Property(e => e.IdOpinion).HasColumnName("idOpinion");
            entity.Property(e => e.DescripcionOpinion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcionOpinion");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreOpinion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombreOpinion");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuarios).HasName("PK__usuarios__3940559A6EE09C55");

            entity.ToTable("usuarios");

            entity.Property(e => e.IdUsuarios).HasColumnName("idUsuarios");
            entity.Property(e => e.DireccionUsuarios)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccionUsuarios");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreUsuarios)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombreUsuarios");
            entity.Property(e => e.TelefonoUsuarios)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("telefonoUsuarios");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
