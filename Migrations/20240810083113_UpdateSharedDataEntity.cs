using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WASA_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSharedDataEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OpenedShiftId",
                table: "shared",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_shared_Barcode",
                table: "shared",
                column: "Barcode")
                .Annotation("Npgsql:NullsDistinct", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_shared_Barcode",
                table: "shared");

            migrationBuilder.DropColumn(
                name: "OpenedShiftId",
                table: "shared");
        }
    }
}
