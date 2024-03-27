using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dictionary.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UseExampleAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsingExample",
                table: "Terms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsingExample",
                table: "Terms");
        }
    }
}
