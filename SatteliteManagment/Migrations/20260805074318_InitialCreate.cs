using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SatteliteManagment.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PacketInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AES_CRC = table.Column<byte>(nullable: false),
                    BROADCAST = table.Column<bool>(nullable: false),
                    ACK_TYP = table.Column<bool>(nullable: false),
                    ACK_REQ = table.Column<bool>(nullable: false),
                    DestAddr = table.Column<decimal>(nullable: false),
                    SourceAddr = table.Column<decimal>(nullable: false),
                    retrCount = table.Column<byte>(nullable: false),
                    payload_lth = table.Column<byte>(nullable: false),
                    packetID = table.Column<long>(nullable: false),
                    rssi = table.Column<short>(nullable: false),
                    snr = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacketInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileTransferPackets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PacketInfoId = table.Column<int>(nullable: false),
                    Type = table.Column<byte>(nullable: false),
                    FileId = table.Column<byte>(nullable: false),
                    Number = table.Column<short>(nullable: false),
                    Size = table.Column<byte>(nullable: false),
                    Data = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTransferPackets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileTransferPackets_PacketInfos_PacketInfoId",
                        column: x => x.PacketInfoId,
                        principalTable: "PacketInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlmPackets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PacketInfoId = table.Column<int>(nullable: false),
                    Temperature1 = table.Column<float>(nullable: false),
                    Temperature2 = table.Column<float>(nullable: false),
                    BatteryV = table.Column<float>(nullable: false),
                    PvPower1 = table.Column<float>(nullable: false),
                    PvPower2 = table.Column<float>(nullable: false),
                    PvPower3 = table.Column<float>(nullable: false),
                    AngularRate = table.Column<float>(nullable: false),
                    MagFieldAbs = table.Column<float>(nullable: false),
                    BatChargePower = table.Column<float>(nullable: false),
                    BatDischargePower = table.Column<float>(nullable: false),
                    ResetCounter = table.Column<byte>(nullable: false),
                    StatusFlags = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlmPackets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TlmPackets_PacketInfos_PacketInfoId",
                        column: x => x.PacketInfoId,
                        principalTable: "PacketInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileTransferPackets_PacketInfoId",
                table: "FileTransferPackets",
                column: "PacketInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TlmPackets_PacketInfoId",
                table: "TlmPackets",
                column: "PacketInfoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileTransferPackets");

            migrationBuilder.DropTable(
                name: "TlmPackets");

            migrationBuilder.DropTable(
                name: "PacketInfos");
        }
    }
}
