using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class districtMultilanguageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SubDistricts",
                newName: "Name_RU");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Districts",
                newName: "Name_RU");

            migrationBuilder.AddColumn<string>(
                name: "Name_AZ",
                table: "SubDistricts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_EN",
                table: "SubDistricts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_AZ",
                table: "Districts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_EN",
                table: "Districts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name_AZ",
                table: "SubDistricts");

            migrationBuilder.DropColumn(
                name: "Name_EN",
                table: "SubDistricts");

            migrationBuilder.DropColumn(
                name: "Name_AZ",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "Name_EN",
                table: "Districts");

            migrationBuilder.RenameColumn(
                name: "Name_RU",
                table: "SubDistricts",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Name_RU",
                table: "Districts",
                newName: "Name");
        }
    }
}
