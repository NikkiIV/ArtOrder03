using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtOrder03.Infrastructure.Migrations
{
    public partial class DeleteOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommissionOrders_AspNetUsers_UserId",
                table: "CommissionOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Commissions_AspNetUsers_UserId",
                table: "Commissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_AspNetUsers_UserId",
                table: "Sales");

            migrationBuilder.AddForeignKey(
                name: "FK_CommissionOrders_AspNetUsers_UserId",
                table: "CommissionOrders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Commissions_AspNetUsers_UserId",
                table: "Commissions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_AspNetUsers_UserId",
                table: "Sales",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommissionOrders_AspNetUsers_UserId",
                table: "CommissionOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Commissions_AspNetUsers_UserId",
                table: "Commissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_AspNetUsers_UserId",
                table: "Sales");

            migrationBuilder.AddForeignKey(
                name: "FK_CommissionOrders_AspNetUsers_UserId",
                table: "CommissionOrders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commissions_AspNetUsers_UserId",
                table: "Commissions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_AspNetUsers_UserId",
                table: "Sales",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
