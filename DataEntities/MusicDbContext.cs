﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DotNetCoreWebMySQL.DataEntities
{
  public partial class MusicDbContext : DbContext
  {
    public MusicDbContext()
    {
    }

    public MusicDbContext(DbContextOptions<MusicDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Album { get; set; }
    public virtual DbSet<Artist> Artist { get; set; }
    public virtual DbSet<Artistbasicinfo> Artistbasicinfo { get; set; }
    public virtual DbSet<Cart> Cart { get; set; }
    public virtual DbSet<Cartdetail> Cartdetail { get; set; }
    public virtual DbSet<Genre> Genre { get; set; }
    public virtual DbSet<Inventory> Inventory { get; set; }
    public virtual DbSet<Order> Order { get; set; }
    public virtual DbSet<Orderdetail> Orderdetail { get; set; }
    public virtual DbSet<Track> Track { get; set; }

    //         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //         {
    //             if (!optionsBuilder.IsConfigured)
    //             {
    // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
    //                 optionsBuilder.UseMySql("server=localhost;database=GS_DB;user=root;password=Password@1;treattinyasboolean=true", x => x.ServerVersion("8.0.19-mysql"));
    //             }
    //         }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Album>(entity =>
      {
        entity.ToTable("album");

        entity.HasIndex(e => e.ArtistId)
                  .HasName("FK_Album_ToArtist");

        entity.HasIndex(e => e.GenreId)
                  .HasName("FK_Album_ToGenre_idx");

        entity.Property(e => e.Id)
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.AlbumName)
                  .IsRequired()
                  .HasColumnType("varchar(200)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.AlbumUrl)
                  .HasColumnType("varchar(500)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.ArtistId)
                  .IsRequired()
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.CreatedBy)
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.GenreId)
                  .IsRequired()
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.Label)
                  .HasColumnType("varchar(200)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.LargeThumbnail)
                  .HasColumnType("varchar(100)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.MediumThumbnail)
                  .HasColumnType("varchar(100)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.ModifiedBy)
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.SmallThumbnail)
                  .HasColumnType("varchar(100)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.ThumbnailTag)
                  .HasColumnType("varchar(50)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.HasOne(d => d.Artist)
                  .WithMany(p => p.Album)
                  .HasForeignKey(d => d.ArtistId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Album_ToArtist");

        entity.HasOne(d => d.Genre)
                  .WithMany(p => p.Album)
                  .HasForeignKey(d => d.GenreId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Album_ToGenre");
      });

      modelBuilder.Entity<Artist>(entity =>
      {
        entity.ToTable("artist");

        entity.Property(e => e.Id)
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.ArtistName)
                  .IsRequired()
                  .HasColumnType("varchar(100)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.Biography)
                  .HasColumnType("longtext")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.CreatedBy)
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.LargeThumbnail)
                  .HasColumnType("varchar(100)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.ModifiedBy)
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.SmallThumbnail)
                  .HasColumnType("varchar(100)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.ThumbnailTag)
                  .HasColumnType("varchar(50)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.YearActive)
                  .HasColumnType("varchar(50)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");
      });

      modelBuilder.Entity<Artistbasicinfo>(entity =>
      {
        entity.HasKey(e => e.ArtistId)
                  .HasName("PRIMARY");

        entity.ToTable("artistbasicinfo");

        entity.Property(e => e.ArtistId)
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.AlsoKnownAs)
                  .HasColumnType("varchar(500)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.Born)
                  .HasColumnType("varchar(100)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.CreatedBy)
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.Died)
                  .HasColumnType("varchar(100)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.ModifiedBy)
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.HasOne(d => d.Artist)
                  .WithOne(p => p.Artistbasicinfo)
                  .HasForeignKey<Artistbasicinfo>(d => d.ArtistId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_ArtistBasicInfo_ToArtist");
      });

      modelBuilder.Entity<Cart>(entity =>
      {
        entity.ToTable("cart");

        entity.Property(e => e.Id)
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");
      });

      modelBuilder.Entity<Cartdetail>(entity =>
      {
        entity.ToTable("cartdetail");

        entity.HasIndex(e => e.CartId)
                  .HasName("FK_CartDetail_ToCart");

        entity.Property(e => e.Id)
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.CartId)
                  .IsRequired()
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.InventoryId)
                  .IsRequired()
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.HasOne(d => d.Cart)
                  .WithMany(p => p.Cartdetail)
                  .HasForeignKey(d => d.CartId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_CartDetail_ToCart");
      });

      modelBuilder.Entity<Genre>(entity =>
      {
        entity.ToTable("genre");

        entity.Property(e => e.Id)
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.Description)
                  .HasColumnType("longtext")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.GenreName)
                  .IsRequired()
                  .HasColumnType("varchar(50)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");
      });

      modelBuilder.Entity<Inventory>(entity =>
      {
        entity.ToTable("inventory");

        entity.HasIndex(e => e.AlbumId)
                  .HasName("UK_Inventory")
                  .IsUnique();

        entity.Property(e => e.Id)
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.AlbumId)
                  .IsRequired()
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.CreatedBy)
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.ModifiedBy)
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.HasOne(d => d.Album)
                  .WithOne(p => p.Inventory)
                  .HasForeignKey<Inventory>(d => d.AlbumId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Inventory_ToAlbum");
      });

      modelBuilder.Entity<Order>(entity =>
      {
        entity.ToTable("order");

        entity.Property(e => e.Id)
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.AddressLine1)
                  .HasColumnType("varchar(100)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.AddressLine2)
                  .HasColumnType("varchar(50)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.City)
                  .HasColumnType("varchar(50)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.Country)
                  .HasColumnType("varchar(100)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.Email)
                  .HasColumnType("varchar(100)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.FirstName)
                  .HasColumnType("varchar(50)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.LastName)
                  .HasColumnType("varchar(50)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.Phone)
                  .HasColumnType("varchar(20)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.PostalCode)
                  .HasColumnType("varchar(12)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.StateProvince)
                  .HasColumnType("varchar(50)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.UserName)
                  .HasColumnType("varchar(100)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");
      });

      modelBuilder.Entity<Orderdetail>(entity =>
      {
        entity.ToTable("orderdetail");

        entity.HasIndex(e => e.InventoryId)
                  .HasName("UK_ToInventory")
                  .IsUnique();

        entity.HasIndex(e => e.OrderId)
                  .HasName("FK_OrderDetail_ToOrder");

        entity.Property(e => e.Id)
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.InventoryId)
                  .IsRequired()
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.OrderId)
                  .IsRequired()
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.HasOne(d => d.Inventory)
                  .WithOne(p => p.Orderdetail)
                  .HasForeignKey<Orderdetail>(d => d.InventoryId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_OrderDetail_ToInventory");

        entity.HasOne(d => d.Order)
                  .WithMany(p => p.Orderdetail)
                  .HasForeignKey(d => d.OrderId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_OrderDetail_ToOrder");
      });

      modelBuilder.Entity<Track>(entity =>
      {
        entity.ToTable("track");

        entity.HasIndex(e => e.AlbumId)
                  .HasName("FK_Track_ToAlbum");

        entity.Property(e => e.Id)
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.AlbumId)
                  .IsRequired()
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.Composer)
                  .HasColumnType("longtext")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.CreatedBy)
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.Duration)
                  .HasColumnType("varchar(20)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.Featuring)
                  .HasColumnType("longtext")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.ModifiedBy)
                  .HasColumnType("varchar(64)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.Performer)
                  .HasColumnType("longtext")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.Property(e => e.TrackName)
                  .IsRequired()
                  .HasColumnType("varchar(100)")
                  .HasCharSet("utf8mb4")
                  .HasCollation("utf8mb4_0900_ai_ci");

        entity.HasOne(d => d.Album)
                  .WithMany(p => p.Track)
                  .HasForeignKey(d => d.AlbumId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Track_ToAlbum");
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
