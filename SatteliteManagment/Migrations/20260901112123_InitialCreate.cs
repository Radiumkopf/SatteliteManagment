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
                name: "PacketDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    packetType = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacketDescriptions", x => x.Id);
                });

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
                name: "StoredFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Address = table.Column<byte[]>(nullable: false),
                    FileData = table.Column<byte[]>(nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    ContentType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoredFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoilMagnetMoments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DescriptionId = table.Column<int>(nullable: false),
                    Result = table.Column<byte>(nullable: false),
                    MagnetMoment = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoilMagnetMoments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoilMagnetMoments_PacketDescriptions_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "PacketDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FileRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DescriptionId = table.Column<int>(nullable: false),
                    Result = table.Column<byte>(nullable: false),
                    FileId = table.Column<byte>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Size = table.Column<byte>(nullable: false),
                    Data = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileRequests_PacketDescriptions_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "PacketDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FileTransferPackets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DescriptionId = table.Column<int>(nullable: false),
                    Result = table.Column<byte>(nullable: false),
                    FileId = table.Column<byte>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Size = table.Column<byte>(nullable: false),
                    Data = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTransferPackets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileTransferPackets_PacketDescriptions_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "PacketDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuleStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DescriptionId = table.Column<int>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    ModuleStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleStatuses_PacketDescriptions_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "PacketDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MotorSpeeds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DescriptionId = table.Column<int>(nullable: false),
                    Result = table.Column<byte>(nullable: false),
                    Speed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorSpeeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotorSpeeds_PacketDescriptions_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "PacketDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reprogrammings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DescriptionId = table.Column<int>(nullable: false),
                    Result = table.Column<byte>(nullable: false),
                    FileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reprogrammings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reprogrammings_PacketDescriptions_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "PacketDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeSets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DescriptionId = table.Column<int>(nullable: false),
                    Result = table.Column<byte>(nullable: false),
                    TimeSet = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSets_PacketDescriptions_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "PacketDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TlmPackets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DescriptionId = table.Column<int>(nullable: false),
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
                        name: "FK_TlmPackets_PacketDescriptions_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "PacketDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VerifyCheckSums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DescriptionId = table.Column<int>(nullable: false),
                    Result = table.Column<byte>(nullable: false),
                    FileId = table.Column<int>(nullable: false),
                    Crc = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerifyCheckSums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerifyCheckSums_PacketDescriptions_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "PacketDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RadioPackets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dateTime = table.Column<DateTime>(nullable: false),
                    PacketInfoId = table.Column<int>(nullable: false),
                    DescriptionId = table.Column<int>(nullable: false),
                    SenderName = table.Column<string>(nullable: true),
                    ReceiverName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadioPackets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RadioPackets_PacketDescriptions_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "PacketDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RadioPackets_PacketInfos_PacketInfoId",
                        column: x => x.PacketInfoId,
                        principalTable: "PacketInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoilMagnetMoments_DescriptionId",
                table: "CoilMagnetMoments",
                column: "DescriptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileRequests_DescriptionId",
                table: "FileRequests",
                column: "DescriptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileTransferPackets_DescriptionId",
                table: "FileTransferPackets",
                column: "DescriptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModuleStatuses_DescriptionId",
                table: "ModuleStatuses",
                column: "DescriptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MotorSpeeds_DescriptionId",
                table: "MotorSpeeds",
                column: "DescriptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RadioPackets_DescriptionId",
                table: "RadioPackets",
                column: "DescriptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RadioPackets_PacketInfoId",
                table: "RadioPackets",
                column: "PacketInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reprogrammings_DescriptionId",
                table: "Reprogrammings",
                column: "DescriptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSets_DescriptionId",
                table: "TimeSets",
                column: "DescriptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TlmPackets_DescriptionId",
                table: "TlmPackets",
                column: "DescriptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VerifyCheckSums_DescriptionId",
                table: "VerifyCheckSums",
                column: "DescriptionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoilMagnetMoments");

            migrationBuilder.DropTable(
                name: "FileRequests");

            migrationBuilder.DropTable(
                name: "FileTransferPackets");

            migrationBuilder.DropTable(
                name: "ModuleStatuses");

            migrationBuilder.DropTable(
                name: "MotorSpeeds");

            migrationBuilder.DropTable(
                name: "RadioPackets");

            migrationBuilder.DropTable(
                name: "Reprogrammings");

            migrationBuilder.DropTable(
                name: "StoredFiles");

            migrationBuilder.DropTable(
                name: "TimeSets");

            migrationBuilder.DropTable(
                name: "TlmPackets");

            migrationBuilder.DropTable(
                name: "VerifyCheckSums");

            migrationBuilder.DropTable(
                name: "PacketInfos");

            migrationBuilder.DropTable(
                name: "PacketDescriptions");
        }
    }
}
