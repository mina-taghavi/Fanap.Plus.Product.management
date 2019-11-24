using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fanap.Plus.Product_Management.Migrations
{
    public partial class removeidteamassignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamAssignment_Products_ProductID",
                table: "TeamAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamAssignment_Teams_TeamID",
                table: "TeamAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamAssignment",
                table: "TeamAssignment");

            migrationBuilder.DropIndex(
                name: "IX_TeamAssignment_TeamID",
                table: "TeamAssignment");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TeamAssignment");

            migrationBuilder.RenameColumn(
                name: "TeamID",
                table: "TeamAssignment",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "TeamAssignment",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamAssignment_ProductID",
                table: "TeamAssignment",
                newName: "IX_TeamAssignment_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamAssignment",
                table: "TeamAssignment",
                columns: new[] { "TeamId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeamAssignment_Products_ProductId",
                table: "TeamAssignment",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamAssignment_Teams_TeamId",
                table: "TeamAssignment",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamAssignment_Products_ProductId",
                table: "TeamAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamAssignment_Teams_TeamId",
                table: "TeamAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamAssignment",
                table: "TeamAssignment");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "TeamAssignment",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "TeamAssignment",
                newName: "TeamID");

            migrationBuilder.RenameIndex(
                name: "IX_TeamAssignment_ProductId",
                table: "TeamAssignment",
                newName: "IX_TeamAssignment_ProductID");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TeamAssignment",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamAssignment",
                table: "TeamAssignment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TeamAssignment_TeamID",
                table: "TeamAssignment",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamAssignment_Products_ProductID",
                table: "TeamAssignment",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamAssignment_Teams_TeamID",
                table: "TeamAssignment",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
