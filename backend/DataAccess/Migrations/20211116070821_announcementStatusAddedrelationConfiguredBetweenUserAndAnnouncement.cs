using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class announcementStatusAddedrelationConfiguredBetweenUserAndAnnouncement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnnouncementStatus",
                table: "Announcements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Announcements",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_UserId",
                table: "Announcements",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Users_UserId",
                table: "Announcements",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Users_UserId",
                table: "Announcements");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_UserId",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "AnnouncementStatus",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Announcements");
        }
    }
}
