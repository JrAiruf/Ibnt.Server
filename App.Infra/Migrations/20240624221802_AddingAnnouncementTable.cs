using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddingAnnouncementTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BibleMessageReactions_BibleMessages_BibleMessageId",
                table: "BibleMessageReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_BibleMessages_Members_MemberId",
                table: "BibleMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_BibleMessages_TimeLine_TimeLineId",
                table: "BibleMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Credentials_Members_MemberId",
                table: "Credentials");

            migrationBuilder.DropForeignKey(
                name: "FK_EventReactions_Events_EventId",
                table: "EventReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_EventReactions_Members_MemberEntityId",
                table: "EventReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Members_MemberId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_TimeLine_TimeLineId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReactions_Posts_PostId",
                table: "PostReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Members_MemberId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecoveryPasswords",
                table: "RecoveryPasswords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostReactions",
                table: "PostReactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventReactions",
                table: "EventReactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Credentials",
                table: "Credentials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BibleMessages",
                table: "BibleMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BibleMessageReactions",
                table: "BibleMessageReactions");

            migrationBuilder.RenameTable(
                name: "RecoveryPasswords",
                newName: "RecoveryPassword");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");

            migrationBuilder.RenameTable(
                name: "PostReactions",
                newName: "PostReaction");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Member");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Event");

            migrationBuilder.RenameTable(
                name: "EventReactions",
                newName: "EventReaction");

            migrationBuilder.RenameTable(
                name: "Credentials",
                newName: "Credential");

            migrationBuilder.RenameTable(
                name: "BibleMessages",
                newName: "BibleMessage");

            migrationBuilder.RenameTable(
                name: "BibleMessageReactions",
                newName: "BibleMessageReaction");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_MemberId",
                table: "Post",
                newName: "IX_Post_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_PostReactions_PostId",
                table: "PostReaction",
                newName: "IX_PostReaction_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_TimeLineId",
                table: "Event",
                newName: "IX_Event_TimeLineId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_MemberId",
                table: "Event",
                newName: "IX_Event_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_EventReactions_MemberEntityId",
                table: "EventReaction",
                newName: "IX_EventReaction_MemberEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_EventReactions_EventId",
                table: "EventReaction",
                newName: "IX_EventReaction_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Credentials_MemberId",
                table: "Credential",
                newName: "IX_Credential_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_BibleMessages_TimeLineId",
                table: "BibleMessage",
                newName: "IX_BibleMessage_TimeLineId");

            migrationBuilder.RenameIndex(
                name: "IX_BibleMessages_MemberId",
                table: "BibleMessage",
                newName: "IX_BibleMessage_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_BibleMessageReactions_BibleMessageId",
                table: "BibleMessageReaction",
                newName: "IX_BibleMessageReaction_BibleMessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecoveryPassword",
                table: "RecoveryPassword",
                column: "VerificationCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostReaction",
                table: "PostReaction",
                columns: new[] { "MemberId", "PostId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventReaction",
                table: "EventReaction",
                columns: new[] { "MemberId", "EventId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Credential",
                table: "Credential",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BibleMessage",
                table: "BibleMessage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BibleMessageReaction",
                table: "BibleMessageReaction",
                columns: new[] { "MemberId", "BibleMessageId" });

            migrationBuilder.CreateTable(
                name: "Announcement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberId = table.Column<string>(type: "character varying(36)", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<string>(type: "character varying(48)", nullable: false),
                    FixedWarning = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcement", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BibleMessage_Member_MemberId",
                table: "BibleMessage",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BibleMessage_TimeLine_TimeLineId",
                table: "BibleMessage",
                column: "TimeLineId",
                principalTable: "TimeLine",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BibleMessageReaction_BibleMessage_BibleMessageId",
                table: "BibleMessageReaction",
                column: "BibleMessageId",
                principalTable: "BibleMessage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Credential_Member_MemberId",
                table: "Credential",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Member_MemberId",
                table: "Event",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_TimeLine_TimeLineId",
                table: "Event",
                column: "TimeLineId",
                principalTable: "TimeLine",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventReaction_Event_EventId",
                table: "EventReaction",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventReaction_Member_MemberEntityId",
                table: "EventReaction",
                column: "MemberEntityId",
                principalTable: "Member",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Member_MemberId",
                table: "Post",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReaction_Post_PostId",
                table: "PostReaction",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BibleMessage_Member_MemberId",
                table: "BibleMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_BibleMessage_TimeLine_TimeLineId",
                table: "BibleMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_BibleMessageReaction_BibleMessage_BibleMessageId",
                table: "BibleMessageReaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Credential_Member_MemberId",
                table: "Credential");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Member_MemberId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_TimeLine_TimeLineId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_EventReaction_Event_EventId",
                table: "EventReaction");

            migrationBuilder.DropForeignKey(
                name: "FK_EventReaction_Member_MemberEntityId",
                table: "EventReaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Member_MemberId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReaction_Post_PostId",
                table: "PostReaction");

            migrationBuilder.DropTable(
                name: "Announcement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecoveryPassword",
                table: "RecoveryPassword");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostReaction",
                table: "PostReaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventReaction",
                table: "EventReaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Credential",
                table: "Credential");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BibleMessageReaction",
                table: "BibleMessageReaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BibleMessage",
                table: "BibleMessage");

            migrationBuilder.RenameTable(
                name: "RecoveryPassword",
                newName: "RecoveryPasswords");

            migrationBuilder.RenameTable(
                name: "PostReaction",
                newName: "PostReactions");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "Member",
                newName: "Members");

            migrationBuilder.RenameTable(
                name: "EventReaction",
                newName: "EventReactions");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Events");

            migrationBuilder.RenameTable(
                name: "Credential",
                newName: "Credentials");

            migrationBuilder.RenameTable(
                name: "BibleMessageReaction",
                newName: "BibleMessageReactions");

            migrationBuilder.RenameTable(
                name: "BibleMessage",
                newName: "BibleMessages");

            migrationBuilder.RenameIndex(
                name: "IX_PostReaction_PostId",
                table: "PostReactions",
                newName: "IX_PostReactions_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_MemberId",
                table: "Posts",
                newName: "IX_Posts_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_EventReaction_MemberEntityId",
                table: "EventReactions",
                newName: "IX_EventReactions_MemberEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_EventReaction_EventId",
                table: "EventReactions",
                newName: "IX_EventReactions_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Event_TimeLineId",
                table: "Events",
                newName: "IX_Events_TimeLineId");

            migrationBuilder.RenameIndex(
                name: "IX_Event_MemberId",
                table: "Events",
                newName: "IX_Events_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Credential_MemberId",
                table: "Credentials",
                newName: "IX_Credentials_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_BibleMessageReaction_BibleMessageId",
                table: "BibleMessageReactions",
                newName: "IX_BibleMessageReactions_BibleMessageId");

            migrationBuilder.RenameIndex(
                name: "IX_BibleMessage_TimeLineId",
                table: "BibleMessages",
                newName: "IX_BibleMessages_TimeLineId");

            migrationBuilder.RenameIndex(
                name: "IX_BibleMessage_MemberId",
                table: "BibleMessages",
                newName: "IX_BibleMessages_MemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecoveryPasswords",
                table: "RecoveryPasswords",
                column: "VerificationCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostReactions",
                table: "PostReactions",
                columns: new[] { "MemberId", "PostId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventReactions",
                table: "EventReactions",
                columns: new[] { "MemberId", "EventId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Credentials",
                table: "Credentials",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BibleMessageReactions",
                table: "BibleMessageReactions",
                columns: new[] { "MemberId", "BibleMessageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BibleMessages",
                table: "BibleMessages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BibleMessageReactions_BibleMessages_BibleMessageId",
                table: "BibleMessageReactions",
                column: "BibleMessageId",
                principalTable: "BibleMessages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BibleMessages_Members_MemberId",
                table: "BibleMessages",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BibleMessages_TimeLine_TimeLineId",
                table: "BibleMessages",
                column: "TimeLineId",
                principalTable: "TimeLine",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Credentials_Members_MemberId",
                table: "Credentials",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventReactions_Events_EventId",
                table: "EventReactions",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventReactions_Members_MemberEntityId",
                table: "EventReactions",
                column: "MemberEntityId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Members_MemberId",
                table: "Events",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_TimeLine_TimeLineId",
                table: "Events",
                column: "TimeLineId",
                principalTable: "TimeLine",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReactions_Posts_PostId",
                table: "PostReactions",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Members_MemberId",
                table: "Posts",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");
        }
    }
}
