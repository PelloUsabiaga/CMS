using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS02.Migrations
{
    public partial class _1706202101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Roles",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Permisions",
                newName: "RoleId");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Permisions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "Permisions",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "Permisions");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Roles",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Permisions",
                newName: "Role");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Permisions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }
    }
}
