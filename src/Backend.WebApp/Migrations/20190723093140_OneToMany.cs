using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.WebApp.Migrations
{
    public partial class OneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Roles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_GroupId",
                table: "Roles",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Groups_GroupId",
                table: "Roles",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Groups_GroupId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_GroupId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Roles");
        }
    }
}
