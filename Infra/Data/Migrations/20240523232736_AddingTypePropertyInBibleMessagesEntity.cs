using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ibnt.Server.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingTypePropertyInBibleMessagesEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "BibleMessages",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "BibleMessages");
        }
    }
}
