using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_campaign_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaign_Images_ImageId",
                table: "Campaign");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campaign",
                table: "Campaign");

            migrationBuilder.RenameTable(
                name: "Campaign",
                newName: "Campaigns");

            migrationBuilder.RenameIndex(
                name: "IX_Campaign_ImageId",
                table: "Campaigns",
                newName: "IX_Campaigns_ImageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campaigns",
                table: "Campaigns",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Images_ImageId",
                table: "Campaigns",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Images_ImageId",
                table: "Campaigns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campaigns",
                table: "Campaigns");

            migrationBuilder.RenameTable(
                name: "Campaigns",
                newName: "Campaign");

            migrationBuilder.RenameIndex(
                name: "IX_Campaigns_ImageId",
                table: "Campaign",
                newName: "IX_Campaign_ImageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campaign",
                table: "Campaign",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaign_Images_ImageId",
                table: "Campaign",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
