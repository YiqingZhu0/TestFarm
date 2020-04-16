using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestFarm.Models
{
    public partial class VerticalFarmingContext : DbContext
    {
        public VerticalFarmingContext(DbContextOptions<VerticalFarmingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LstCropStatus> LstCropStatus { get; set; }
        public virtual DbSet<LstLocations> LstLocations { get; set; }
        public virtual DbSet<LstPlantSize> LstPlantSize { get; set; }
        public virtual DbSet<LstPlantType> LstPlantType { get; set; }
        public virtual DbSet<LstTowerType> LstTowerType { get; set; }
        public virtual DbSet<CropStatus> CropsStatus { get; set; }
        public virtual DbSet<Crop> Crops { get; set; }
        public virtual DbSet<Plant> Plants { get; set; }
        public virtual DbSet<Port> Ports { get; set; }
        public virtual DbSet<Tower> Towers { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-NMHTB71\\JCKServer;Database=VerticalFarming;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LstCropStatus>(entity =>
            {
                entity.ToTable("lstCropStatus");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.StatusAbbrev)
                    .IsRequired()
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<LstLocations>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK__lstLocat__E7FEA497A8AD8372");

                entity.ToTable("lstLocations");
            });

            modelBuilder.Entity<LstPlantSize>(entity =>
            {
                entity.ToTable("lstPlantSize");

                entity.Property(e => e.Abbrev).HasMaxLength(5);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<LstPlantType>(entity =>
            {
                entity.ToTable("lstPlantType");

                entity.Property(e => e.Abbrev).HasMaxLength(5);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<LstTowerType>(entity =>
            {
                entity.HasKey(e => e.TowerTypeId)
                    .HasName("PK__lstTower__4888EEE0BC4E01BF");

                entity.ToTable("lstTowerType");

                entity.Property(e => e.Image).HasMaxLength(2500);

                entity.Property(e => e.TowerDesc)
                    .IsRequired()
                    .HasMaxLength(3500);

                entity.Property(e => e.TowerName)
                    .IsRequired()
                    .HasMaxLength(1500);
            });

            modelBuilder.Entity<CropStatus>(entity =>
            {
                entity.HasKey(e => e.CropStatusId)
                    .HasName("PK__tblCropS__24FABA028868D436");

                entity.ToTable("tblCropStatus");

                entity.HasOne(d => d.Crop)
                    .WithMany(p => p.CropStatus)
                    .HasForeignKey(d => d.CropId)
                    .HasConstraintName("FK_tblCropStatus_tblCrops");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.CropStatus)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_tblCropStatus_lstCropStatus");
            });

            modelBuilder.Entity<Crop>(entity =>
            {
                entity.HasKey(e => e.CropId)
                    .HasName("PK__tblCrops__923561154055E0BE");

                entity.ToTable("tblCrops");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Plant)
                    .WithMany(p => p.Crop)
                    .HasForeignKey(d => d.PlantId)
                    .HasConstraintName("FK_tblCrops_tblPlant");

                entity.HasOne(d => d.Port)
                    .WithMany(p => p.Crop)
                    .HasForeignKey(d => d.PortId)
                    .HasConstraintName("FK_tblCrops_tblPorts");
            });

            modelBuilder.Entity<Plant>(entity =>
            {
                entity.HasKey(e => e.PlantId)
                    .HasName("PK__tblPlant__98FE395C39E3BFA2");

                entity.ToTable("tblPlant");

                entity.Property(e => e.Abbrev)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(2500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Plant)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("FK_tblPlant_lstPlantType");

                entity.HasOne(d => d.SizeNavigation)
                    .WithMany(p => p.Plant)
                    .HasForeignKey(d => d.Size)
                    .HasConstraintName("FK_tblPlant_lstPlantSize");
            });

            modelBuilder.Entity<Port>(entity =>
            {
                entity.HasKey(e => e.PortId)
                    .HasName("PK__tblPorts__D859BF8FEAD50597");

                entity.ToTable("tblPorts");

                entity.HasOne(d => d.Tower)
                    .WithMany(p => p.Port)
                    .HasForeignKey(d => d.TowerId)
                    .HasConstraintName("FK_tblPorts_tblTower");
            });

            modelBuilder.Entity<Tower>(entity =>
            {
                entity.HasKey(e => e.TowerId)
                    .HasName("PK__tblTower__848567BC58452599");

                entity.ToTable("tblTower");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(700);

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.Tower)
                    .HasForeignKey(d => d.Location)
                    .HasConstraintName("FK_tblTower_lstLocations");

                entity.HasOne(d => d.TowerTypeNavigation)
                    .WithMany(p => p.Tower)
                    .HasForeignKey(d => d.TowerType)
                    .HasConstraintName("FK_tblTower_lstTowerType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
