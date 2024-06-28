using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WASA_API.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryName);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductCode = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Count = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductCode);
                });

            migrationBuilder.CreateTable(
                name: "receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LoyaltyCardID = table.Column<int>(type: "integer", nullable: true),
                    LoyaltyBonusAdded = table.Column<double>(type: "double precision", nullable: true),
                    ProductCodes = table.Column<List<string>>(type: "text[]", nullable: true),
                    ProductCategories = table.Column<List<string>>(type: "text[]", nullable: true),
                    ProductNames = table.Column<List<string>>(type: "text[]", nullable: true),
                    ProductPrices = table.Column<List<double>>(type: "double precision[]", nullable: true),
                    ProductCount = table.Column<List<double>>(type: "double precision[]", nullable: true),
                    PayMethod = table.Column<int>(type: "integer", nullable: true),
                    Total = table.Column<double>(type: "double precision", nullable: false),
                    Canceled = table.Column<bool>(type: "boolean", nullable: false),
                    CancelReason = table.Column<int>(type: "integer", nullable: false),
                    Closed = table.Column<bool>(type: "boolean", nullable: false),
                    Seller = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CancelDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ClosedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receipts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "shifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Closed = table.Column<bool>(type: "boolean", nullable: true),
                    OpenBy = table.Column<string>(type: "text", nullable: false),
                    ClosedBy = table.Column<string>(type: "text", nullable: true),
                    OpenDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Cash = table.Column<double>(type: "double precision", nullable: true),
                    CashBox = table.Column<double>(type: "double precision", nullable: true),
                    CashBoxOperations = table.Column<List<string>>(type: "text[]", nullable: true),
                    Acquiring = table.Column<double>(type: "double precision", nullable: true),
                    AcquiringApproved = table.Column<bool>(type: "boolean", nullable: true),
                    Total = table.Column<double>(type: "double precision", nullable: true),
                    ReceiptsList = table.Column<List<int>>(type: "integer[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    FIO = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shifts_Acquiring",
                table: "shifts",
                column: "Acquiring")
                .Annotation("Npgsql:NullsDistinct", true);

            migrationBuilder.CreateIndex(
                name: "IX_shifts_AcquiringApproved",
                table: "shifts",
                column: "AcquiringApproved")
                .Annotation("Npgsql:NullsDistinct", true);

            migrationBuilder.CreateIndex(
                name: "IX_shifts_Cash",
                table: "shifts",
                column: "Cash")
                .Annotation("Npgsql:NullsDistinct", true);

            migrationBuilder.CreateIndex(
                name: "IX_shifts_CashBox",
                table: "shifts",
                column: "CashBox")
                .Annotation("Npgsql:NullsDistinct", true);

            migrationBuilder.CreateIndex(
                name: "IX_shifts_CashBoxOperations",
                table: "shifts",
                column: "CashBoxOperations")
                .Annotation("Npgsql:NullsDistinct", true);

            migrationBuilder.CreateIndex(
                name: "IX_shifts_Closed",
                table: "shifts",
                column: "Closed")
                .Annotation("Npgsql:NullsDistinct", true);

            migrationBuilder.CreateIndex(
                name: "IX_shifts_CloseDate",
                table: "shifts",
                column: "CloseDate")
                .Annotation("Npgsql:NullsDistinct", true);

            migrationBuilder.CreateIndex(
                name: "IX_shifts_ClosedBy",
                table: "shifts",
                column: "ClosedBy")
                .Annotation("Npgsql:NullsDistinct", true);

            migrationBuilder.CreateIndex(
                name: "IX_shifts_ReceiptsList",
                table: "shifts",
                column: "ReceiptsList")
                .Annotation("Npgsql:NullsDistinct", true);

            migrationBuilder.CreateIndex(
                name: "IX_shifts_Total",
                table: "shifts",
                column: "Total")
                .Annotation("Npgsql:NullsDistinct", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "receipts");

            migrationBuilder.DropTable(
                name: "shifts");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
