using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShelterDAL.Models;

public partial class AnShelterIdenContext : DbContext
{
    public AnShelterIdenContext()
    {
    }

    public AnShelterIdenContext(DbContextOptions<AnShelterIdenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<ComentGlob> ComentGlobs { get; set; }

    public virtual DbSet<ComentGood> ComentGoods { get; set; }

    public virtual DbSet<ComentKindAnimal> ComentKindAnimals { get; set; }

    public virtual DbSet<Good> Goods { get; set; }

    public virtual DbSet<KindOfAnimal> KindOfAnimals { get; set; }

    public virtual DbSet<KindOfGood> KindOfGoods { get; set; }
    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Volonter> Volonters { get; set; }

    public virtual DbSet<VolontersAnimal> VolontersAnimals { get; set; }

    public virtual DbSet<VolontersGood> VolontersGoods { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Name=BookStoresDB");
        }
    }
protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.Idanimal).HasName("PK__Animals__5D8F073D76DB50EF");

            entity.Property(e => e.Idanimal).HasColumnName("IDAnimal");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.KindNavigation).WithMany(p => p.Animals)
                .HasForeignKey(d => d.Kind)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Animals__Kind__2A4B4B5E");
        });

        modelBuilder.Entity<ComentGlob>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ComentGl__3214EC270345D92A");

            entity.ToTable("ComentGlob");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Idvolonter).HasColumnName("IDVolonter");
            entity.Property(e => e.Text)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.IdvolonterNavigation).WithMany(p => p.ComentGlobs)
                .HasForeignKey(d => d.Idvolonter)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ComentGlo__IDVol__403A8C7D");
        });

        modelBuilder.Entity<ComentGood>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ComentGo__3214EC273E438E7E");

            entity.ToTable("ComentGood");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Idgood).HasColumnName("IDGood");
            entity.Property(e => e.Idvolonter).HasColumnName("IDVolonter");
            entity.Property(e => e.Text)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.IdgoodNavigation).WithMany(p => p.ComentGoods)
                .HasForeignKey(d => d.Idgood)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ComentGoo__IDGoo__398D8EEE");

            entity.HasOne(d => d.IdvolonterNavigation).WithMany(p => p.ComentGoods)
                .HasForeignKey(d => d.Idvolonter)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ComentGoo__IDVol__38996AB5");
        });

        modelBuilder.Entity<ComentKindAnimal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ComentKi__3214EC27C48BBC0C");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.IdkindAnimals).HasColumnName("IDKindAnimals");
            entity.Property(e => e.Idvolonter).HasColumnName("IDVolonter");
            entity.Property(e => e.Text)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.IdkindAnimalsNavigation).WithMany(p => p.ComentKindAnimals)
                .HasForeignKey(d => d.IdkindAnimals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ComentKin__IDKin__3D5E1FD2");

            entity.HasOne(d => d.IdvolonterNavigation).WithMany(p => p.ComentKindAnimals)
                .HasForeignKey(d => d.Idvolonter)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ComentKin__IDVol__3C69FB99");
        });

        modelBuilder.Entity<Good>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Goods__3214EC27E5FDF0B2");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.NameKindNavigation).WithMany(p => p.Goods)
                .HasForeignKey(d => d.NameKind)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Goods__NameKind__2D27B809");
        });

        modelBuilder.Entity<KindOfAnimal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KindOfAn__3214EC275922B149");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NameKind)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<KindOfGood>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KindOfGo__3214EC27BA14D8B1");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NameKind)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Volonter>(entity =>
        {
            entity.HasKey(e => e.Idvolonters).HasName("PK__Volonter__D3BC0C3D529BEE2B");

            entity.Property(e => e.Idvolonters).HasColumnName("IDVolonters");
            entity.Property(e => e.EMail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("E-Mail");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNamber)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VolontersAnimal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Volonter__3214EC274D2062F6");

            entity.ToTable("Volonters_Animals");

            entity.HasIndex(e => e.Idanimals, "UQ__Volonter__1CF18EFE0ECBD9ED").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Idanimals).HasColumnName("IDAnimals");
            entity.Property(e => e.Idvolonter).HasColumnName("IDVolonter");

            entity.HasOne(d => d.IdanimalsNavigation).WithOne(p => p.VolontersAnimal)
                .HasForeignKey<VolontersAnimal>(d => d.Idanimals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Volonters__IDAni__31EC6D26");

            entity.HasOne(d => d.IdvolonterNavigation).WithMany(p => p.VolontersAnimals)
                .HasForeignKey(d => d.Idvolonter)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Volonters__IDVol__30F848ED");
        });

        modelBuilder.Entity<VolontersGood>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Volonter__3214EC27F53949D1");

            entity.ToTable("Volonters_Goods");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Idgood).HasColumnName("IDGood");
            entity.Property(e => e.Idvolonter).HasColumnName("IDVolonter");

            entity.HasOne(d => d.IdgoodNavigation).WithMany(p => p.VolontersGoods)
                .HasForeignKey(d => d.Idgood)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Volonters__IDGoo__35BCFE0A");

            entity.HasOne(d => d.IdvolonterNavigation).WithMany(p => p.VolontersGoods)
                .HasForeignKey(d => d.Idvolonter)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Volonters__IDVol__34C8D9D1");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
