using System;
using System.Collections.Generic;
using DirectorDomain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DirectorDomain.Infrastructure.Data;

public partial class Parcial20240121200032Context : DbContext
{
    public Parcial20240121200032Context()
    {
    }

    public Parcial20240121200032Context(DbContextOptions<Parcial20240121200032Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Director> Director { get; set; }

    public virtual DbSet<Movie> Movie { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=WS2302434;Database=Parcial20240121200032;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Director>(entity =>
        {
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.Property(e => e.Genre).HasMaxLength(100);
            entity.Property(e => e.ReleaseYear).HasColumnType("datetime");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
