using Microsoft.EntityFrameworkCore.Migrations;

namespace Chefs.Migrations
{
    public partial class LinksMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Dishes_ChefID",
                table: "Dishes",
                column: "ChefID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Chefs_ChefID",
                table: "Dishes",
                column: "ChefID",
                principalTable: "Chefs",
                principalColumn: "ChefID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Chefs_ChefID",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_ChefID",
                table: "Dishes");
        }
    }
}
