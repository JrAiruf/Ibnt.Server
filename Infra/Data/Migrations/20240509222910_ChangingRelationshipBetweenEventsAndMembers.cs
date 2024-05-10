using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ibnt.Server.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangingRelationshipBetweenEventsAndMembers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventEntityMemberEntity");

            migrationBuilder.AddColumn<string>(
                name: "MemberId",
                table: "Events",
                type: "character varying(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_MemberId",
                table: "Events",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Members_MemberId",
                table: "Events",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Members_MemberId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_MemberId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Events");

            migrationBuilder.CreateTable(
                name: "EventEntityMemberEntity",
                columns: table => new
                {
                    EventsId = table.Column<string>(type: "character varying(36)", nullable: false),
                    MembersId = table.Column<string>(type: "character varying(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventEntityMemberEntity", x => new { x.EventsId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_EventEntityMemberEntity_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventEntityMemberEntity_Members_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventEntityMemberEntity_MembersId",
                table: "EventEntityMemberEntity",
                column: "MembersId");
        }
    }
}
