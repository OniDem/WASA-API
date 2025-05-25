using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WASA_API.Migrations
{
    /// <inheritdoc />
    public partial class AddCompatible : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "visits");

            migrationBuilder.AddColumn<string>(
                name: "ModelCode",
                table: "products",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "modelCompatibles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModelCodes = table.Column<string[]>(type: "text[]", nullable: false),
                    CompatibleType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelCompatibles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_ModelCode",
                table: "products",
                column: "ModelCode")
                .Annotation("Npgsql:NullsDistinct", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "modelCompatibles");

            migrationBuilder.DropIndex(
                name: "IX_products_ModelCode",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ModelCode",
                table: "products");

            migrationBuilder.CreateTable(
                name: "visits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClosedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAtFull = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAtShort = table.Column<string>(type: "text", nullable: false),
                    OrgId = table.Column<int>(type: "integer", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    ReceiptId = table.Column<int>(type: "integer", nullable: true),
                    ShiftId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visits", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_visits_ReceiptId",
                table: "visits",
                column: "ReceiptId")
                .Annotation("Npgsql:NullsDistinct", true);
        }
    }
}
