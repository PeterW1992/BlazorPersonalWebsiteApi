using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorPersonalWebsite.EntityFramework.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobApplication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobApplicationRef = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DateApplied = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Outcome = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplication", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectRef = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareProject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WoodworkProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectRef = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WoodworkProject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareProjectImage",
                columns: table => new
                {
                    SoftwareProjectImageId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    SoftwareProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareProjectImage", x => x.SoftwareProjectImageId);
                    table.ForeignKey(
                        name: "FK_SoftwareProjectImage_SoftwareProject_SoftwareProjectId",
                        column: x => x.SoftwareProjectId,
                        principalTable: "SoftwareProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WoodworkProjectImage",
                columns: table => new
                {
                    WoodworkProjectImageId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    WoodworkProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WoodworkProjectImage", x => x.WoodworkProjectImageId);
                    table.ForeignKey(
                        name: "FK_WoodworkProjectImage_WoodworkProject_WoodworkProjectId",
                        column: x => x.WoodworkProjectId,
                        principalTable: "WoodworkProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SoftwareProject",
                columns: new[] { "Id", "DateCreated", "Description", "Name", "ProjectRef" },
                values: new object[] { 1, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Skill action calculator for video game Runescape", "Runescape Calculator", "rsCalc" });

            migrationBuilder.InsertData(
                table: "SoftwareProject",
                columns: new[] { "Id", "DateCreated", "Description", "Name", "ProjectRef" },
                values: new object[] { 2, new DateTime(2016, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "University e-commerce book store", "uniEcomm" });

            migrationBuilder.InsertData(
                table: "SoftwareProject",
                columns: new[] { "Id", "DateCreated", "Description", "Name", "ProjectRef" },
                values: new object[] { 3, new DateTime(2016, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Loyalty Pro Android App", "loyaltyProApp" });

            migrationBuilder.InsertData(
                table: "SoftwareProject",
                columns: new[] { "Id", "DateCreated", "Description", "Name", "ProjectRef" },
                values: new object[] { 4, new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "University Dissertation - GPS Logger", "uniDis" });

            migrationBuilder.InsertData(
                table: "WoodworkProject",
                columns: new[] { "Id", "DateCreated", "Description", "Name", "ProjectRef" },
                values: new object[] { 1, new DateTime(2017, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Side Gate", "sideGate" });

            migrationBuilder.InsertData(
                table: "WoodworkProject",
                columns: new[] { "Id", "DateCreated", "Description", "Name", "ProjectRef" },
                values: new object[] { 2, new DateTime(2017, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Workbench", "workbench" });

            migrationBuilder.InsertData(
                table: "WoodworkProject",
                columns: new[] { "Id", "DateCreated", "Description", "Name", "ProjectRef" },
                values: new object[] { 3, new DateTime(2017, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bird table", "birdTable" });

            migrationBuilder.InsertData(
                table: "WoodworkProject",
                columns: new[] { "Id", "DateCreated", "Description", "Name", "ProjectRef" },
                values: new object[] { 4, new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Raised Garden bed (Small)", "raisedGardenBendSmall" });

            migrationBuilder.InsertData(
                table: "WoodworkProject",
                columns: new[] { "Id", "DateCreated", "Description", "Name", "ProjectRef" },
                values: new object[] { 5, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Raised Garden bed (Large)", "raisedGardenBendLarge" });

            migrationBuilder.InsertData(
                table: "SoftwareProjectImage",
                columns: new[] { "SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId" },
                values: new object[] { 1, "Agility skill calculator", "images\\software-images\\rs-calculator\\1.png", 1 });

            migrationBuilder.InsertData(
                table: "SoftwareProjectImage",
                columns: new[] { "SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId" },
                values: new object[] { 21, "Open side bar", "images\\software-images\\gps-logger\\5.png", 4 });

            migrationBuilder.InsertData(
                table: "SoftwareProjectImage",
                columns: new[] { "SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId" },
                values: new object[] { 20, "Staypoint shown on map", "images\\software-images\\gps-logger\\4.png", 4 });

            migrationBuilder.InsertData(
                table: "SoftwareProjectImage",
                columns: new[] { "SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId" },
                values: new object[] { 19, "Staypoint overview showing individual visits", "images\\software-images\\gps-logger\\3.png", 4 });

            migrationBuilder.InsertData(
                table: "SoftwareProjectImage",
                columns: new[] { "SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId" },
                values: new object[] { 18, "Individual journey view", "images\\software-images\\gps-logger\\2.png", 4 });

            migrationBuilder.InsertData(
                table: "SoftwareProjectImage",
                columns: new[] { "SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId" },
                values: new object[] { 17, "Display showing journeys between two staypoints", "images\\software-images\\gps-logger\\1.png", 4 });

            migrationBuilder.InsertData(
                table: "SoftwareProjectImage",
                columns: new[] { "SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId" },
                values: new object[] { 16, "Manual log in page", "images\\software-images\\loyalty-pro-app\\6.png", 3 });

            migrationBuilder.InsertData(
                table: "SoftwareProjectImage",
                columns: new[] { "SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId" },
                values: new object[] { 15, "Initial unlogged in page", "images\\software-images\\loyalty-pro-app\\5.png", 3 });

            migrationBuilder.InsertData(
                table: "SoftwareProjectImage",
                columns: new[] { "SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId" },
                values: new object[] { 14, "Vouchers overview page", "images\\software-images\\loyalty-pro-app\\4.png", 3 });

            migrationBuilder.InsertData(
                table: "SoftwareProjectImage",
                columns: new[] { "SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId" },
                values: new object[] { 12, "Balance overview page", "images\\software-images\\loyalty-pro-app\\2.png", 3 });

            migrationBuilder.InsertData(
                table: "SoftwareProjectImage",
                columns: new[] { "SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId" },
                values: new object[] { 13, "Personal details page", "images\\software-images\\loyalty-pro-app\\3.png", 3 });

            migrationBuilder.InsertData(
                table: "SoftwareProjectImage",
                columns: new[] { "SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId" },
                values: new object[] { 10, "Ecommerce contact us page", "images\\software-images\\ecommerce-site\\6.png", 2 });

            migrationBuilder.InsertData(
                table: "SoftwareProjectImage",
                columns: new[] { "SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId" },
                values: new object[] { 9, "Ecommerce admin page - Edit listing", "images\\software-images\\ecommerce-site\\5.png", 2 });

            migrationBuilder.InsertData(
                table: "SoftwareProjectImage",
                columns: new[] { "SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId" },
                values: new object[] { 8, "Ecommerce admin page", "images\\software-images\\ecommerce-site\\4.png", 2 });

            migrationBuilder.InsertData(
                table: "SoftwareProjectImage",
                columns: new[] { "SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId" },
                values: new object[] { 7, "Ecommerce basket page", "images\\software-images\\ecommerce-site\\3.png", 2 });

            migrationBuilder.InsertData(
                table: "SoftwareProjectImage",
                columns: new[] { "SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId" },
                values: new object[] { 6, "Ecommerce product page", "images\\software-images\\ecommerce-site\\2.png", 2 });

            migrationBuilder.InsertData(
                table: "SoftwareProjectImage",
                columns: new[] { "SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId" },
                values: new object[] { 5, "Ecommerce homepage", "images\\software-images\\ecommerce-site\\1.png", 2 });

            migrationBuilder.InsertData(
                table: "SoftwareProjectImage",
                columns: new[] { "SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId" },
                values: new object[] { 4, "Dropdown showing skill subcategories", "images\\software-images\\rs-calculator\\4.png", 1 });

            migrationBuilder.InsertData(
                table: "SoftwareProjectImage",
                columns: new[] { "SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId" },
                values: new object[] { 3, "Dropdown showing which skills are included", "images\\software-images\\rs-calculator\\3.png", 1 });

            migrationBuilder.InsertData(
                table: "SoftwareProjectImage",
                columns: new[] { "SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId" },
                values: new object[] { 2, "Fishing skill calculator", "images\\software-images\\rs-calculator\\2.png", 1 });

            migrationBuilder.InsertData(
                table: "SoftwareProjectImage",
                columns: new[] { "SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId" },
                values: new object[] { 11, "Main menu", "images\\software-images\\loyalty-pro-app\\1.png", 3 });

            migrationBuilder.InsertData(
                table: "WoodworkProjectImage",
                columns: new[] { "WoodworkProjectImageId", "Description", "ImageUrl", "WoodworkProjectId" },
                values: new object[] { 4, "All raised garden beds", "images\\woodwork-images\\raised-garden-bed\\all-in-view.jpg", 4 });

            migrationBuilder.InsertData(
                table: "WoodworkProjectImage",
                columns: new[] { "WoodworkProjectImageId", "Description", "ImageUrl", "WoodworkProjectId" },
                values: new object[] { 1, "Unhung gate", "images\\woodwork-images\\side-gate\\sidegate-unhung.jpg", 1 });

            migrationBuilder.InsertData(
                table: "WoodworkProjectImage",
                columns: new[] { "WoodworkProjectImageId", "Description", "ImageUrl", "WoodworkProjectId" },
                values: new object[] { 2, "Unfinished workbench", "images\\woodwork-images\\workbench\\workbench-unfinished.jpg", 2 });

            migrationBuilder.InsertData(
                table: "WoodworkProjectImage",
                columns: new[] { "WoodworkProjectImageId", "Description", "ImageUrl", "WoodworkProjectId" },
                values: new object[] { 3, "Unfinished workbench", "images\\woodwork-images\\bird-table\\bird-table.jpg", 3 });

            migrationBuilder.InsertData(
                table: "WoodworkProjectImage",
                columns: new[] { "WoodworkProjectImageId", "Description", "ImageUrl", "WoodworkProjectId" },
                values: new object[] { 5, "All raised garden beds", "images\\woodwork-images\\raised-garden-bed\\all-in-view.jpg", 5 });

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareProjectImage_SoftwareProjectId",
                table: "SoftwareProjectImage",
                column: "SoftwareProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WoodworkProjectImage_WoodworkProjectId",
                table: "WoodworkProjectImage",
                column: "WoodworkProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobApplication");

            migrationBuilder.DropTable(
                name: "SoftwareProjectImage");

            migrationBuilder.DropTable(
                name: "WoodworkProjectImage");

            migrationBuilder.DropTable(
                name: "SoftwareProject");

            migrationBuilder.DropTable(
                name: "WoodworkProject");
        }
    }
}
