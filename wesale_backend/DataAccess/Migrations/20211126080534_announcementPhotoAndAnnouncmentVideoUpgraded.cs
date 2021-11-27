using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class announcementPhotoAndAnnouncmentVideoUpgraded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnouncementPhotoUploadRequests");

            migrationBuilder.DropTable(
                name: "AnnouncementVideoUploadRequests");

            migrationBuilder.AddColumn<string>(
                name: "RequestId",
                table: "AnnouncementVideos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AnnouncementVideos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestId",
                table: "AnnouncementPhotos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AnnouncementPhotos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementVideos_UserId",
                table: "AnnouncementVideos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementPhotos_UserId",
                table: "AnnouncementPhotos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementPhotos_Users_UserId",
                table: "AnnouncementPhotos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementVideos_Users_UserId",
                table: "AnnouncementVideos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementPhotos_Users_UserId",
                table: "AnnouncementPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementVideos_Users_UserId",
                table: "AnnouncementVideos");

            migrationBuilder.DropIndex(
                name: "IX_AnnouncementVideos_UserId",
                table: "AnnouncementVideos");

            migrationBuilder.DropIndex(
                name: "IX_AnnouncementPhotos_UserId",
                table: "AnnouncementPhotos");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "AnnouncementVideos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AnnouncementVideos");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "AnnouncementPhotos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AnnouncementPhotos");

            migrationBuilder.CreateTable(
                name: "AnnouncementPhotoUploadRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementPhotoUploadRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementPhotoUploadRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementVideoUploadRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VideoName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementVideoUploadRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementVideoUploadRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementPhotoUploadRequests_RequestId",
                table: "AnnouncementPhotoUploadRequests",
                column: "RequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementPhotoUploadRequests_UserId",
                table: "AnnouncementPhotoUploadRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementVideoUploadRequests_RequestId",
                table: "AnnouncementVideoUploadRequests",
                column: "RequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementVideoUploadRequests_UserId",
                table: "AnnouncementVideoUploadRequests",
                column: "UserId");
        }
    }
}
