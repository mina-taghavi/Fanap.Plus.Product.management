using Microsoft.EntityFrameworkCore.Migrations;

namespace Fanap.Plus.Product_Management.Migrations
{
    public partial class deletedevelopmentteamproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DevelopmentTeam",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DevelopmentTeam",
                table: "Products",
                nullable: true);
        }
    }
}
