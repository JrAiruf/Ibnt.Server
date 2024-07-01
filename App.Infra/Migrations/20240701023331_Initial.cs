using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(36)", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    ProfileImage = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecoveryPassword",
                columns: table => new
                {
                    VerificationCode = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    VerificationEmail = table.Column<string>(type: "text", nullable: true),
                    NewPassword = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecoveryPassword", x => x.VerificationCode);
                });

            migrationBuilder.CreateTable(
                name: "TimeLine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    PostDate = table.Column<string>(type: "character varying(48)", nullable: true),
                    CreationDate = table.Column<string>(type: "character varying(48)", nullable: true),
                    Date = table.Column<string>(type: "character varying(48)", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeLine", x => x.Id);
                });

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
                    table.ForeignKey(
                        name: "FK_Announcement_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Credential",
                columns: table => new
                {
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: false),
                    MemberId = table.Column<string>(type: "character varying(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credential", x => x.Email);
                    table.ForeignKey(
                        name: "FK_Credential_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(36)", nullable: false),
                    EntityType = table.Column<string>(type: "text", nullable: false),
                    MemberId = table.Column<string>(type: "character varying(36)", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: false),
                    PostDate = table.Column<string>(type: "character varying(48)", nullable: true),
                    CreationDate = table.Column<string>(type: "character varying(48)", nullable: true),
                    Date = table.Column<string>(type: "character varying(48)", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BibleMessage",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(36)", nullable: false),
                    BaseText = table.Column<string>(type: "text", nullable: true),
                    EntityType = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    MemberId = table.Column<string>(type: "character varying(36)", nullable: false),
                    TimeLineId = table.Column<Guid>(type: "uuid", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: false),
                    PostDate = table.Column<string>(type: "character varying(48)", nullable: true),
                    CreationDate = table.Column<string>(type: "character varying(48)", nullable: true),
                    Date = table.Column<string>(type: "character varying(48)", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BibleMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BibleMessage_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BibleMessage_TimeLine_TimeLineId",
                        column: x => x.TimeLineId,
                        principalTable: "TimeLine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(36)", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    EntityType = table.Column<string>(type: "text", nullable: false),
                    MemberId = table.Column<string>(type: "character varying(36)", nullable: true),
                    TimeLineId = table.Column<Guid>(type: "uuid", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: false),
                    PostDate = table.Column<string>(type: "character varying(48)", nullable: true),
                    CreationDate = table.Column<string>(type: "character varying(48)", nullable: true),
                    Date = table.Column<string>(type: "character varying(48)", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Event_TimeLine_TimeLineId",
                        column: x => x.TimeLineId,
                        principalTable: "TimeLine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostReaction",
                columns: table => new
                {
                    MemberId = table.Column<string>(type: "character varying(36)", nullable: false),
                    PostId = table.Column<string>(type: "character varying(36)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Toogled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReaction", x => new { x.MemberId, x.PostId });
                    table.ForeignKey(
                        name: "FK_PostReaction_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BibleMessageReaction",
                columns: table => new
                {
                    MemberId = table.Column<string>(type: "character varying(36)", nullable: false),
                    BibleMessageId = table.Column<string>(type: "character varying(36)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Toogled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BibleMessageReaction", x => new { x.MemberId, x.BibleMessageId });
                    table.ForeignKey(
                        name: "FK_BibleMessageReaction_BibleMessage_BibleMessageId",
                        column: x => x.BibleMessageId,
                        principalTable: "BibleMessage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventReaction",
                columns: table => new
                {
                    MemberId = table.Column<string>(type: "character varying(36)", nullable: false),
                    EventId = table.Column<string>(type: "character varying(36)", nullable: false),
                    MemberEntityId = table.Column<string>(type: "character varying(36)", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Toogled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventReaction", x => new { x.MemberId, x.EventId });
                    table.ForeignKey(
                        name: "FK_EventReaction_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventReaction_Member_MemberEntityId",
                        column: x => x.MemberEntityId,
                        principalTable: "Member",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcement_MemberId",
                table: "Announcement",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_BibleMessage_MemberId",
                table: "BibleMessage",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_BibleMessage_TimeLineId",
                table: "BibleMessage",
                column: "TimeLineId");

            migrationBuilder.CreateIndex(
                name: "IX_BibleMessageReaction_BibleMessageId",
                table: "BibleMessageReaction",
                column: "BibleMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Credential_MemberId",
                table: "Credential",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_MemberId",
                table: "Event",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_TimeLineId",
                table: "Event",
                column: "TimeLineId");

            migrationBuilder.CreateIndex(
                name: "IX_EventReaction_EventId",
                table: "EventReaction",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventReaction_MemberEntityId",
                table: "EventReaction",
                column: "MemberEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_MemberId",
                table: "Post",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReaction_PostId",
                table: "PostReaction",
                column: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcement");

            migrationBuilder.DropTable(
                name: "BibleMessageReaction");

            migrationBuilder.DropTable(
                name: "Credential");

            migrationBuilder.DropTable(
                name: "EventReaction");

            migrationBuilder.DropTable(
                name: "PostReaction");

            migrationBuilder.DropTable(
                name: "RecoveryPassword");

            migrationBuilder.DropTable(
                name: "BibleMessage");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "TimeLine");

            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
