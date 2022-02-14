using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NTWetterWebApi.Data.Models
{
    public partial class NTWetterContext : DbContext
    {
        public NTWetterContext()
        {
        }

        public NTWetterContext(DbContextOptions<NTWetterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Wetter> Wetters { get; set; }
        public virtual DbSet<WetterMappingWetterType> WetterMappingWetterTypes { get; set; }
        public virtual DbSet<WetterType> WetterTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=NTWetter;User Id=sa; Password=Password1;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wetter>(entity =>
            {
                entity.ToTable("Wetter");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Call).HasColumnName("CAll");

                entity.Property(e => e.Country).IsRequired();

                entity.Property(e => e.FindName).IsRequired();

                entity.Property(e => e.Lat).HasColumnType("decimal(8, 6)");

                entity.Property(e => e.Lon).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Speed).HasColumnType("decimal(10, 1)");

                entity.Property(e => e.Temp).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TempMax).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TempMin).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<WetterMappingWetterType>(entity =>
            {
                entity.ToTable("WetterMappingWetterType");
            });

            modelBuilder.Entity<WetterType>(entity =>
            {
                entity.ToTable("WetterType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Icon).IsRequired();

                entity.Property(e => e.Main).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
