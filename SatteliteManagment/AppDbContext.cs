using Microsoft.EntityFrameworkCore;
using SatteliteManagment.Entities;
using SatteliteManagment.Entities.LeafEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SatteliteManagment
{
    internal class AppDbContext : DbContext
    {
        public DbSet<TlmPacketEntity> TlmPackets { get; set; }
        public DbSet<PacketInfoEntity> PacketInfos { get; set; }
        public DbSet<FileTransferPacketEntity> FileTransferPackets { get; set; }
        public DbSet<RadioPacketEntity> RadioPackets { get; set; }
        public DbSet<PacketDescriptionEntity> PacketDescriptions { get; set; }

        public DbSet<FileRequestEntity> FileRequests { get; set; }
        public DbSet<ModuleStatusEntity> ModuleStatuses { get; set; }
        public DbSet<MotorSpeedEntity> MotorSpeeds { get; set; }
        public DbSet<ReprogrammingEntity> Reprogrammings { get; set; }
        public DbSet<TimeSetEntity> TimeSets { get; set; }
        public DbSet<VerifyCheckSumEntity> VerifyCheckSums { get; set; }
        public DbSet<CoilMagnetMomentEntity> CoilMagnetMoments { get; set; }
        public DbSet<StoredFileEntity> StoredFiles { get; set; }

        private readonly string path = Path.Combine(Directory.GetCurrentDirectory(), "Properties/dbconnect.txt");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseNpgsql(File.ReadAllText(path));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RadioPacketEntity>()
                .HasOne(x => x.PacketInfo)
                .WithOne(x => x.RadioPacketEntity)
                .HasForeignKey<RadioPacketEntity>(x => x.PacketInfoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RadioPacketEntity>()
                .HasOne(x => x.PacketDescription)
                .WithOne()
                .HasForeignKey<RadioPacketEntity>(x => x.DescriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TlmPacketEntity>()
                .HasOne(x => x.DescriptionEntity)
                .WithOne()
                .HasForeignKey<TlmPacketEntity>(x => x.DescriptionId);

            modelBuilder.Entity<FileTransferPacketEntity>()
                .HasOne(x => x.DescriptionEntity)
                .WithOne()
                .HasForeignKey<FileTransferPacketEntity>(x => x.DescriptionId);
            // FileRequest -> PacketDescription
            modelBuilder.Entity<FileRequestEntity>()
                .HasOne(x => x.DescriptionEntity)
                .WithOne()
                .HasForeignKey<FileRequestEntity>(x => x.DescriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            // ModuleStatus -> PacketDescription
            modelBuilder.Entity<ModuleStatusEntity>()
                .HasOne(x => x.DescriptionEntity)
                .WithOne()
                .HasForeignKey<ModuleStatusEntity>(x => x.DescriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            // MotorSpeed -> PacketDescription
            modelBuilder.Entity<MotorSpeedEntity>()
                .HasOne(x => x.DescriptionEntity)
                .WithOne()
                .HasForeignKey<MotorSpeedEntity>(x => x.DescriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Reprogramming -> PacketDescription
            modelBuilder.Entity<ReprogrammingEntity>()
                .HasOne(x => x.DescriptionEntity)
                .WithOne()
                .HasForeignKey<ReprogrammingEntity>(x => x.DescriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            // TimeSet -> PacketDescription
            modelBuilder.Entity<TimeSetEntity>()
                .HasOne(x => x.DescriptionEntity)
                .WithOne()
                .HasForeignKey<TimeSetEntity>(x => x.DescriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            // VerifyCheckSum -> PacketDescription
            modelBuilder.Entity<VerifyCheckSumEntity>()
                .HasOne(x => x.DescriptionEntity)
                .WithOne()
                .HasForeignKey<VerifyCheckSumEntity>(x => x.DescriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            // CoilMagnetMoment -> PacketDescription
            modelBuilder.Entity<CoilMagnetMomentEntity>()
                .HasOne(x => x.DescriptionEntity)
                .WithOne()
                .HasForeignKey<CoilMagnetMomentEntity>(x => x.DescriptionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
