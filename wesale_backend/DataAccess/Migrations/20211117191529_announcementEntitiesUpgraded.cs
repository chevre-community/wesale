using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class announcementEntitiesUpgraded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementBuildings_Announcements_AnnouncementId",
                table: "AnnouncementBuildings");

            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementObjects_Announcements_AnnouncementId",
                table: "AnnouncementObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementRents_Announcements_AnnouncementId",
                table: "AnnouncementRents");

            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementSales_Announcements_AnnouncementId",
                table: "AnnouncementSales");

            migrationBuilder.DropIndex(
                name: "IX_AnnouncementSales_AnnouncementId",
                table: "AnnouncementSales");

            migrationBuilder.DropIndex(
                name: "IX_AnnouncementRents_AnnouncementId",
                table: "AnnouncementRents");

            migrationBuilder.DropColumn(
                name: "AnnouncementId",
                table: "AnnouncementSales");

            migrationBuilder.DropColumn(
                name: "AnnouncementId",
                table: "AnnouncementRents");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "AnnouncementSales",
                newName: "AnnouncementDealId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "AnnouncementRents",
                newName: "AnnouncementDealId");

            migrationBuilder.RenameColumn(
                name: "AnnouncementId",
                table: "AnnouncementObjects",
                newName: "AnnouncementPropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_AnnouncementObjects_AnnouncementId",
                table: "AnnouncementObjects",
                newName: "IX_AnnouncementObjects_AnnouncementPropertyId");

            migrationBuilder.RenameColumn(
                name: "AnnouncementId",
                table: "AnnouncementBuildings",
                newName: "AnnouncementPropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_AnnouncementBuildings_AnnouncementId",
                table: "AnnouncementBuildings",
                newName: "IX_AnnouncementBuildings_AnnouncementPropertyId");

            migrationBuilder.CreateTable(
                name: "AnnouncementDeals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SubType = table.Column<int>(type: "int", nullable: false),
                    AnnouncementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementDeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementDeals_Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SubType = table.Column<int>(type: "int", nullable: false),
                    AnnouncementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementProperties_Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementSales_AnnouncementDealId",
                table: "AnnouncementSales",
                column: "AnnouncementDealId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementRents_AnnouncementDealId",
                table: "AnnouncementRents",
                column: "AnnouncementDealId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementDeals_AnnouncementId",
                table: "AnnouncementDeals",
                column: "AnnouncementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementProperties_AnnouncementId",
                table: "AnnouncementProperties",
                column: "AnnouncementId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementBuildings_AnnouncementProperties_AnnouncementPropertyId",
                table: "AnnouncementBuildings",
                column: "AnnouncementPropertyId",
                principalTable: "AnnouncementProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementObjects_AnnouncementProperties_AnnouncementPropertyId",
                table: "AnnouncementObjects",
                column: "AnnouncementPropertyId",
                principalTable: "AnnouncementProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementRents_AnnouncementDeals_AnnouncementDealId",
                table: "AnnouncementRents",
                column: "AnnouncementDealId",
                principalTable: "AnnouncementDeals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementSales_AnnouncementDeals_AnnouncementDealId",
                table: "AnnouncementSales",
                column: "AnnouncementDealId",
                principalTable: "AnnouncementDeals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementBuildings_AnnouncementProperties_AnnouncementPropertyId",
                table: "AnnouncementBuildings");

            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementObjects_AnnouncementProperties_AnnouncementPropertyId",
                table: "AnnouncementObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementRents_AnnouncementDeals_AnnouncementDealId",
                table: "AnnouncementRents");

            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementSales_AnnouncementDeals_AnnouncementDealId",
                table: "AnnouncementSales");

            migrationBuilder.DropTable(
                name: "AnnouncementDeals");

            migrationBuilder.DropTable(
                name: "AnnouncementProperties");

            migrationBuilder.DropIndex(
                name: "IX_AnnouncementSales_AnnouncementDealId",
                table: "AnnouncementSales");

            migrationBuilder.DropIndex(
                name: "IX_AnnouncementRents_AnnouncementDealId",
                table: "AnnouncementRents");

            migrationBuilder.RenameColumn(
                name: "AnnouncementDealId",
                table: "AnnouncementSales",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "AnnouncementDealId",
                table: "AnnouncementRents",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "AnnouncementPropertyId",
                table: "AnnouncementObjects",
                newName: "AnnouncementId");

            migrationBuilder.RenameIndex(
                name: "IX_AnnouncementObjects_AnnouncementPropertyId",
                table: "AnnouncementObjects",
                newName: "IX_AnnouncementObjects_AnnouncementId");

            migrationBuilder.RenameColumn(
                name: "AnnouncementPropertyId",
                table: "AnnouncementBuildings",
                newName: "AnnouncementId");

            migrationBuilder.RenameIndex(
                name: "IX_AnnouncementBuildings_AnnouncementPropertyId",
                table: "AnnouncementBuildings",
                newName: "IX_AnnouncementBuildings_AnnouncementId");

            migrationBuilder.AddColumn<int>(
                name: "AnnouncementId",
                table: "AnnouncementSales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnnouncementId",
                table: "AnnouncementRents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementSales_AnnouncementId",
                table: "AnnouncementSales",
                column: "AnnouncementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementRents_AnnouncementId",
                table: "AnnouncementRents",
                column: "AnnouncementId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementBuildings_Announcements_AnnouncementId",
                table: "AnnouncementBuildings",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementObjects_Announcements_AnnouncementId",
                table: "AnnouncementObjects",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementRents_Announcements_AnnouncementId",
                table: "AnnouncementRents",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementSales_Announcements_AnnouncementId",
                table: "AnnouncementSales",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
