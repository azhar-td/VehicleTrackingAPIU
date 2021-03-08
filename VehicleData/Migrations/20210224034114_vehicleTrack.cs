using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleData.Migrations
{
    public partial class vehicleTrack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    CreationDT = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Model = table.Column<string>(nullable: false),
                    RegNum = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    CreationDT = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Token = table.Column<string>(nullable: false),
                    CreationDT = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleLogin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(nullable: false),
                    Token = table.Column<string>(nullable: false),
                    CreationDT = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleLogin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleLogin_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePosition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(nullable: false),
                    Longitude = table.Column<decimal>(nullable: false),
                    Latitude = table.Column<decimal>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclePosition_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreationDT", "Email", "Name", "Password" },
                values: new object[] { 1, new DateTime(2021, 2, 24, 8, 41, 13, 875, DateTimeKind.Local).AddTicks(1195), "azhar.teradata@gmail.com", "Azhar", "azhar123" });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "CreationDT", "Model", "Password", "RegNum" },
                values: new object[] { 1, new DateTime(2021, 2, 24, 8, 41, 13, 875, DateTimeKind.Local).AddTicks(5111), "2009", "azhar123", "LEE-09-1208" });

            migrationBuilder.InsertData(
                table: "VehiclePosition",
                columns: new[] { "Id", "Latitude", "Longitude", "TimeStamp", "VehicleId" },
                values: new object[] { 1, 40.73m, -74.00m, new DateTime(2021, 2, 24, 8, 41, 13, 875, DateTimeKind.Local).AddTicks(8122), 1 });

            migrationBuilder.InsertData(
                table: "VehiclePosition",
                columns: new[] { "Id", "Latitude", "Longitude", "TimeStamp", "VehicleId" },
                values: new object[] { 2, 32.09m, 72.67m, new DateTime(2021, 2, 24, 8, 31, 13, 875, DateTimeKind.Local).AddTicks(8765), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLogin_VehicleId",
                table: "VehicleLogin",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePosition_VehicleId",
                table: "VehiclePosition",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "VehicleLogin");

            migrationBuilder.DropTable(
                name: "VehiclePosition");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
