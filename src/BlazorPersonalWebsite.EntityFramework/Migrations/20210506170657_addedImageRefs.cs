using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorPersonalWebsite.EntityFramework.Migrations
{
    public partial class addedImageRefs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageRef",
                table: "WoodworkProjectImage",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectRef",
                table: "WoodworkProject",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageRef",
                table: "SoftwareProjectImage",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectRef",
                table: "SoftwareProject",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_WoodworkProject_ProjectRef",
                table: "WoodworkProject",
                column: "ProjectRef");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_SoftwareProject_ProjectRef",
                table: "SoftwareProject",
                column: "ProjectRef");

            migrationBuilder.UpdateData(
                table: "WoodworkProjectImage",
                keyColumn: "WoodworkProjectImageId",
                keyValue: 1,
                column: "ImageRef",
                value: "unhungGate");

            migrationBuilder.UpdateData(
                table: "WoodworkProjectImage",
                keyColumn: "WoodworkProjectImageId",
                keyValue: 2,
                column: "ImageRef",
                value: "unfinishedWorkbench");

            migrationBuilder.UpdateData(
                table: "WoodworkProjectImage",
                keyColumn: "WoodworkProjectImageId",
                keyValue: 3,
                columns: new[] { "Description", "ImageRef" },
                values: new object[] { "Bird Table", "birdTable" });

            migrationBuilder.UpdateData(
                table: "WoodworkProjectImage",
                keyColumn: "WoodworkProjectImageId",
                keyValue: 4,
                column: "ImageRef",
                value: "allRaisedBed");

            migrationBuilder.UpdateData(
                table: "WoodworkProjectImage",
                keyColumn: "WoodworkProjectImageId",
                keyValue: 5,
                column: "ImageRef",
                value: "allRaisedBed2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_WoodworkProject_ProjectRef",
                table: "WoodworkProject");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_SoftwareProject_ProjectRef",
                table: "SoftwareProject");

            migrationBuilder.DropColumn(
                name: "ImageRef",
                table: "WoodworkProjectImage");

            migrationBuilder.DropColumn(
                name: "ImageRef",
                table: "SoftwareProjectImage");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectRef",
                table: "WoodworkProject",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectRef",
                table: "SoftwareProject",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "WoodworkProjectImage",
                keyColumn: "WoodworkProjectImageId",
                keyValue: 3,
                column: "Description",
                value: "Unfinished workbench");
        }
    }
}
