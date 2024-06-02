using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ibnt.Server.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixingIdBug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PostDate",
                table: "TimeLine",
                type: "character varying(48)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "TimeLine",
                type: "character varying(48)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreationDate",
                table: "TimeLine",
                type: "character varying(48)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PostDate",
                table: "TimeLine",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(48)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TimeLine",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(48)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TimeLine",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(48)",
                oldNullable: true);
        }
    }
}
