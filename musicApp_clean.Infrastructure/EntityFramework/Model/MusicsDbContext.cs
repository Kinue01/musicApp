using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace musicApp_clean.Infrastructure.EntityFramework.Model;

public partial class MusicsDbContext : DbContext
{
    public MusicsDbContext()
    {
    }

    public MusicsDbContext(DbContextOptions<MusicsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAuthor> TbAuthors { get; set; }

    public virtual DbSet<TbGenre> TbGenres { get; set; }

    public virtual DbSet<TbMusic> TbMusics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=192.168.0.107;Port=5432;Database=musics_db;Username=postgres;Password=1");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAuthor>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("tb_author_pkey");

            entity.ToTable("tb_author");

            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(100)
                .HasColumnName("author_name");
        });

        modelBuilder.Entity<TbGenre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("tb_gerne_pkey");

            entity.ToTable("tb_genre");

            entity.Property(e => e.GenreId)
                .HasDefaultValueSql("nextval('tb_gerne_gerne_id_seq'::regclass)")
                .HasColumnName("genre_id");
            entity.Property(e => e.GenreName)
                .HasMaxLength(30)
                .HasColumnName("genre_name");
        });

        modelBuilder.Entity<TbMusic>(entity =>
        {
            entity.HasKey(e => e.MusicId).HasName("tb_music_pkey");

            entity.ToTable("tb_music");

            entity.Property(e => e.MusicId).HasColumnName("music_id");
            entity.Property(e => e.MusicAuthorId).HasColumnName("music_author_id");
            entity.Property(e => e.MusicGenreId).HasColumnName("music_genre_id");
            entity.Property(e => e.MusicName)
                .HasMaxLength(100)
                .HasColumnName("music_name");
            entity.Property(e => e.MusicUrl)
                .HasMaxLength(50)
                .HasColumnName("music_url");

            entity.HasOne(d => d.MusicAuthor).WithMany(p => p.TbMusics)
                .HasForeignKey(d => d.MusicAuthorId)
                .HasConstraintName("tb_music_music_author_id_fkey");

            entity.HasOne(d => d.MusicGenre).WithMany(p => p.TbMusics)
                .HasForeignKey(d => d.MusicGenreId)
                .HasConstraintName("tb_music_music_genre_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
