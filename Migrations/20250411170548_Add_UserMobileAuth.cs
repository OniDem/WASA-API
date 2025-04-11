using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WASA_API.Migrations
{
    /// <inheritdoc />
    public partial class Add_UserMobileAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UserAuthInMobileApp",
                table: "shared",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAuthInMobileApp",
                table: "shared");
        }
    }
}
