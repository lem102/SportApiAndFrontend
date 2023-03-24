using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SportsApi.Models;

public partial class TappittechnicaltestContext : DbContext
{
    public TappittechnicaltestContext()
    {
    }

    public TappittechnicaltestContext(DbContextOptions<TappittechnicaltestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Sport> Sports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=tappittechnicaltest;Username=lem;Password=sonics101");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Personid).HasName("pk_people");

            entity.ToTable("people", "tappittechnicaltest");

            entity.Property(e => e.Personid).HasColumnName("personid");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.IsAuthorised).HasColumnName("isauthorised");
            entity.Property(e => e.IsEnabled).HasColumnName("isenabled");
            entity.Property(e => e.IsValid).HasColumnName("isvalid");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("lastname");

            entity.HasMany(d => d.Sports).WithMany(p => p.People)
                .UsingEntity<Dictionary<string, object>>(
                    "Favouritesport",
                    r => r.HasOne<Sport>().WithMany()
                        .HasForeignKey("Sportid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_favouritesports_sports"),
                    l => l.HasOne<Person>().WithMany()
                        .HasForeignKey("Personid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_favouritesports_people"),
                    j =>
                    {
                        j.HasKey("Personid", "Sportid").HasName("pk_favouritesports");
                        j.ToTable("favouritesports", "tappittechnicaltest");
                        j.IndexerProperty<int>("Personid").HasColumnName("personid");
                        j.IndexerProperty<int>("Sportid").HasColumnName("sportid");
                    });
        });

        modelBuilder.Entity<Sport>(entity =>
        {
            entity.HasKey(e => e.SportId).HasName("pk_sports");

            entity.ToTable("sports", "tappittechnicaltest");

            entity.Property(e => e.SportId).HasColumnName("sportid");
            entity.Property(e => e.IsEnabled).HasColumnName("isenabled");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
