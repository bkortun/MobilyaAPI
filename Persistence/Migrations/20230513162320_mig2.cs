using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Complete",
                table: "Orders",
                newName: "IsCompleted");

            migrationBuilder.RenameColumn(
                name: "Cancel",
                table: "Orders",
                newName: "IsCanceled");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "Orders",
                newName: "Complete");

            migrationBuilder.RenameColumn(
                name: "IsCanceled",
                table: "Orders",
                newName: "Cancel");
        }
    }
}
