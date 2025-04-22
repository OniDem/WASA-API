using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WASA_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrgEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CashBox",
                table: "organizations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<List<string>>(
                name: "CashBoxOperations",
                table: "organizations",
                type: "text[]",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CashBox",
                table: "organizations");

            migrationBuilder.DropColumn(
                name: "CashBoxOperations",
                table: "organizations");
        }
    }
}
