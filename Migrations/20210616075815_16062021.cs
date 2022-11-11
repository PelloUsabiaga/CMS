using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS02.Migrations
{
    public partial class _16062021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Document",
                newName: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Document",
                newName: "Data");
        }
    }
}
