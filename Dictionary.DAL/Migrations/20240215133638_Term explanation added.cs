using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dictionary.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Termexplanationadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Explanation",
                table: "Terms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Explanation",
                table: "Terms");
        }
    }
}
