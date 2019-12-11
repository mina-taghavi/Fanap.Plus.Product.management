using Microsoft.EntityFrameworkCore.Migrations;

namespace Fanap.Plus.Product_Management.Migrations
{
    public partial class addedproductforeignkeytomembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Members",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Members_ProductId",
                table: "Members",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Products_ProductId",
                table: "Members",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Products_ProductId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_ProductId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Members");
        }
    }
}
