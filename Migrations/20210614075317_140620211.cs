using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS02.Migrations
{
    public partial class _140620211 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StateId",
                table: "Users",
                newName: "StatesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatesId",
                table: "Users",
                newName: "StateId");
        }
    }
}
