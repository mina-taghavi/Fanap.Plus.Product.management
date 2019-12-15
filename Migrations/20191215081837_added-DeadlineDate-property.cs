using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fanap.Plus.Product_Management.Migrations
{
    public partial class addedDeadlineDateproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectManagementName",
                table: "Products",
                newName: "ProductManagementName");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeadlineDate",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeadlineDate",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductManagementName",
                table: "Products",
                newName: "ProjectManagementName");
        }
    }
}
