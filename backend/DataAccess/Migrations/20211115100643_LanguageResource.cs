using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class LanguageResource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LanguageResources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelatedPage = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "*"),
                    ContentKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content_AZ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content_RU = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: ""),
                    Content_EN = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageResources", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageResources");
        }
    }
}
