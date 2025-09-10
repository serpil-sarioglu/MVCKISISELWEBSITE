using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCKISISELWEBSITE.DAL;

public partial class KisiselwebsiteContext : DbContext
{
    public KisiselwebsiteContext()
    {
    }

    public KisiselwebsiteContext(DbContextOptions<KisiselwebsiteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CalismaAlanlari> CalismaAlanlaris { get; set; }

    public virtual DbSet<GenelBilgi> GenelBilgis { get; set; }

    public virtual DbSet<Kadromuz> Kadromuzs { get; set; }

    public virtual DbSet<Kullanici> Kullanicis { get; set; }

    public virtual DbSet<Makaleler> Makalelers { get; set; }

    public virtual DbSet<Mesajlar> Mesajlars { get; set; }

    public virtual DbSet<Slider> Sliders { get; set; }

    public virtual DbSet<Videolar> Videolars { get; set; }

    public virtual DbSet<Yorumlar> Yorumlars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=LAPTOP-7A4VAITE;initial catalog=KISISELWEBSITE;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CalismaAlanlari>(entity =>
        {
            entity.ToTable("CalismaAlanlari");

            entity.Property(e => e.Baslik).HasMaxLength(50);
        });

        modelBuilder.Entity<GenelBilgi>(entity =>
        {
            entity.ToTable("GenelBilgi");

            entity.Property(e => e.Fax).HasMaxLength(50);
            entity.Property(e => e.Telefon).HasMaxLength(50);
        });

        modelBuilder.Entity<Kadromuz>(entity =>
        {
            entity.ToTable("Kadromuz");
        });

        modelBuilder.Entity<Kullanici>(entity =>
        {
            entity.ToTable("Kullanici");
        });

        modelBuilder.Entity<Makaleler>(entity =>
        {
            entity.ToTable("Makaleler");

            entity.Property(e => e.Baslik).HasMaxLength(50);
        });

        modelBuilder.Entity<Mesajlar>(entity =>
        {
            entity.ToTable("Mesajlar");
        });

        modelBuilder.Entity<Slider>(entity =>
        {
            entity.ToTable("Slider");
        });

        modelBuilder.Entity<Videolar>(entity =>
        {
            entity.ToTable("Videolar");
        });

        modelBuilder.Entity<Yorumlar>(entity =>
        {
            entity.ToTable("Yorumlar");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Tarih).HasColumnType("datetime");

            entity.HasOne(d => d.Makale).WithMany(p => p.Yorumlars)
                .HasForeignKey(d => d.MakaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Yorumlar_Makaleler");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_Yorumlar_Yorumlar");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
