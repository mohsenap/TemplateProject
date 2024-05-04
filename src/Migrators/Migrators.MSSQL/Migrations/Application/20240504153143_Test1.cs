using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    /// <inheritdoc />
    public partial class Test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsuranceCoverage",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsurenceCover = table.Column<int>(type: "int", nullable: false),
                    MinimumAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaximumAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCoverage", x => x.Id);
                    table.UniqueConstraint("AK_InsuranceCoverage_InsurenceCover", x => x.InsurenceCover);
                });

            migrationBuilder.CreateTable(
                name: "UserRequest",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TenantId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRequestInsuranceCoverage",
                schema: "Catalog",
                columns: table => new
                {
                    UserRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsuranceCoverageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRequestInsuranceCoverage", x => new { x.UserRequestId, x.InsuranceCoverageId });
                    table.ForeignKey(
                        name: "FK_UserRequestInsuranceCoverage_InsuranceCoverage_InsuranceCoverageId",
                        column: x => x.InsuranceCoverageId,
                        principalSchema: "Catalog",
                        principalTable: "InsuranceCoverage",
                        principalColumn: "InsurenceCover",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRequestInsuranceCoverage_UserRequest_UserRequestId",
                        column: x => x.UserRequestId,
                        principalSchema: "Catalog",
                        principalTable: "UserRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRequestInsuranceCoverage_InsuranceCoverageId",
                schema: "Catalog",
                table: "UserRequestInsuranceCoverage",
                column: "InsuranceCoverageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRequestInsuranceCoverage",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "InsuranceCoverage",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "UserRequest",
                schema: "Catalog");
        }
    }
}
