using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CA_Yemektarifi_ödev.Models;

public partial class YemekSitesiContext : DbContext
{
    public YemekSitesiContext()
    {
    }

    public YemekSitesiContext(DbContextOptions<YemekSitesiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fotoğraf> Fotoğrafs { get; set; }

    public virtual DbSet<Kullanıcılar> Kullanıcılars { get; set; }

    public virtual DbSet<YemekTarifi> YemekTarifis { get; set; }

    public virtual DbSet<Yorumlar> Yorumlars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=FEYZALAPTOP\\SQLEXPRESS01;database=yemek sitesi;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fotoğraf>(entity =>
        {
            entity.ToTable("fotoğraf");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Açıklama)
                .HasMaxLength(50)
                .HasColumnName("açıklama");
            entity.Property(e => e.FotoUrl)
                .HasMaxLength(50)
                .HasColumnName("fotoURL");
        });

        modelBuilder.Entity<Kullanıcılar>(entity =>
        {
            entity.ToTable("kullanıcılar");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Adı)
                .HasMaxLength(50)
                .HasColumnName("adı");
            entity.Property(e => e.Soyad)
                .HasMaxLength(50)
                .HasColumnName("soyad");
            entity.Property(e => e.Şehirler)
                .HasMaxLength(50)
                .HasColumnName("şehirler");
        });

        modelBuilder.Entity<YemekTarifi>(entity =>
        {
            entity.ToTable("Yemek Tarifi");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FotoId).HasColumnName("fotoID");
            entity.Property(e => e.Tarif).HasMaxLength(500);
            entity.Property(e => e.YemekAdı).HasMaxLength(50);
            entity.Property(e => e.YorumId).HasColumnName("yorumID");
            entity.Property(e => e.YükleyenKullanıcıId).HasColumnName("YükleyenKullanıcıID");

            entity.HasOne(d => d.Foto).WithMany(p => p.YemekTarifis)
                .HasForeignKey(d => d.FotoId)
                .HasConstraintName("FK_Yemek Tarifi_fotoğraf");

            entity.HasOne(d => d.Yorum).WithMany(p => p.YemekTarifis)
                .HasForeignKey(d => d.YorumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Yemek Tarifi_yorumlar");

            entity.HasOne(d => d.YükleyenKullanıcı).WithMany(p => p.YemekTarifis)
                .HasForeignKey(d => d.YükleyenKullanıcıId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Yemek Tarifi_kullanıcılar1");
        });

        modelBuilder.Entity<Yorumlar>(entity =>
        {
            entity.ToTable("yorumlar");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.KullanıcıId).HasColumnName("KullanıcıID");
            entity.Property(e => e.Metin)
                .HasMaxLength(50)
                .HasColumnName("metin");
            entity.Property(e => e.YorumTarihi).HasColumnType("date");

            entity.HasOne(d => d.Kullanıcı).WithMany(p => p.Yorumlars)
                .HasForeignKey(d => d.KullanıcıId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_yorumlar_kullanıcılar");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
