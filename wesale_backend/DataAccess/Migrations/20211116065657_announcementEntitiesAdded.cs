using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class announcementEntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsSubscribed = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementBuildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnnouncementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementBuildings_Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WpNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnouncementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementContacts_Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Y = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnouncementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementLocations_Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnnouncementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementObjects_Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnouncementId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementPhotos_Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementRents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<float>(type: "real", nullable: false),
                    AnnouncementRentType = table.Column<int>(type: "int", nullable: false),
                    AnnouncementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementRents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementRents_Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementSales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasCoupon = table.Column<bool>(type: "bit", nullable: false),
                    CostFrom = table.Column<float>(type: "real", nullable: true),
                    CostTo = table.Column<float>(type: "real", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AnnouncementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementSales_Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementVideos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnouncementId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementVideos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementVideos_Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementGardenBuildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<float>(type: "real", nullable: false),
                    AreaOfLand = table.Column<float>(type: "real", nullable: false),
                    AnnouncementBuildingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementGardenBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementGardenBuildings_AnnouncementBuildings_AnnouncementBuildingId",
                        column: x => x.AnnouncementBuildingId,
                        principalTable: "AnnouncementBuildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementHouseBuildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomCount = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<float>(type: "real", nullable: false),
                    AreaOfLand = table.Column<float>(type: "real", nullable: false),
                    AnnouncementBuildingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementHouseBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementHouseBuildings_AnnouncementBuildings_AnnouncementBuildingId",
                        column: x => x.AnnouncementBuildingId,
                        principalTable: "AnnouncementBuildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementNewBuildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomCount = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<float>(type: "real", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    FloorCount = table.Column<int>(type: "int", nullable: false),
                    AnnouncementBuildingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementNewBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementNewBuildings_AnnouncementBuildings_AnnouncementBuildingId",
                        column: x => x.AnnouncementBuildingId,
                        principalTable: "AnnouncementBuildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementOldBuildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomCount = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<float>(type: "real", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    FloorCount = table.Column<int>(type: "int", nullable: false),
                    AnnouncementBuildingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementOldBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementOldBuildings_AnnouncementBuildings_AnnouncementBuildingId",
                        column: x => x.AnnouncementBuildingId,
                        principalTable: "AnnouncementBuildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementContactNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnouncementContactId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementContactNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementContactNumbers_AnnouncementContacts_AnnouncementContactId",
                        column: x => x.AnnouncementContactId,
                        principalTable: "AnnouncementContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementGarageObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<float>(type: "real", nullable: false),
                    AnnouncementObjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementGarageObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementGarageObjects_AnnouncementObjects_AnnouncementObjectId",
                        column: x => x.AnnouncementObjectId,
                        principalTable: "AnnouncementObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementLandObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<float>(type: "real", nullable: false),
                    AnnouncementObjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementLandObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementLandObjects_AnnouncementObjects_AnnouncementObjectId",
                        column: x => x.AnnouncementObjectId,
                        principalTable: "AnnouncementObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementOfficeObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomCount = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<float>(type: "real", nullable: false),
                    AnnouncementOfficeType = table.Column<int>(type: "int", nullable: false),
                    AnnouncementObjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementOfficeObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementOfficeObjects_AnnouncementObjects_AnnouncementObjectId",
                        column: x => x.AnnouncementObjectId,
                        principalTable: "AnnouncementObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementBuildings_AnnouncementId",
                table: "AnnouncementBuildings",
                column: "AnnouncementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementContactNumbers_AnnouncementContactId",
                table: "AnnouncementContactNumbers",
                column: "AnnouncementContactId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementContacts_AnnouncementId",
                table: "AnnouncementContacts",
                column: "AnnouncementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementGarageObjects_AnnouncementObjectId",
                table: "AnnouncementGarageObjects",
                column: "AnnouncementObjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementGardenBuildings_AnnouncementBuildingId",
                table: "AnnouncementGardenBuildings",
                column: "AnnouncementBuildingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementHouseBuildings_AnnouncementBuildingId",
                table: "AnnouncementHouseBuildings",
                column: "AnnouncementBuildingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementLandObjects_AnnouncementObjectId",
                table: "AnnouncementLandObjects",
                column: "AnnouncementObjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementLocations_AnnouncementId",
                table: "AnnouncementLocations",
                column: "AnnouncementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementNewBuildings_AnnouncementBuildingId",
                table: "AnnouncementNewBuildings",
                column: "AnnouncementBuildingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementObjects_AnnouncementId",
                table: "AnnouncementObjects",
                column: "AnnouncementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementOfficeObjects_AnnouncementObjectId",
                table: "AnnouncementOfficeObjects",
                column: "AnnouncementObjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementOldBuildings_AnnouncementBuildingId",
                table: "AnnouncementOldBuildings",
                column: "AnnouncementBuildingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementPhotos_AnnouncementId",
                table: "AnnouncementPhotos",
                column: "AnnouncementId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementRents_AnnouncementId",
                table: "AnnouncementRents",
                column: "AnnouncementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementSales_AnnouncementId",
                table: "AnnouncementSales",
                column: "AnnouncementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementVideos_AnnouncementId",
                table: "AnnouncementVideos",
                column: "AnnouncementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnouncementContactNumbers");

            migrationBuilder.DropTable(
                name: "AnnouncementGarageObjects");

            migrationBuilder.DropTable(
                name: "AnnouncementGardenBuildings");

            migrationBuilder.DropTable(
                name: "AnnouncementHouseBuildings");

            migrationBuilder.DropTable(
                name: "AnnouncementLandObjects");

            migrationBuilder.DropTable(
                name: "AnnouncementLocations");

            migrationBuilder.DropTable(
                name: "AnnouncementNewBuildings");

            migrationBuilder.DropTable(
                name: "AnnouncementOfficeObjects");

            migrationBuilder.DropTable(
                name: "AnnouncementOldBuildings");

            migrationBuilder.DropTable(
                name: "AnnouncementPhotos");

            migrationBuilder.DropTable(
                name: "AnnouncementRents");

            migrationBuilder.DropTable(
                name: "AnnouncementSales");

            migrationBuilder.DropTable(
                name: "AnnouncementVideos");

            migrationBuilder.DropTable(
                name: "AnnouncementContacts");

            migrationBuilder.DropTable(
                name: "AnnouncementObjects");

            migrationBuilder.DropTable(
                name: "AnnouncementBuildings");

            migrationBuilder.DropTable(
                name: "Announcements");
        }
    }
}
