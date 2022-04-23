using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtOrder03.Infrastructure.Migrations
{
    public partial class EditCommissionInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CommissionInfos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "CommissionInfos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CommissionInfos");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "CommissionInfos");
        }
    }
}
