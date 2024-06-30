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
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(36)", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    ProfileImage = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecoveryPasswords",
                columns: table => new
                {
                    VerificationCode = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    VerificationEmail = table.Column<string>(type: "text", nullable: true),
                    NewPassword = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecoveryPasswords", x => x.VerificationCode);
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
                name: "Credentials",
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
                    table.PrimaryKey("PK_Credentials", x => x.Email);
                    table.ForeignKey(
                        name: "FK_Credentials_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
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
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BibleMessages",
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
                    table.PrimaryKey("PK_BibleMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BibleMessages_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BibleMessages_TimeLine_TimeLineId",
                        column: x => x.TimeLineId,
                        principalTable: "TimeLine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Events",
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
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Events_TimeLine_TimeLineId",
                        column: x => x.TimeLineId,
                        principalTable: "TimeLine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostReactions",
                columns: table => new
                {
                    MemberId = table.Column<string>(type: "character varying(36)", nullable: false),
                    PostId = table.Column<string>(type: "character varying(36)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Toogled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReactions", x => new { x.MemberId, x.PostId });
                    table.ForeignKey(
                        name: "FK_PostReactions_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BibleMessageReactions",
                columns: table => new
                {
                    MemberId = table.Column<string>(type: "character varying(36)", nullable: false),
                    BibleMessageId = table.Column<string>(type: "character varying(36)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Toogled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BibleMessageReactions", x => new { x.MemberId, x.BibleMessageId });
                    table.ForeignKey(
                        name: "FK_BibleMessageReactions_BibleMessages_BibleMessageId",
                        column: x => x.BibleMessageId,
                        principalTable: "BibleMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventReactions",
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
                    table.PrimaryKey("PK_EventReactions", x => new { x.MemberId, x.EventId });
                    table.ForeignKey(
                        name: "FK_EventReactions_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventReactions_Members_MemberEntityId",
                        column: x => x.MemberEntityId,
                        principalTable: "Members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BibleMessageReactions_BibleMessageId",
                table: "BibleMessageReactions",
                column: "BibleMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_BibleMessages_MemberId",
                table: "BibleMessages",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_BibleMessages_TimeLineId",
                table: "BibleMessages",
                column: "TimeLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_MemberId",
                table: "Credentials",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventReactions_EventId",
                table: "EventReactions",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventReactions_MemberEntityId",
                table: "EventReactions",
                column: "MemberEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_MemberId",
                table: "Events",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_TimeLineId",
                table: "Events",
                column: "TimeLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReactions_PostId",
                table: "PostReactions",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_MemberId",
                table: "Posts",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BibleMessageReactions");

            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.DropTable(
                name: "EventReactions");

            migrationBuilder.DropTable(
                name: "PostReactions");

            migrationBuilder.DropTable(
                name: "RecoveryPasswords");

            migrationBuilder.DropTable(
                name: "BibleMessages");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "TimeLine");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
