using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLibrary.Migrations
{
    public partial class MigrationThree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ApplicationDB");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customer",
                newSchema: "ApplicationDB");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "ApplicationDB",
                table: "Customer",
                newName: "NAME");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Customer",
                schema: "ApplicationDB",
                newName: "Customer");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "Customer",
                newName: "Name");
        }
    }
}
