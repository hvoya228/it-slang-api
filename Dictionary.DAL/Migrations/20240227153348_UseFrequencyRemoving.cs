using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dictionary.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UseFrequencyRemoving : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Terms_UseFrequencies_UseFrequencyId",
                table: "Terms");

            migrationBuilder.DropTable(
                name: "UseFrequencies");

            migrationBuilder.DropIndex(
                name: "IX_Terms_UseFrequencyId",
                table: "Terms");

            migrationBuilder.DropColumn(
                name: "UseFrequencyId",
                table: "Terms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UseFrequencyId",
                table: "Terms",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "UseFrequencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Frequency = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UseFrequencies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Terms_UseFrequencyId",
                table: "Terms",
                column: "UseFrequencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Terms_UseFrequencies_UseFrequencyId",
                table: "Terms",
                column: "UseFrequencyId",
                principalTable: "UseFrequencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
