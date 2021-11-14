using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class notifyEventEmailSubjectPropertyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailSubject_AZ",
                table: "NotifyEvents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailSubject_EN",
                table: "NotifyEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailSubject_RU",
                table: "NotifyEvents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotifyEvents_NotifyFor",
                table: "NotifyEvents",
                column: "NotifyFor",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NotifyEvents_NotifyFor",
                table: "NotifyEvents");

            migrationBuilder.DropColumn(
                name: "EmailSubject_AZ",
                table: "NotifyEvents");

            migrationBuilder.DropColumn(
                name: "EmailSubject_EN",
                table: "NotifyEvents");

            migrationBuilder.DropColumn(
                name: "EmailSubject_RU",
                table: "NotifyEvents");
        }
    }
}
