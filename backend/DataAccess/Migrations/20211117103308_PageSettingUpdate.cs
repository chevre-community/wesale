using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class PageSettingUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PageSettings",
                table: "PageSettings");

            migrationBuilder.RenameTable(
                name: "PageSettings",
                newName: "PageSetting");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PageSetting",
                table: "PageSetting",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PageSetting",
                table: "PageSetting");

            migrationBuilder.RenameTable(
                name: "PageSetting",
                newName: "PageSettings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PageSettings",
                table: "PageSettings",
                column: "Id");
        }
    }
}
