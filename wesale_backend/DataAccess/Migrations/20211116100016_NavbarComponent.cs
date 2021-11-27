using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class NavbarComponent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NavbarComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_AZ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_RU = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: ""),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: ""),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Order = table.Column<int>(type: "int", nullable: false),
                    RequireAuthorization = table.Column<bool>(type: "bit", nullable: false),
                    ShowOnHeader = table.Column<bool>(type: "bit", nullable: false),
                    ShowOnFooter = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavbarComponents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NavbarComponents");
        }
    }
}
