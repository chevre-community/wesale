using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class announcementRentAndAnnouncementOfficeTypePropertyRenamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnnouncementRentType",
                table: "AnnouncementRents",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "AnnouncementOfficeType",
                table: "AnnouncementOfficeObjects",
                newName: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "AnnouncementRents",
                newName: "AnnouncementRentType");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "AnnouncementOfficeObjects",
                newName: "AnnouncementOfficeType");
        }
    }
}
