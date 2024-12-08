using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fwf.dal.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "route",
                columns: table => new
                {
                    airline = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    sourceAirport = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    destinationAirport = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    codeShare = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    stops = table.Column<int>(type: "int", nullable: false),
                    equipment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    sourceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_route", x => new { x.airline, x.sourceAirport, x.destinationAirport, x.codeShare, x.stops });
                });

            migrationBuilder.CreateTable(
                name: "route_staging",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    airline = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    sourceAirport = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    destinationAirport = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    codeShare = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    stops = table.Column<int>(type: "int", nullable: true),
                    equipment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    pipelineRunId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    provider = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_route_staging", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "route");

            migrationBuilder.DropTable(
                name: "route_staging");
        }
    }
}
