using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JOSE_FARIAS.Server.Models;

public partial class JoseFariasContext : DbContext
{
    public JoseFariasContext()
    {
    }

    public JoseFariasContext(DbContextOptions<JoseFariasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.Idtarea).HasName("PK__tarea__74E91987F2462A30");

            entity.ToTable("tarea");

            entity.Property(e => e.Idtarea).HasColumnName("idtarea");
            entity.Property(e => e.Completada)
                .HasDefaultValueSql("((0))")
                .HasColumnName("completada");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK__Usuario__080A9743C35C79A5");

            entity.ToTable("Usuario");

            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Clave)
                .HasMaxLength(300)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(200)
                .HasColumnName("correo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
