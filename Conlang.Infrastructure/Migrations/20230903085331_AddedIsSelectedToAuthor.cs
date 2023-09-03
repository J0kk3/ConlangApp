using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Conlang.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsSelectedToAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Authors",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Authors");
        }
    }
}
