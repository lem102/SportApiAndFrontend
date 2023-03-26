using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SportsApi.Database;

public partial class SportContext : DbContext
{
    public SportContext()
    {
    }

    public SportContext(DbContextOptions<SportContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Sport> Sports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("pk_people");

            entity.ToTable("people", "tappittechnicaltest");

            entity.Property(e => e.PersonId).HasColumnName("personid");
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
