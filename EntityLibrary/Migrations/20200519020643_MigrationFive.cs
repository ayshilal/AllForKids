using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLibrary.Migrations
{
    public partial class MigrationFive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Purchase_PurchaseID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Purchase_PurchaseID",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Product_PurchaseID",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_PurchaseID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PurchaseID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PurchaseID",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "USER",
                newSchema: "ApplicationDB");

            migrationBuilder.RenameColumn(
                name: "InsertDate",
                schema: "ApplicationDB",
                table: "Customer",
                newName: "INSERT_DATE");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "ApplicationDB",
                table: "USER",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "InsertDate",
                schema: "ApplicationDB",
                table: "USER",
                newName: "INSERT_DATE");

            migrationBuilder.AlterColumn<DateTime>(
                name: "INSERT_DATE",
                schema: "ApplicationDB",
                table: "Customer",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<long>(
                name: "INSERT_USER_ID",
                schema: "ApplicationDB",
                table: "Customer",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "LAST_UPDATE_DATE",
                schema: "ApplicationDB",
                table: "Customer",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LAST_UPDATE_USER_ID",
                schema: "ApplicationDB",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "STATUS",
                schema: "ApplicationDB",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "InsertUserId",
                table: "Purchase",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Purchase",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastUpdateUserId",
                table: "Purchase",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Purchase",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "InsertUserId",
                table: "Product",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastUpdateUserId",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                schema: "ApplicationDB",
                table: "USER",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "INSERT_DATE",
                schema: "ApplicationDB",
                table: "USER",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<long>(
                name: "INSERT_USER_ID",
                schema: "ApplicationDB",
                table: "USER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "LAST_UPDATE_DATE",
                schema: "ApplicationDB",
                table: "USER",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LAST_UPDATE_USER_ID",
                schema: "ApplicationDB",
                table: "USER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "STATUS",
                schema: "ApplicationDB",
                table: "USER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_USER",
                schema: "ApplicationDB",
                table: "USER",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "ApplicationDB",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INSERT_USER_ID = table.Column<long>(nullable: false),
                    INSERT_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    LAST_UPDATE_USER_ID = table.Column<long>(nullable: true),
                    LAST_UPDATE_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    STATUS = table.Column<int>(nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_USER_INSERT_USER_ID",
                schema: "ApplicationDB",
                table: "USER",
                column: "INSERT_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_LAST_UPDATE_USER_ID",
                schema: "ApplicationDB",
                table: "USER",
                column: "LAST_UPDATE_USER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category",
                schema: "ApplicationDB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USER",
                schema: "ApplicationDB",
                table: "USER");

            migrationBuilder.DropIndex(
                name: "IX_USER_INSERT_USER_ID",
                schema: "ApplicationDB",
                table: "USER");

            migrationBuilder.DropIndex(
                name: "IX_USER_LAST_UPDATE_USER_ID",
                schema: "ApplicationDB",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "INSERT_USER_ID",
                schema: "ApplicationDB",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "LAST_UPDATE_DATE",
                schema: "ApplicationDB",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "LAST_UPDATE_USER_ID",
                schema: "ApplicationDB",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "STATUS",
                schema: "ApplicationDB",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "InsertUserId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "LastUpdateUserId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "InsertUserId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "LastUpdateUserId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "INSERT_USER_ID",
                schema: "ApplicationDB",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "LAST_UPDATE_DATE",
                schema: "ApplicationDB",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "LAST_UPDATE_USER_ID",
                schema: "ApplicationDB",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "STATUS",
                schema: "ApplicationDB",
                table: "USER");

            migrationBuilder.RenameTable(
                name: "USER",
                schema: "ApplicationDB",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "INSERT_DATE",
                schema: "ApplicationDB",
                table: "Customer",
                newName: "InsertDate");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "User",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "INSERT_DATE",
                table: "User",
                newName: "InsertDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                schema: "ApplicationDB",
                table: "Customer",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<long>(
                name: "PurchaseID",
                table: "Product",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<long>(
                name: "PurchaseID",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_PurchaseID",
                table: "Product",
                column: "PurchaseID");

            migrationBuilder.CreateIndex(
                name: "IX_User_PurchaseID",
                table: "User",
                column: "PurchaseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Purchase_PurchaseID",
                table: "Product",
                column: "PurchaseID",
                principalTable: "Purchase",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Purchase_PurchaseID",
                table: "User",
                column: "PurchaseID",
                principalTable: "Purchase",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
