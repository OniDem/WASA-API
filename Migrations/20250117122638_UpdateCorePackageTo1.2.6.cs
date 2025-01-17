using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WASA_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCorePackageTo126 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrgId",
                table: "shared",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "shared");
        }
    }
}
