using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WASA_API.Migrations
{
    /// <inheritdoc />
    public partial class CoreUpdate124 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrganizationId",
                table: "visits",
                newName: "OrgId");

            migrationBuilder.RenameColumn(
                name: "OrganizationId",
                table: "shifts",
                newName: "OrgId");

            migrationBuilder.AddColumn<int>(
                name: "OrgId",
                table: "users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CashBox",
                table: "shared",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "OrgId",
                table: "receipts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrgId",
                table: "products",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "CashBox",
                table: "shared");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "receipts");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "OrgId",
                table: "visits",
                newName: "OrganizationId");

            migrationBuilder.RenameColumn(
                name: "OrgId",
                table: "shifts",
                newName: "OrganizationId");
        }
    }
}
