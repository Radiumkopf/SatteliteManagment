using Microsoft.EntityFrameworkCore;
using SatteliteManagment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace SatteliteManagment
{
    internal class AppDbContext : DbContext
    {
        public DbSet<TlmPacketEntity> TlmPackets { get; set; }
        public DbSet<PacketInfoEntity> PacketInfos { get; set; }
        public DbSet<FileTransferPacketEntity> FileTransferPackets { get; set; }
        public DbSet<RadioPacketEntity> RadioPackets { get; set; }
        public DbSet<PacketDescriptionEntity> PacketDescriptions { get; set; }


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
        }
    }
}
