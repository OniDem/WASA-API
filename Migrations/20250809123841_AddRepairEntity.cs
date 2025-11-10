using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WASA_API.Migrations
{
    /// <inheritdoc />
    public partial class AddRepairEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "repairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractSign = table.Column<bool>(type: "boolean", nullable: false),
                    CreationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ContractSignAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Client = table.Column<string>(type: "text", nullable: true),
                    ClientPhone = table.Column<string>(type: "text", nullable: true),
                    PreferCommunicationType = table.Column<string>(type: "text", nullable: true),
                    RepairObject = table.Column<string>(type: "text", nullable: false),
                    RepairObjectPassword = table.Column<string>(type: "text", nullable: false),
                    GetObjectAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SerialNumbers = table.Column<List<string>>(type: "text[]", nullable: true),
                    IMEI = table.Column<string>(type: "text", nullable: true),
                    Service = table.Column<string>(type: "text", nullable: false),
                    IsDiagnostic = table.Column<bool>(type: "boolean", nullable: false),
                    DiagnosticResultShort = table.Column<string>(type: "text", nullable: true),
                    DiagnosticResultLong = table.Column<string>(type: "text", nullable: true),
                    RepairVariants = table.Column<List<string>>(type: "text[]", nullable: true),
                    RepairTime = table.Column<int>(type: "integer", nullable: false),
                    EstimatedCost = table.Column<double>(type: "double precision", nullable: false),
                    PrePayment = table.Column<double>(type: "double precision", nullable: false),
                    PrePaymentType = table.Column<int>(type: "integer", nullable: false),
                    PreIsReceipted = table.Column<bool>(type: "boolean", nullable: false),
                    MainPayment = table.Column<double>(type: "double precision", nullable: false),
                    MainPaymentType = table.Column<int>(type: "integer", nullable: false),
                    MainIsReceipted = table.Column<bool>(type: "boolean", nullable: false),
                    PostPayment = table.Column<double>(type: "double precision", nullable: false),
                    PostPaymentType = table.Column<int>(type: "integer", nullable: false),
                    PostIsReceipted = table.Column<bool>(type: "boolean", nullable: false),
                    TotalPayment = table.Column<double>(type: "double precision", nullable: false),
                    TotalCost = table.Column<double>(type: "double precision", nullable: false),
                    IssueAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WarrantyDays = table.Column<int>(type: "integer", nullable: false),
                    WarrantyIsExpired = table.Column<bool>(type: "boolean", nullable: false),
                    ReturnByWarranty = table.Column<bool>(type: "boolean", nullable: false),
                    ReturnByWarrantyReason = table.Column<string>(type: "text", nullable: true),
                    WarrantyCost = table.Column<double>(type: "double precision", nullable: false),
                    Tax = table.Column<double>(type: "double precision", nullable: false),
                    AcquiringTax = table.Column<double>(type: "double precision", nullable: false),
                    AmountToDeduction = table.Column<double>(type: "double precision", nullable: false),
                    IsDeducted = table.Column<bool>(type: "boolean", nullable: false),
                    Profit = table.Column<double>(type: "double precision", nullable: false),
                    Marginality = table.Column<int>(type: "integer", nullable: false),
                    RepairStatuses = table.Column<int[]>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_repairs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "repairs");
        }
    }
}
