using Microsoft.EntityFrameworkCore.Migrations;

namespace Fanap.Plus.Product_Management.Migrations
{
    public partial class nullableproductidformember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Products_ProductId",
                table: "Members");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Members",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Products_ProductId",
                table: "Members",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Products_ProductId",
                table: "Members");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Members",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Products_ProductId",
                table: "Members",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
