using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ibnt.Server.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingTimeLineTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TimeLineId",
                table: "Events",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TimeLineId",
                table: "BibleMessages",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TimeLine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    PostDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeLine", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_TimeLineId",
                table: "Events",
                column: "TimeLineId");

            migrationBuilder.CreateIndex(
                name: "IX_BibleMessages_TimeLineId",
                table: "BibleMessages",
                column: "TimeLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_BibleMessages_TimeLine_TimeLineId",
                table: "BibleMessages",
                column: "TimeLineId",
                principalTable: "TimeLine",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_TimeLine_TimeLineId",
                table: "Events",
                column: "TimeLineId",
                principalTable: "TimeLine",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BibleMessages_TimeLine_TimeLineId",
                table: "BibleMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_TimeLine_TimeLineId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "TimeLine");

            migrationBuilder.DropIndex(
                name: "IX_Events_TimeLineId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_BibleMessages_TimeLineId",
                table: "BibleMessages");

            migrationBuilder.DropColumn(
                name: "TimeLineId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "TimeLineId",
                table: "BibleMessages");
        }
    }
}
