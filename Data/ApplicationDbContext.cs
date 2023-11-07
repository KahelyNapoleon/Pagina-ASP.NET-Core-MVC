﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PeluqueriaAgendaServicio.web.Models;

namespace PeluqueriaAgendaServicio.web.Data;

public partial class ApplicationDbContext : DbContext //QUE SON LAS CLASES PARCIALES?
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; } //Que es DbSet?

    public virtual DbSet<EstadosTurno> EstadosTurnos { get; set; }

    public virtual DbSet<Localidad> Localidades { get; set; }

    public virtual DbSet<Provincia> Provincias { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<TiposServicio> TiposServicios { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\MSSQLSERVER01; Initial Catalog=AgendaServiciosPeluqueria;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__71ABD08721C7D466");

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Barrio)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CuitCuil)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Partido)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Localidad).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.LocalidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clientes_Localidades");

            entity.HasOne(d => d.Provincia).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.ProvinciaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clientes_Provincias");
        });

        modelBuilder.Entity<EstadosTurno>(entity =>
        {
            entity.HasKey(e => e.EstadoTurnoId).HasName("PK__EstadosT__10C65F061CD0D410");

            entity.ToTable("EstadosTurno");

            entity.HasIndex(e => e.Descripcion, "UQ__EstadosT__92C53B6C9103C035").IsUnique();

            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Localidad>(entity =>
        {
            entity.HasKey(e => e.LocalidadId).HasName("PK__Localida__6E2890A22ABCA085");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Provincia).WithMany(p => p.Localidades)
                .HasForeignKey(d => d.ProvinciaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Localidades_Provincias");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.ProvinciaId).HasName("PK__Provinci__F7CBC77706FE431B");

            entity.HasIndex(e => e.Descripcion, "UQ__Provinci__92C53B6C48ACB935").IsUnique();

            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.ServicioId).HasName("PK__Servicio__D5AEECC23AABFC83");

            entity.HasIndex(e => e.Descripcion, "UQ__Servicio__92C53B6CADD7D4CD").IsUnique();

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Observacion).HasColumnType("text");
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.TipoServicio).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.TipoServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Servicios_TiposServicios");
        });

        modelBuilder.Entity<TiposServicio>(entity =>
        {
            entity.HasKey(e => e.TipoServicioId).HasName("PK__TiposSer__BC9FF47D6412272D");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Turno>(entity =>
        {
            entity.HasKey(e => e.TurnoId).HasName("PK__Turnos__AD3E2E942A3ECE2B");

            entity.Property(e => e.FechaTurno).HasColumnType("date");
            entity.Property(e => e.Observacion).HasColumnType("text");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Turnos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_Turnos_Clientes");

            entity.HasOne(d => d.EstadoTurno).WithMany(p => p.Turnos)
                .HasForeignKey(d => d.EstadoTurnoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Turnos_EstadosTurno");

            entity.HasOne(d => d.Servicio).WithMany(p => p.Turnos)
                .HasForeignKey(d => d.ServicioId)
                .HasConstraintName("FK_Turnos_Servicios");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
