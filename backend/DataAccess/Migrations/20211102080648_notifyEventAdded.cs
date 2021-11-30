using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class notifyEventAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotifyEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotifyFor = table.Column<int>(type: "int", nullable: false),
                    EmailEnabled = table.Column<bool>(type: "bit", nullable: false),
                    EmailText_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailText_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailText_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMSEnabled = table.Column<bool>(type: "bit", nullable: false),
                    SMSText_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMSText_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMSText_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotifyEvents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotifyEvents");
        }
    }
}
