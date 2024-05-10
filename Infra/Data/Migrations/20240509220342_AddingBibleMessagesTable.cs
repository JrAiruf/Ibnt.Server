using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ibnt.Server.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingBibleMessagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Reactions",
                table: "Reactions");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Reactions",
                type: "character varying(36)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "BibleMessageId",
                table: "Reactions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Events",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntityType",
                table: "Events",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Reactions_MemberId_BibleMessageId",
                table: "Reactions",
                columns: new[] { "MemberId", "BibleMessageId" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Reactions_MemberId_EventId",
                table: "Reactions",
                columns: new[] { "MemberId", "EventId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reactions",
                table: "Reactions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BibleMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BaseText = table.Column<string>(type: "text", nullable: true),
                    EntityType = table.Column<string>(type: "text", nullable: false),
                    MemberId = table.Column<string>(type: "character varying(36)", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    PostDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BibleMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BibleMessages_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_BibleMessageId",
                table: "Reactions",
                column: "BibleMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_BibleMessages_MemberId",
                table: "BibleMessages",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_BibleMessages_BibleMessageId",
                table: "Reactions",
                column: "BibleMessageId",
                principalTable: "BibleMessages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_BibleMessages_BibleMessageId",
                table: "Reactions");

            migrationBuilder.DropTable(
                name: "BibleMessages");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Reactions_MemberId_BibleMessageId",
                table: "Reactions");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Reactions_MemberId_EventId",
                table: "Reactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reactions",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Reactions_BibleMessageId",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "BibleMessageId",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EntityType",
                table: "Events");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reactions",
                table: "Reactions",
                columns: new[] { "MemberId", "EventId" });
        }
    }
}
