using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class PhonePrefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhonePrefixId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PhonePrefixes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhonePrefixes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhonePrefixId",
                table: "Users",
                column: "PhonePrefixId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PhonePrefixes_PhonePrefixId",
                table: "Users",
                column: "PhonePrefixId",
                principalTable: "PhonePrefixes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_PhonePrefixes_PhonePrefixId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "PhonePrefixes");

            migrationBuilder.DropIndex(
                name: "IX_Users_PhonePrefixId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhonePrefixId",
                table: "Users");
        }
    }
}
