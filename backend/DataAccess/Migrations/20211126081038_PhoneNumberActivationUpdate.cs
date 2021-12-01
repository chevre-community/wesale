using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class PhoneNumberActivationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendAgainMinute",
                table: "PhoneNumberActivations");

            migrationBuilder.AddColumn<bool>(
                name: "IsSuccessStatusCode",
                table: "SmsOperationResults",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSuccessStatusCode",
                table: "SmsOperationResults");

            migrationBuilder.AddColumn<int>(
                name: "SendAgainMinute",
                table: "PhoneNumberActivations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
