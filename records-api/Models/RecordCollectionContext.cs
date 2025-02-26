using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace records_api.Models;

public partial class RecordCollectionContext : DbContext
{
    public RecordCollectionContext()
    {
    }

    public RecordCollectionContext(DbContextOptions<RecordCollectionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonArtist> PersonArtists { get; set; }

    public virtual DbSet<Record> Records { get; set; }

    public virtual DbSet<RecordLabel> RecordLabels { get; set; }

    public virtual DbSet<Song> Songs { get; set; }

    public virtual DbSet<SongWriter> SongWriters { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    public virtual DbSet<TrackProducer> TrackProducers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost:5432;Database=record-collection;Username=postgres;Password=collection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.ArtistId).HasName("artist_pkey");

            entity.ToTable("artist");

            entity.Property(e => e.ArtistId)
                .ValueGeneratedNever()
                .HasColumnName("artist_id");
            entity.Property(e => e.ArtistName)
                .HasMaxLength(255)
                .HasColumnName("artist_name");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("person_pkey");

            entity.ToTable("person");

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnName("person_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
        });

        modelBuilder.Entity<PersonArtist>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("person_artist");

            entity.Property(e => e.ArtistId).HasColumnName("artist_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");

            entity.HasOne(d => d.Artist).WithMany()
                .HasForeignKey(d => d.ArtistId)
                .HasConstraintName("bridge_artist_id");

            entity.HasOne(d => d.Person).WithMany()
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("bridge_person_id");
        });

        modelBuilder.Entity<Record>(entity =>
        {
            entity.HasKey(e => e.RecordId).HasName("record_pkey");

            entity.ToTable("record");

            entity.HasIndex(e => e.ArtistId, "fki_record_artist_id");

            entity.HasIndex(e => e.RecordLabelId, "fki_record_record_label");

            entity.Property(e => e.RecordId)
                .ValueGeneratedNever()
                .HasColumnName("record_id");
            entity.Property(e => e.AlbumArt)
                .HasMaxLength(1000)
                .HasColumnName("album_art");
            entity.Property(e => e.ArtistId).HasColumnName("artist_id");
            entity.Property(e => e.RecordLabelId).HasColumnName("record_label_id");
            entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");

            entity.HasOne(d => d.Artist).WithMany(p => p.Records)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("record_artist_id");

            entity.HasOne(d => d.RecordLabel).WithMany(p => p.Records)
                .HasForeignKey(d => d.RecordLabelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("record_record_label");
        });

        modelBuilder.Entity<RecordLabel>(entity =>
        {
            entity.HasKey(e => e.RecordLabelId).HasName("record_label_pkey");

            entity.ToTable("record_label");

            entity.Property(e => e.RecordLabelId)
                .ValueGeneratedNever()
                .HasColumnName("record_label_id");
            entity.Property(e => e.RecordLabelName)
                .HasMaxLength(100)
                .HasColumnName("record_label_name");
        });

        modelBuilder.Entity<Song>(entity =>
        {
            entity.HasKey(e => e.SongId).HasName("song_pkey");

            entity.ToTable("song");

            entity.Property(e => e.SongId)
                .ValueGeneratedNever()
                .HasColumnName("song_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        modelBuilder.Entity<SongWriter>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("song_writer");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.SongId).HasColumnName("song_id");

            entity.HasOne(d => d.Person).WithMany()
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("song_person_id");

            entity.HasOne(d => d.Song).WithMany()
                .HasForeignKey(d => d.SongId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("song_song_id");
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.HasKey(e => e.TrackId).HasName("track_pkey");

            entity.ToTable("track");

            entity.HasIndex(e => e.SongId, "fki_track_song_id");

            entity.Property(e => e.TrackId)
                .ValueGeneratedNever()
                .HasColumnName("track_id");
            entity.Property(e => e.RecordId).HasColumnName("record_id");
            entity.Property(e => e.SongId).HasColumnName("song_id");
            entity.Property(e => e.SongNameOverride)
                .HasMaxLength(255)
                .HasColumnName("song_name_override");
            entity.Property(e => e.TrackLength).HasColumnName("track_length");
            entity.Property(e => e.TrackNumber).HasColumnName("track_number");

            entity.HasOne(d => d.Record).WithMany(p => p.Tracks)
                .HasForeignKey(d => d.RecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("track_record_id");

            entity.HasOne(d => d.Song).WithMany(p => p.Tracks)
                .HasForeignKey(d => d.SongId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("track_song_id");
        });

        modelBuilder.Entity<TrackProducer>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("track_producer");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.TrackId).HasColumnName("track_id");

            entity.HasOne(d => d.Track).WithMany()
                .HasForeignKey(d => d.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("track_track_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
