using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrNew.Persistence.Migrations
{
    public partial class SeedingHr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HrAllocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrAllocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HrTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HrRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HrTypeId = table.Column<int>(type: "int", nullable: false),
                    HrAllocationId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrRequests_HrAllocations_HrAllocationId",
                        column: x => x.HrAllocationId,
                        principalTable: "HrAllocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrRequests_HrTypes_HrTypeId",
                        column: x => x.HrTypeId,
                        principalTable: "HrTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HrAllocations",
                columns: new[] { "Id", "Name", "Surname" },
                values: new object[,]
                {
                    { 101, "Adam", "Nowak" },
                    { 102, "Maciek", "Bogdan" },
                    { 103, "Tymon", "Matison" },
                    { 104, "Jan", "Szczur" },
                    { 105, "Konrad", "Epal" }
                });

            migrationBuilder.InsertData(
                table: "HrTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Vacation" },
                    { 2, "Sick" }
                });

            migrationBuilder.InsertData(
                table: "HrRequests",
                columns: new[] { "Id", "Description", "EndDate", "HrAllocationId", "HrTypeId", "StartDate" },
                values: new object[] { 1, "Description", new DateTime(2023, 9, 10, 7, 7, 47, 419, DateTimeKind.Local).AddTicks(5565), 101, 1, new DateTime(2023, 9, 10, 7, 7, 47, 419, DateTimeKind.Local).AddTicks(5538) });

            migrationBuilder.InsertData(
                table: "HrRequests",
                columns: new[] { "Id", "Description", "EndDate", "HrAllocationId", "HrTypeId", "StartDate" },
                values: new object[] { 2, "Description", new DateTime(2023, 9, 10, 7, 7, 47, 419, DateTimeKind.Local).AddTicks(5569), 102, 2, new DateTime(2023, 9, 10, 7, 7, 47, 419, DateTimeKind.Local).AddTicks(5568) });

            migrationBuilder.CreateIndex(
                name: "IX_HrRequests_HrAllocationId",
                table: "HrRequests",
                column: "HrAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_HrRequests_HrTypeId",
                table: "HrRequests",
                column: "HrTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrRequests");

            migrationBuilder.DropTable(
                name: "HrAllocations");

            migrationBuilder.DropTable(
                name: "HrTypes");
        }
    }
}
