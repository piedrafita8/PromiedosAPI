using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromiedosApi.Migrations
{
    /// <inheritdoc />
    public partial class InitializeBaseEntityAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Stadiums");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Stadiums");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Cities");

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "Tournaments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "Tournaments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "Teams",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "Teams",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "Stadiums",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "Stadiums",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "Matches",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "Matches",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "Cities",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "Cities",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "Stadiums");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "Stadiums");

            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "Cities");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Tournaments",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Tournaments",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Teams",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Teams",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Stadiums",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Stadiums",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Matches",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Matches",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Cities",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Cities",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
