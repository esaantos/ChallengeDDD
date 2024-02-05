using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Associates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Cpf = table.Column<string>(type: "nchar(11)", fixedLength: true, maxLength: 11, nullable: false),
                    DateBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Cnpj = table.Column<string>(type: "nchar(14)", fixedLength: true, maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssociateCompany",
                columns: table => new
                {
                    AssociatesId = table.Column<int>(type: "int", nullable: false),
                    CompaniesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociateCompany", x => new { x.AssociatesId, x.CompaniesId });
                    table.ForeignKey(
                        name: "FK_AssociateCompany_Associates_AssociatesId",
                        column: x => x.AssociatesId,
                        principalTable: "Associates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssociateCompany_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssociateCompany_CompaniesId",
                table: "AssociateCompany",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_Associates_Cpf",
                table: "Associates",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Cnpj",
                table: "Companies",
                column: "Cnpj",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssociateCompany");

            migrationBuilder.DropTable(
                name: "Associates");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
