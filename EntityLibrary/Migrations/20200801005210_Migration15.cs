using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLibrary.Migrations
{
    public partial class Migration15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Product",
                newName: "STATUS");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Product",
                newName: "PRICE");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Product",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "LastUpdateUserId",
                table: "Product",
                newName: "LAST_UPDATE_USER_ID");

            migrationBuilder.RenameColumn(
                name: "LastUpdateDate",
                table: "Product",
                newName: "LAST_UPDATE_DATE");

            migrationBuilder.RenameColumn(
                name: "InsertUserId",
                table: "Product",
                newName: "INSERT_USER_ID");

            migrationBuilder.RenameColumn(
                name: "InsertDate",
                table: "Product",
                newName: "INSERT_DATE");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LAST_UPDATE_DATE",
                table: "Product",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "INSERT_DATE",
                table: "Product",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "AVAILABILITY",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "COMPAREATPRICE",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "IMAGES",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RATING",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "REVIEWS",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SLUG",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brand",
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
                    SLUG = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttribute",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INSERT_USER_ID = table.Column<long>(nullable: false),
                    INSERT_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    LAST_UPDATE_USER_ID = table.Column<long>(nullable: true),
                    LAST_UPDATE_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    STATUS = table.Column<int>(nullable: false),
                    SLUG = table.Column<string>(nullable: true),
                    NAME = table.Column<string>(nullable: true),
                    FEATURED = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttribute", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributeValue",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INSERT_USER_ID = table.Column<long>(nullable: false),
                    INSERT_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    LAST_UPDATE_USER_ID = table.Column<long>(nullable: true),
                    LAST_UPDATE_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    STATUS = table.Column<int>(nullable: false),
                    SLUG = table.Column<string>(nullable: true),
                    NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeValue", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "ProductAttribute");

            migrationBuilder.DropTable(
                name: "ProductAttributeValue");

            migrationBuilder.DropColumn(
                name: "AVAILABILITY",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "COMPAREATPRICE",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IMAGES",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "RATING",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "REVIEWS",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SLUG",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "STATUS",
                table: "Product",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "PRICE",
                table: "Product",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "Product",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LAST_UPDATE_USER_ID",
                table: "Product",
                newName: "LastUpdateUserId");

            migrationBuilder.RenameColumn(
                name: "LAST_UPDATE_DATE",
                table: "Product",
                newName: "LastUpdateDate");

            migrationBuilder.RenameColumn(
                name: "INSERT_USER_ID",
                table: "Product",
                newName: "InsertUserId");

            migrationBuilder.RenameColumn(
                name: "INSERT_DATE",
                table: "Product",
                newName: "InsertDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Product",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}
