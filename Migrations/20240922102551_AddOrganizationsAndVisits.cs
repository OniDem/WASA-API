using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WASA_API.Migrations
{
    /// <inheritdoc />
    public partial class AddOrganizationsAndVisits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "receipts",
                newName: "CreationDateFull");

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "shifts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreationDateShort",
                table: "receipts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Shifts = table.Column<List<int>>(type: "integer[]", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Billing = table.Column<double>(type: "double precision", nullable: false),
                    StaffIds = table.Column<List<int>>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "visits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganizationId = table.Column<int>(type: "integer", nullable: false),
                    ShiftId = table.Column<int>(type: "integer", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    ReceiptId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAtFull = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAtShort = table.Column<string>(type: "text", nullable: false),
                    ClosedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visits", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_organizations_Billing",
                table: "organizations",
                column: "Billing")
                .Annotation("Npgsql:NullsDistinct", true);

            migrationBuilder.CreateIndex(
                name: "IX_organizations_Shifts",
                table: "organizations",
                column: "Shifts")
                .Annotation("Npgsql:NullsDistinct", true);

            migrationBuilder.CreateIndex(
                name: "IX_organizations_StaffIds",
                table: "organizations",
                column: "StaffIds")
                .Annotation("Npgsql:NullsDistinct", true);

            migrationBuilder.CreateIndex(
                name: "IX_visits_ReceiptId",
                table: "visits",
                column: "ReceiptId")
                .Annotation("Npgsql:NullsDistinct", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "organizations");

            migrationBuilder.DropTable(
                name: "visits");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "shifts");

            migrationBuilder.DropColumn(
                name: "CreationDateShort",
                table: "receipts");

            migrationBuilder.RenameColumn(
                name: "CreationDateFull",
                table: "receipts",
                newName: "CreationDate");
        }
    }
}
