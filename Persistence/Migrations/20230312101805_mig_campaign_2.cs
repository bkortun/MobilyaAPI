using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_campaign_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CampaignName",
                table: "Campaign",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CampaignDescription",
                table: "Campaign",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Campaign",
                newName: "CampaignName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Campaign",
                newName: "CampaignDescription");
        }
    }
}
