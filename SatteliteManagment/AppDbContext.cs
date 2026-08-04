using Microsoft.EntityFrameworkCore;
using SatteliteManagment.Entities;
using System;
using System.Collections.Generic;
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
            
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=telemetry_db;Username=postgres;Password=1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PacketInfoEntity>()
                .HasOne(p => p.TlmPacket)
                .WithOne(t => t.PacketInfo)
                .HasForeignKey<TlmPacketEntity>(t => t.PacketInfoId);

            modelBuilder.Entity<PacketInfoEntity>()
                .HasOne(p => p.FileTransferPacket)
                .WithOne(f => f.PacketInfo)
                .HasForeignKey<FileTransferPacketEntity>(f => f.PacketInfoId);
        }
    }
}
