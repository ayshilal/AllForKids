using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLibrary.Migrations
{
    public partial class Migration14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INSERT_USER_ID = table.Column<long>(nullable: false),
                    INSERT_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    LAST_UPDATE_USER_ID = table.Column<long>(nullable: true),
                    LAST_UPDATE_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    STATUS = table.Column<int>(nullable: false),
                    NAME = table.Column<string>(nullable: true),
                    TYPE = table.Column<string>(nullable: true),
                    SLUG = table.Column<string>(nullable: true),
                    PATH = table.Column<string>(nullable: true),
                    IMAGE = table.Column<string>(nullable: true),
                    ITEMS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
