using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCancel",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "Cancel",
                table: "Orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Complete",
                table: "Orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cancel",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Complete",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "IsCancel",
                table: "Orders",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "Orders",
                type: "boolean",
                nullable: false,
                defaultValue: true);
        }
    }
}
